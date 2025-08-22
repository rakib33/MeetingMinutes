using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Infrastructure.Configurations
{
    public class MeetingMinutesMasterConfig : IEntityTypeConfiguration<MeetingMinutesMaster>
    {
        public void Configure(EntityTypeBuilder<MeetingMinutesMaster> builder)
        {
            builder.ToTable("Meeting_Minutes_Master_Tbl");
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Id);

        }
    }
}
