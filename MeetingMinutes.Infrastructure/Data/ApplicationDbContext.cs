using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;


namespace MeetingMinutes.Infrastructure.Data
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
            modelBuilder.ApplyConfiguration(new CorporateCustomerConfig());
            modelBuilder.ApplyConfiguration(new IndividualCustomerConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new MeetingMinutesMasterConfig());
            modelBuilder.ApplyConfiguration(new MeetingMinutesDetailsConfig());
            // Additional model configurations can go here
        }
    }
}
