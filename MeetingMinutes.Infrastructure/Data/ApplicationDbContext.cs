using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DoctorBooking.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // DbSet properties for your entities
        public DbSet<CorporateCustomer> corporateCustomers  { get; set; }
        public DbSet<IndividualCustomer> individualCustomers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<MeetingMinutesMaster> meetingMinutesMasters { get; set; }
        public DbSet<MeetingMinutesDetails> MeetingMinutesDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new ClinicConfiguration());
            //modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            //modelBuilder.ApplyConfiguration(new PatientConfiguration());
            //modelBuilder.ApplyConfiguration(new ScheduleSlotConfiguration());
            //modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            // Additional model configurations can go here
        }
    }
}
