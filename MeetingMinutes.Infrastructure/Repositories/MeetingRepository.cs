using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Data;
using MeetingMinutes.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationDbContext _db;

        public MeetingRepository(ApplicationDbContext db) => _db = db;

        public async Task<bool> SaveMeetingWithSPAsync(MeetingMinutesMaster meetingsData)
        {
            try
            {
                var parameters = new[]
               {
                new SqlParameter("@Id", meetingsData.Id),
                new SqlParameter("@MeetingDateTime",meetingsData.MeetingDateTime ?? (object)DBNull.Value),
                new SqlParameter("@MeetingPlace", meetingsData.MeetingPlace ?? (object)DBNull.Value),
                new SqlParameter("@AttendClientSide", meetingsData.AttendClientSide ?? (object)DBNull.Value),
                new SqlParameter("@AttendHostSide", meetingsData.AttendHostSide ?? (object)DBNull.Value),
                new SqlParameter("@MeetingAgenda", meetingsData.MeetingAgenda ?? (object)DBNull.Value),
                new SqlParameter("@MeetingDiscussion", meetingsData.MeetingDiscussion ?? (object)DBNull.Value),
                new SqlParameter("@MeetingDecision", meetingsData.MeetingDecision ?? (object)DBNull.Value),
                new SqlParameter("@CorporateCustomerId", meetingsData.CorporateCustomerId ?? (object)DBNull.Value),
                new SqlParameter("@IndividualCustomerId", meetingsData.IndividualCustomerId ?? (object)DBNull.Value)
            };


                await using var connection = _db.Database.GetDbConnection();
                await using var command = connection.CreateCommand();

                command.CommandText = "Meeting_Minutes_Master_Save_SP";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                //return the inserted row Id
                var result = await command.ExecuteScalarAsync();

                if (result == null && result == DBNull.Value)
                    return false;
                
               return Convert.ToInt32(result) > 0 ? true: false;
        
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error saving meeting: {ex.Message}");
                return false;
            }
        }
    }
}
