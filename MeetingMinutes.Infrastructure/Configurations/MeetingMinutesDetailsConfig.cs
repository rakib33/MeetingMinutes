using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Configurations
{
    public class MeetingMinutesDetailsConfig : IEntityTypeConfiguration<MeetingMinutesDetails>
    {
        public void Configure(EntityTypeBuilder<MeetingMinutesDetails> builder)
        {
            builder.ToTable("Meeting_Minutes_Details_Tbl");
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Id);
        }
    }
}
