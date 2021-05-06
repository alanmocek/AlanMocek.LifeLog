using AlanMocek.LifeLog.Core.Activities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Data.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(activity => activity.Id);

            builder.Property(activity => activity.Name)
                .IsRequired(true);

            builder.Property(activity => activity.Type)
                .IsRequired(true);

            builder.Property(activity => activity.HasValue)
                .IsRequired(true);

            builder.Property(activity => activity.CreatedAtUtc)
                .IsRequired(true);

            builder.Property(activity => activity.UpdatedAtUtc)
                .IsRequired(true);
        }
    }
}
