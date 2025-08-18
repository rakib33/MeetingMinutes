using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Domain.Entities
{
    public class MeetingMinutesMaster
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string CustomerName { get; set; }
        public DateTime? MeetingDateTime { get; set; }

        [StringLength(250)]
        public string MeetingPlace { get; set; }
       
        [StringLength(500)]
        public string AttendsFromClientSide { get; set; }

        [StringLength(500)]
        public string AttendsFromHostSide { get; set; }

        [StringLength(500)]
        public string MeetingAgenda { get; set; }   
        
        [StringLength(500)]
        public string MeetingDiscussion { get; set; }
       
        [StringLength(500)]
        public string MeetingDecision { get; set; }

        public int? CorporateCustomerId { get; set; }
        public CorporateCustomer CorporateCustomer { get; set; }

        public int? IndividualCustomerId { get; set; }
        public IndividualCustomer IndividualCustomer { get; set; }

    }
}
