using System;

namespace slaxafor.Models
{
    public class SlackMessage
    {
        public string Channel { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}