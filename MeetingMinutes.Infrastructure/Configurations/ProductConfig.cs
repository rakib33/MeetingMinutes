using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products_Service_Tbl");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.HasIndex(c => c.Id);
            builder.HasIndex(c => c.Name);
        }
    }
}
