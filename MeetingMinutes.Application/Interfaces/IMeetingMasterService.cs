using MeetingMinutes.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Application.Interfaces
{
    public interface IMeetingMasterService
    {
        Task<bool> SaveMeetingMasterAsync(MeetingDto meetingDto);
    }
}
