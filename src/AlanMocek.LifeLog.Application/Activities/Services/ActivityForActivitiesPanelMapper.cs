using AlanMocek.LifeLog.Application.Activities.DTOs;
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
                ActivitiesTypes.TimeActivity => new TimeActivityForActivitiesPanel(activity.Id, activity.Name, activity.Type, activity.HasValue),

                ActivitiesTypes.ClockActivity => new ClockActivityForActivitiesPanel(activity.Id, activity.Name, activity.Type, activity.HasValue),

                ActivitiesTypes.QuantityActivity => new QuantityActivityForActivitiesPanel(activity.Id, activity.Name, activity.Type, activity.HasValue),

                ActivitiesTypes.OccurrenceActivity => new OccurrenceActivityForActivitiesPanel(activity.Id, activity.Name, activity.Type, activity.HasValue),

                _ => throw new NotImplementedException($"Maping {typeof(Activity)} of type {activity.Type} to {nameof(ActivityForActivitiesPanel)} is not implemented.")
            };
        }
    }
}
