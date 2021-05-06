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
        public DbSet<OccurrenceActivity> OccurrenceActivities { get; set; }

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
                .HasValue<ClockActivity>(ActivitiesTypes.ClockActivity)
                .HasValue<OccurrenceActivity>(ActivitiesTypes.OccurrenceActivity)
                .HasValue<TimeActivity>(ActivitiesTypes.TimeActivity)
                .HasValue<QuantityActivity>(ActivitiesTypes.QuantityActivity);

            


            modelBuilder.Entity<ActivityRecord>()
                .HasDiscriminator(activityRecord => activityRecord.ActivityType)
                .HasValue<ClockActivityRecord>(ActivitiesTypes.ClockActivity)
                .HasValue<OccurrenceActivityRecord>(ActivitiesTypes.OccurrenceActivity)
                .HasValue<TimeActivityRecord>(ActivitiesTypes.TimeActivity)
                .HasValue<QuantityActivityRecord>(ActivitiesTypes.QuantityActivity);


            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new DayRecordConfiguration());

            modelBuilder.ApplyConfiguration(new ActivityRecordConfiguration());
            modelBuilder.ApplyConfiguration(new ClockActivityRecordConfiguration());
            modelBuilder.ApplyConfiguration(new TimeActivityRecordConfiguration());
            modelBuilder.ApplyConfiguration(new QuantityActivityRecordConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
