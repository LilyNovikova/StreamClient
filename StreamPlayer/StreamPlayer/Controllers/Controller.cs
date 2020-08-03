using StreamPlayer.RTP;
using StreamPlayer.RTSP;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using View = StreamPlayer.Views.View;

namespace StreamPlayer.Controllers
{
    public class Controller
    {
        private static View view;
        private RtspModel rtspModel = null;
        private Thread videoTimerThread = null;
        private RtpModel rtpModel = null;
        private byte[] videoFrame;
        private string sessionNum;
        private int ClientPort;

        //Connect button is clicked
        public void Connect(object sender, EventArgs e)
        {
            //Determine which view to control
            view = (View)((Button)sender).FindForm();

            //disable the connect button
            view.DisableConnectBtn();

            ClientPort = int.Parse(ViewClientPort);

            //Listen for server
            this.ListenForServer();

            rtspModel.Send(new RtspRequest
            {
                RequestType = RtspRequest.RtspRequestType.DESCRIBE,
                FileName = VideoName
            });

            //wait for the reply from the server
            try
            {
                var response = rtspModel.Listen();

                var files = response.Content.Split(';')
                    .Where(file => file != string.Empty)
                    .ToArray();
                UpdateVideosList(files);

                UpdateServerBox(response.ToString() + Environment.NewLine);
                UpdateClientBox("New RTSP State: CONNECTED" + Environment.NewLine);
                //disable & enable appropriate buttons
                view.EnableButton(View.Buttons.Setup);
                view.EnableFilesCmb();
            }
            catch (ArgumentException ex)
            {
                UpdateServerBox($"Error: {ex.Message}{Environment.NewLine}");
            }

        }

        //Setup button is clicked
        public void Setup(object sender, EventArgs e)
        {
            //Determine which view to control
            view = (View)((Button)sender).FindForm();

            //send the request message to the server
            rtspModel.Send(new RtspRequest
            {
                RequestType = RtspRequest.RtspRequestType.SETUP,
                FileName = VideoName
            });

            //wait for the reply from the server
            try
            {
                var response = rtspModel.Listen();
                sessionNum = response.Session;

                UpdateServerBox(response.ToString() + Environment.NewLine);
                UpdateClientBox("New RTSP State: READY" + Environment.NewLine);
                //disable & enable appropriate buttons
                view.DisableButton(View.Buttons.Setup);
                view.EnableButton(View.Buttons.Play);
                view.SetImageBoxBlack();
            }
            catch (ArgumentException ex)
            {
                UpdateServerBox($"Error: {ex.Message}{Environment.NewLine}");
            }
        }

        //Play button is clicked
        public void Play(object sender, EventArgs e)
        {
            //Determine which view to control
            view = (View)((Button)sender).FindForm();

            //send the request message to the server
            rtspModel.Send(new RtspRequest
            {
                RequestType = RtspRequest.RtspRequestType.PLAY,
                FileName = VideoName,
                SessionID = sessionNum
            });

            //wait for the reply from the server
            try
            {
                var response = rtspModel.Listen();

                UpdateServerBox(response.ToString() + Environment.NewLine);
                //Start UDP video thread to start receiving images
                if (videoTimerThread == null)
                {
                    this.videoTimerThread = new Thread(Communications);
                    videoTimerThread.IsBackground = true; //to stop all threads with application is terminated
                    this.videoTimerThread.Start();
                }
                UpdateClientBox("New RTSP State: PLAYING" + Environment.NewLine);
                //disable & enable appropriate buttons
                view.DisableButton(View.Buttons.Play);
                view.EnableButton(View.Buttons.Pause);
                view.EnableButton(View.Buttons.Teardowm);
            }
            catch (ArgumentException ex)
            {
                UpdateServerBox($"Error: {ex.Message}{Environment.NewLine}");
            }
        }

        //Pause button is clicked
        public void Pause(object sender, EventArgs e)
        {
            //Determine which view to control
            view = (View)((Button)sender).FindForm();

            //send the request message to the server
            rtspModel.Send(new RtspRequest
            {
                RequestType = RtspRequest.RtspRequestType.PAUSE,
                FileName = VideoName,
                SessionID = sessionNum
            });

            //wait for the reply from the server
            try
            {
                var response = rtspModel.Listen();

                UpdateServerBox(response.ToString() + Environment.NewLine);
                UpdateClientBox("New RTSP State: PAUSED" + Environment.NewLine);

                //disable & enable appropriate buttons
                view.DisableButton(View.Buttons.Setup);
                view.DisableButton(View.Buttons.Pause);
                view.EnableButton(View.Buttons.Play);
            }
            catch (ArgumentException ex)
            {
                UpdateServerBox($"Error: {ex.Message}{Environment.NewLine}");
            }
        }

        //Tear down button is clicked
        public void Teardown(object sender, EventArgs e)
        {
            //Determine which view to control
            view = (View)((Button)sender).FindForm();

            //send the request message to the server
            rtspModel.Send(new RtspRequest
            {
                RequestType = RtspRequest.RtspRequestType.TEARDOWN,
                FileName = VideoName,
                SessionID = sessionNum
            });

            //wait for the reply from the server
            try
            {
                var response = rtspModel.Listen();
                sessionNum = response.Session;

                UpdateServerBox(response.ToString() + Environment.NewLine);
                UpdateClientBox("New RTSP State: TEARDOWN" + Environment.NewLine);
                //reset sequence number
                rtspModel.CSeqNum = 1;

                //disable & enable appropriate buttons
                view.EnableButton(View.Buttons.Setup);
                view.DisableButton(View.Buttons.Play);
                view.DisableButton(View.Buttons.Pause);
                view.DisableButton(View.Buttons.Teardowm);
            }
            catch (ArgumentException ex)
            {
                UpdateServerBox($"Error: {ex.Message}{Environment.NewLine}");
            }
        }

        //close application
        public void Exit(object sender, EventArgs e)
        {
            if (videoTimerThread != null)
            {
                this.videoTimerThread.Abort();
            }
            Application.Exit();
        }

        //communications thread for UDP socket to receive video frames
        public void Communications()
        {
            //used to receive video frames from server
            rtpModel = new RtpModel(this.ServerIP, this.ServerPort, ClientPort);

            while (true)
            {
                //converts the video frame into an image
                var currentVideoFrame = rtpModel.GetImage(ref videoFrame);

                //break out of loop if video is over
                if (currentVideoFrame == null)
                {
                    view.DisableButton(View.Buttons.Pause);
                    break;
                }

                //store the video header
                var videoFrameHeader = new byte[12];
                Buffer.BlockCopy(videoFrame, 0, videoFrameHeader, 0, videoFrameHeader.Length);

                //if packet report is checked, display packet report
                if (view.IsPacketReportChecked)
                {
                    //get sequence number
                    var sequenceNum = new byte[2];
                    Buffer.BlockCopy(videoFrameHeader, 2, sequenceNum, 0, sequenceNum.Length);
                    Array.Reverse(sequenceNum);
                    BitArray sequenceNumBits = new BitArray(sequenceNum);
                    int seqNumBitsStr = GetIntFromBitArray(sequenceNumBits);

                    //get time stamp
                    var timeStamp = new byte[4];
                    Buffer.BlockCopy(videoFrameHeader, 4, timeStamp, 0, timeStamp.Length);
                    Array.Reverse(timeStamp);
                    var timeStampBits = new BitArray(timeStamp);
                    var timeStampBitsStr = GetIntFromBitArray(timeStampBits);

                    //get payload type
                    var type = new byte[1];
                    Buffer.BlockCopy(videoFrameHeader, 1, type, 0, type.Length);
                    var typeBits = new BitArray(type);
                    typeBits.Set(7, false);
                    var timeBitsStr = GetIntFromBitArray(typeBits);

                    this.UpdateClientBox(Environment.NewLine + "Got RTP packet with SeqNum #" + seqNumBitsStr
                        + ", Timestamp: " + timeStampBitsStr + " of type " + timeBitsStr + Environment.NewLine);
                }

                //display the image
                view.SetImageBox(currentVideoFrame);
            }

        }

        //connect with server using RTSP
        public void ListenForServer()
        {
            //Create a model to listen for server
            rtspModel = new RtspModel(int.Parse(view.ServerPort), this.ServerIP, ClientPort);

            UpdateClientBox("Client is waiting for server!" + Environment.NewLine);

            //blocks until the client has connected to the server
            rtspModel.ConnectWithServer();

            UpdateClientBox("Client connected to server!" + Environment.NewLine);
        }

        //get the client/server's IP
        public IPAddress ServerIP => view.ServerIP;

        //get the client/server's port number
        public string ServerPort => view.ServerPort;
        public string ViewClientPort => view.ClientPort;

        //get the video name
        public string VideoName => view.VideoName;

        //update the server box
        public void UpdateServerBox(string msg)
        {
            view.SetServerBox(msg);
        }

        //update the client box
        public void UpdateClientBox(string msg)
        {
            view.SetClientBox(msg);
        }

        //convert bit array to int
        public int GetIntFromBitArray(BitArray bitArray)
        {
            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }

        public void UpdateVideosList(string[] videos) => view.UpdateVideoNamesCmb(videos);
    }
}
