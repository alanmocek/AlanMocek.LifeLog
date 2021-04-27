using AlanMocek.LifeLog.Core.Activities;
using AlanMocek.LifeLog.Core.DayRecords;
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


        public LifeLogContext(DbContextOptions<LifeLogContext> options)
            : base(options)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(
        //        "Data Source = UserData.db");

        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasDiscriminator(activity => activity.Type)
                .HasValue<ClockActivity>("activity_clock")
                .HasValue<OccurrenceActivity>("activity_occurrence")
                .HasValue<TimeActivity>("activity_time")
                .HasValue<QuantityActivity>("activity_quantity");

            base.OnModelCreating(modelBuilder);
        }
    }
}
