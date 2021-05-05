using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Core.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.Services
{
    public class ActivityForActivitiesPanelMapper
    {
        public ActivityForActivitiesPanel Map(Activity activity)
        {
            return activity.Type switch
            {
                "activity_time" => new TimeActivityForActivitiesPanel(activity.Id, activity.Name, activity.Type, activity.HasValue),

                "activity_clock" => new ClockActivityForActivitiesPanel(activity.Id, activity.Name, activity.Type, activity.HasValue),

                "activity_quantity" => new QuantityActivityForActivitiesPanel(activity.Id, activity.Name, activity.Type, activity.HasValue),

                "activity_occurred" => new OccurredActivityForActivitiesPanel(activity.Id, activity.Name, activity.Type, activity.HasValue),

                _ => throw new ArgumentException($"Maping {typeof(Activity)} of type {activity.Type} to {nameof(ActivityForActivitiesPanel)} is not implemented.")
            };
        }
    }
}
