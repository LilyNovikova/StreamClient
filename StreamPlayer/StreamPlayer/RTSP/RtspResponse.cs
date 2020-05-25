using System;
using System.Linq;
using System.Text;

namespace StreamPlayer.RTSP
{
    public class RtspResponse
    {
        public string RtspVersion { get; set; }
        public string Status { get; set; }
        public string CSeq { get; set; }
        public string Session { get; set; }
        public string Content { get; set; }

        public RtspResponse() { }
        public RtspResponse(string response)
        {
            var resp = response.Trim()
                .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                .Where(str => str != string.Empty).ToArray();
            if (resp.Length < 7)
            {
                throw new ArgumentException($"'{response}' is not a RTSP response");
            }

            RtspVersion = resp[0];
            Status = $"{resp[1]} {resp[2]}";
            CSeq = resp[4];
            Session = resp[6];
            if (response.Contains(nameof(Content)))
            {
                Content = resp[8].Trim();
            }
        }

        public override string ToString()
        {
            var str = new StringBuilder($"{ RtspVersion} {Status}");
            str.AppendLine($" {nameof(CSeq)}: {CSeq}");
            str.AppendLine($" {nameof(Session)}: {Session}");
            if (Content != null)
            {
                str.AppendLine($" {nameof(Content)}: {Content}");
            }
            return str.ToString();
        }
    }
}
