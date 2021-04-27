using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.Activities.Services
{
    public class ActivitiesFactory
    {
        internal Activity FactorActivityByType(Guid activityId, string activityName, string activityType)
        {
            Activity activity = activityType switch
            {
                "clock" => new ClockActivity(activityId, activityName),
                "occurence" => new OccurrenceActivity(activityId, activityName),
                "activity_quantity" => new QuantityActivity(activityId, activityName),
                "time" => new TimeActivity(activityId, activityName),
                _ => throw new ArgumentException($"Activity type '{activityType}' is not supported.")
            };

            return activity;
        }
    }
}
