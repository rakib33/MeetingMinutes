using MeetingMinutes.Infrastructure.Data;
using MeetingMinutes.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public class MeetingDetailsRepository : IMeetingDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public MeetingDetailsRepository(ApplicationDbContext db) => _db = db;
        public async Task<bool> SaveMeetingDetailsAsync(DataTable meetingDetailsDataTable)
        {            

            var parameter = new SqlParameter
            {
                ParameterName = "@MeetingMinutesList",
                SqlDbType = SqlDbType.Structured,
                TypeName = "dbo.MeetingMinutesListType",
                Value = meetingDetailsDataTable
            };

            await using var connection = _db.Database.GetDbConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "Meeting_Minutes_Details_Save_SP";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(parameter);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            var insertedIds = new List<int>();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                if (!reader.IsDBNull(0))
                {
                    insertedIds.Add(reader.GetInt32(0));
                }
            }

            return true;
        }
    }
}
