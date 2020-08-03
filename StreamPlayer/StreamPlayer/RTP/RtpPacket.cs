using System;

namespace StreamPlayer.RTP
{
    public class RtpPacket
    {
        public RtpPacket() { }

        public byte[] unpacketizeVideoFrame(byte[] packetizedVideoFrame)
        {

            //empty byte array to store the video packet (without header)
            var unpacketizedVideoFrame = new byte[packetizedVideoFrame.Length - 12];

            //add video frame after the header
            Buffer.BlockCopy(packetizedVideoFrame, 12, unpacketizedVideoFrame, 0, unpacketizedVideoFrame.Length);

            return unpacketizedVideoFrame;
        }
    }
}
