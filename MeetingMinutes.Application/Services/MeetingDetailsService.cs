using AutoMapper;
using MeetingMinutes.Application.DTOs;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Application.Services
{
    public class MeetingDetailsService : IMeetingDetailsService
    {
        private readonly IMeetingDetailsRepository _meetingDetailsRepository;      

        public MeetingDetailsService(IMeetingDetailsRepository meetingDetailsRepository, IMapper mapper)
        {
            _meetingDetailsRepository = meetingDetailsRepository;

        }
        public Task<bool> SaveMeetingDetailsAsync(List<MeetingDetailsDto> meetingDetailsDto)
        {
            return _meetingDetailsRepository.SaveMeetingDetailsAsync(CreateMeetingMinutesDataTable(meetingDetailsDto));
        }

        private DataTable CreateMeetingMinutesDataTable(List<MeetingDetailsDto> models)
        {
            var dataTable = new DataTable();

            // DECIMAL columns
            dataTable.Columns.Add("Quantity", typeof(decimal));
            dataTable.Columns.Add("Unit", typeof(decimal));

            // INT columns
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("MeetingMinutesMasterId", typeof(int));

            // Populate DataTable
            foreach (var model in models)
            {
                dataTable.Rows.Add(
                    model.Quantity ?? (object)DBNull.Value,
                    model.Unit ?? (object)DBNull.Value,
                    model.ProductId ?? (object)DBNull.Value,
                    model.MeetingMinutesMasterId ?? (object)DBNull.Value
                );
            }

            return dataTable;
        }
    }
}
