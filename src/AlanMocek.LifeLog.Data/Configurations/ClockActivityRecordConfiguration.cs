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
    public class ClockActivityRecordConfiguration : IEntityTypeConfiguration<ClockActivityRecord>
    {
        public void Configure(EntityTypeBuilder<ClockActivityRecord> builder)
        {
            builder.OwnsOne(activityRecord => activityRecord.Value, ownsBuilder =>
            {
                ownsBuilder.Property(value => value.Hour)
                .IsRequired(true);

                ownsBuilder.Property(value => value.Minute)
                .IsRequired(true);
            });
        }
    }
}
