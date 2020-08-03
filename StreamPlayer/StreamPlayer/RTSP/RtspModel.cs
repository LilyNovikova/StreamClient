using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StreamPlayer.RTSP
{
    public class RtspModel
    {
        private IPEndPoint listenEndPoint;
        public int ServerPort { get; set; }
        public IPAddress ServerIP { get; set; }
        public int ClientPort { get; set; }
        public Socket tcpClient { get; set; } = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);


        //byte array to store request and response messages between client and server
        public byte[] receiveBuffer = new byte[4096];

        public int CSeqNum;

        public RtspModel(int serverPort, IPAddress serverIP, int clientPort)
        {
            this.ServerPort = serverPort;
            this.ServerIP = serverIP;
            this.CSeqNum = 1;
            this.ClientPort = clientPort;

            listenEndPoint = new IPEndPoint(ServerIP, ServerPort);
        }

        //connect client with the server
        public void ConnectWithServer()
        {
            try
            {
                //Connect the client to the server at the server's end point
                tcpClient.Connect(listenEndPoint);
            }
            catch
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
            }
        }


        //client send message to server
        public void Send(RtspRequest request)
        {
            try
            {
                var message = $"{request.RequestType} rtsp://{ServerIP}:{ServerPort}/";
                if (request.RequestType != RtspRequest.RtspRequestType.DESCRIBE)
                {
                    message += request.FileName;
                }
                message += $" RTSP/1.0\r\nCSeq: {CSeqNum}\r\n";
                if (request.RequestType == RtspRequest.RtspRequestType.SETUP)
                {
                    message += $"Transport: RTP/UDP; client_port= {ClientPort}";
                }
                else if (request.RequestType != RtspRequest.RtspRequestType.DESCRIBE)
                {
                    message += $"Session: {request.SessionID}";
                }
                receiveBuffer = new byte[4096];
                receiveBuffer = Encoding.UTF8.GetBytes(message);
                //increment sequence number
                this.CSeqNum++;

                //send the request to the server
                tcpClient.Send(receiveBuffer);
            }
            catch (SocketException err)
            {
                Console.WriteLine("Error occurred on accepted socket:" + err.Message + Environment.NewLine + Environment.NewLine);
            }
        }

        //client wait for server's reply
        public RtspResponse Listen()
        {
            try
            {
                receiveBuffer = new byte[4096];
                var rc = tcpClient.Receive(receiveBuffer);
                if (rc == 0)
                {
                    tcpClient.Close();
                    return new RtspResponse("Error");
                }
                var respStr = Encoding.Default.GetString(receiveBuffer) + Environment.NewLine + Environment.NewLine;
                return new RtspResponse(respStr);
            }
            catch (SocketException err)
            {
                return new RtspResponse("Error occurred on accepted socket:" + err.Message + Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
