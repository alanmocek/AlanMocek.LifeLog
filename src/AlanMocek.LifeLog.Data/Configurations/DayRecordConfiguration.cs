using AlanMocek.LifeLog.Core.DayRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Data.Configurations
{
    public class DayRecordConfiguration : IEntityTypeConfiguration<DayRecord>
    {
        public void Configure(EntityTypeBuilder<DayRecord> builder)
        {
            builder.HasKey(dayRecord => dayRecord.Id);

            builder.Property(dayRecord => dayRecord.Date)
                .IsRequired(true);

            builder.Property(dayRecord => dayRecord.CreatedAtUtc)
                .IsRequired(true);
        }
    }
}
