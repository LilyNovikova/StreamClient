namespace StreamPlayer.RTSP
{
    public class RtspRequest
    {
        public enum RtspRequestType
        {
            SETUP,
            PLAY,
            PAUSE,
            TEARDOWN,
            DESCRIBE
        }

        public RtspRequestType RequestType { get; set; }
        public string FileName { get; set; }
        public string SessionID { get; set; } = string.Empty;
    }
}
