using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Domain.Entities
{
    public class MeetingMinutesMaster
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? MeetingDateTime { get; set; }

        [StringLength(250)]
        public string MeetingPlace { get; set; }
       
        [StringLength(500)]
        public string AttendClientSide { get; set; }

        [StringLength(500)]
        public string AttendHostSide { get; set; }

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
