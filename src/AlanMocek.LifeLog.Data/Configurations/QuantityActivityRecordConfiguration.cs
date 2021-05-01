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
    public class QuantityActivityRecordConfiguration : IEntityTypeConfiguration<QuantityActivityRecord>
    {
        public void Configure(EntityTypeBuilder<QuantityActivityRecord> builder)
        {
            builder.OwnsOne(activityRecord => activityRecord.Value, ownsBuilder =>
            {
                ownsBuilder.Property(value => value.Quantity)
                .IsRequired(true);
            });
        }
    }
}
