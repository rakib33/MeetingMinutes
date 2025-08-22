using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Domain.Entities
{
    public class MeetingMinutesDetails
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int MeetingMinutesMasterId { get; set; }        
        public decimal Quantity { get; set; }
        
        public decimal Unit { get; set; }

        // Navigation property to link to MeetingMinutesMaster
        public MeetingMinutesMaster MeetingMinutesMaster { get; set; }
        // Navigation property to link to Product
        public Product Product { get; set; }
    }
}
