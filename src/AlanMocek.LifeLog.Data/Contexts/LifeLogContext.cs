using AlanMocek.LifeLog.Core.Activities;
using AlanMocek.LifeLog.Core.ActivityRecords;
using AlanMocek.LifeLog.Core.DayRecords;
using AlanMocek.LifeLog.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Data.Contexts
{
    public class LifeLogContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<QuantityActivity> QuantityActivities { get; set; }
        public DbSet<ClockActivity> ClockActivities { get; set; }
        public DbSet<TimeActivity> TimeActivities { get; set; }
        public DbSet<OccurredActivity> OccurrenceActivities { get; set; }

        public DbSet<DayRecord> DayRecords { get; set; }

        public DbSet<ActivityRecord> ActivityRecords { get; set; }
        public DbSet<QuantityActivityRecord> QuantityActivityRecords { get; set; }
        public DbSet<ClockActivityRecord> ClockActivityRecords { get; set; }
        public DbSet<TimeActivityRecord> TimeActivityRecords { get; set; }
        public DbSet<OccurrenceActivityRecord> OccurrenceActivityRecords { get; set; }


        public LifeLogContext(DbContextOptions<LifeLogContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasDiscriminator(activity => activity.Type)
                .HasValue<ClockActivity>("activity_clock")
                .HasValue<OccurredActivity>("activity_occurred")
                .HasValue<TimeActivity>("activity_time")
                .HasValue<QuantityActivity>("activity_quantity");

            


            modelBuilder.Entity<ActivityRecord>()
                .HasDiscriminator(activityRecord => activityRecord.Type)
                .HasValue<ClockActivityRecord>("activity_record_clock")
                .HasValue<OccurrenceActivityRecord>("activity_record_occurrence")
                .HasValue<TimeActivityRecord>("activity_record_time")
                .HasValue<QuantityActivityRecord>("activity_record_quantity");


            modelBuilder.ApplyConfiguration(new ActivityRecordConfiguration());
            modelBuilder.ApplyConfiguration(new ClockActivityRecordConfiguration());
            modelBuilder.ApplyConfiguration(new TimeActivityRecordConfiguration());
            modelBuilder.ApplyConfiguration(new QuantityActivityRecordConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
