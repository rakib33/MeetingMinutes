using AutoMapper;
using MeetingMinutes.Application.DTOs;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Application.Services
{
    public class MeetingMasterService : IMeetingMasterService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;
        public MeetingMasterService(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }
        public async Task<int> SaveMeetingMasterAsync(MeetingDto meetingDto)
        {
            //Parse the date and time(if you need them combined)
            DateTime meetingDateTime;
            if (DateTime.TryParse($"{meetingDto.MeetingDate} {meetingDto.MeetingTime}",
                out meetingDateTime))
            {
                MeetingMinutesMaster model = _mapper.Map<MeetingMinutesMaster>(meetingDto);
                model.MeetingDateTime = meetingDateTime;
                //Corporate,Individual

                if (meetingDto.CustomerType == "Corporate")
                {
                    model.CorporateCustomerId = meetingDto.CustomerId;
                }
                else if (meetingDto.CustomerType == "Individual")
                {
                    model.IndividualCustomerId = meetingDto.CustomerId;
                }
               
                return await _meetingRepository.SaveMeetingWithSPAsync(model);
                // Now you have meetingDateTime with both date and time
            }

            throw new NotImplementedException();
        }
    }
}
