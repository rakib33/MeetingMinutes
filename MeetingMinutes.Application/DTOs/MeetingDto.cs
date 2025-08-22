using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Application.DTOs
{
    public class MeetingDto
    {
        public int CustomerId { get; set; }
        public string CustomerType { get; set; }
        public string MeetingDate { get; set; }
        public string MeetingTime { get; set; } // Can be parsed to TimeSpan if needed
        public string MeetingAgenda { get; set; }
        public string MeetingDiscussion { get; set; }
        public string AttendClientSide { get; set; }
        public string AttendHostSide { get; set; }
        public string MeetingPlace { get; set; }
        public string MeetingDecision { get; set; }

    }
}
