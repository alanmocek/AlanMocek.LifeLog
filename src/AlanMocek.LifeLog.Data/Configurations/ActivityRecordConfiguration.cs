using AlanMocek.LifeLog.Core.Activities;
using AlanMocek.LifeLog.Core.ActivityRecords;
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
    public class ActivityRecordConfiguration : IEntityTypeConfiguration<ActivityRecord>
    {
        public void Configure(EntityTypeBuilder<ActivityRecord> builder)
        {
            builder.HasKey(activityRecord => activityRecord.Id);

            builder.Property(activityRecord => activityRecord.ActivityId)
                .IsRequired(true);

            builder.Property(activityRecord => activityRecord.DayRecordId)
                .IsRequired(true);

            builder.Property(activityRecord => activityRecord.Type)
                .IsRequired(true);

            builder.OwnsOne(activityRecord => activityRecord.Order, ownsBuilder =>
            {
                ownsBuilder.Property(order => order.Order)
                .IsRequired(true);
            });


            builder.HasOne<DayRecord>()
                .WithMany()
                .HasForeignKey(ActivityRecord => ActivityRecord.DayRecordId);


            builder.HasOne(activityRecord => (activityRecord as IActivityRecordWithActivity).Activity)
                .WithMany()
                .HasForeignKey(activityRecord => (activityRecord).ActivityId)
                .Metadata.DependentToPrincipal.SetField("_IActivityRecordWithActivity_Activity");
        }
    }
}
