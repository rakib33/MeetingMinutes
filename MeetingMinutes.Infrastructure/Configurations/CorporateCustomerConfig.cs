using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Configurations
{
    public class CorporateCustomerConfig : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.ToTable("Corporate_Customer_Tbl");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.HasIndex(c => c.Id);
            builder.HasIndex(c => c.Name);
        }
    }
}
