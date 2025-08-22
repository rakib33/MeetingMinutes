using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Configurations
{
    public class IndividualCustomerConfig : IEntityTypeConfiguration<IndividualCustomer>
    {
        public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
        {
            builder.ToTable("Individual_Customer_Tbl");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.HasIndex(c => c.Id);
            builder.HasIndex(c => c.Name);
        }
    }
}
