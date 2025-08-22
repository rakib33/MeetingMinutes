using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Infrastructure.Interfaces
{
    public interface IMeetingDetailsRepository
    {
        Task<bool> SaveMeetingDetailsAsync(DataTable meetingDetailsDataTable);      
    }
}
