using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace StreamPlayer.RTP
{
    public class RtpModel
    {
        private UdpClient udpSocket; //UDP socket to receive video packets from server
        private IPEndPoint serverEndPoint;
        private RtpPacket rtpPacket;

        public RtpModel(IPAddress serverIP, string serverPort, int clientPort)
        {
            //create client end point
            this.serverEndPoint = new IPEndPoint(serverIP, Int32.Parse(serverPort));
            //use to packetize the packet
            this.rtpPacket = new RtpPacket();
            this.udpSocket = new UdpClient(clientPort);
        }

        //convert the video frame into an image
        public Image GetImage(ref byte[] videoFrame)
        {
            try
            {
                //get video frame from server (has header)
                var packetizedVideoFrame = udpSocket.Receive(ref serverEndPoint);

                //make sure video frame received is not empty (ie. end of file)
                if (packetizedVideoFrame.Length > 0)
                {
                    videoFrame = packetizedVideoFrame;

                    //unpacketize (remove header) from the video packet
                    var unpacketizedVideoFrame = rtpPacket.unpacketizeVideoFrame(packetizedVideoFrame);

                    //convert the video frame into an image
                    var image = Image.FromStream(new MemoryStream(unpacketizedVideoFrame));

                    return image;
                }
                else
                    return null;
            }
            catch (SocketException err)
            {
                Console.WriteLine("Receive failed: ", err.Message);
                return null;
            }
        }
    }
}
