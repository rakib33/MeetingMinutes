using Microsoft.EntityFrameworkCore;


namespace MeetingMinutes.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            try
            {
                var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/StoredProcedures/MeetingMinutesMasterSave_SP.sql");
                var sql = File.ReadAllText(sqlFile);
                context.Database.ExecuteSqlRaw(sql);

                sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/StoredProcedures/MeetingMinutesDetailsSave_SP.sql");
                sql = File.ReadAllText(sqlFile);
                context.Database.ExecuteSqlRaw(sql);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
            }
        }
    }
}
