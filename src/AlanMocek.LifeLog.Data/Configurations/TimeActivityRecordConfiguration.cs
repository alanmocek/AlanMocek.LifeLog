using AlanMocek.LifeLog.Core.ActivityRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Data.Configurations
{
    public class TimeActivityRecordConfiguration : IEntityTypeConfiguration<TimeActivityRecord>
    {
        public void Configure(EntityTypeBuilder<TimeActivityRecord> builder)
        {
            builder.OwnsOne(activityRecord => activityRecord.Value, ownsBuilder =>
            {
                ownsBuilder.Property(value => value.Hours)
                .IsRequired(true);

                ownsBuilder.Property(value => value.Minutes)
                .IsRequired(true);

                ownsBuilder.Property(value => value.Seconds)
                .IsRequired(true);
            });
        }
    }
}
