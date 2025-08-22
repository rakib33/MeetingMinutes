using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Application.DTOs
{
    public class MeetingDetailsDto
    {
       // public int Id { get; set; }

        public int? ProductId { get; set; }
        public int? MeetingMinutesMasterId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Unit { get; set; }
    }
}
