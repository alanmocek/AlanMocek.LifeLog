using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Core.Activities;
using AlanMocek.LifeLog.Core.ActivityRecords;
using System;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Services
{
    public class ActivityRecordWithActivityToActivityRecordForDayRecordPanelMapper
    {
        public ActivityRecordForDayRecordPanel Map(IActivityRecordWithActivity activityRecordWithActivity)
        {
            var activityRecordForDayRecordPanelActivity =
                new ActivityRecordForDayRecordPanelActivity(activityRecordWithActivity.Activity.Id, activityRecordWithActivity.Activity.Name, activityRecordWithActivity.Activity.Type);

            return activityRecordWithActivity.Activity.Type switch
            {
                ActivitiesTypes.TimeActivity => new TimeActivityRecordForDayRecordPanel(activityRecordWithActivity.Id, activityRecordWithActivity.DayRecordId, activityRecordWithActivity.Order.Order,
                activityRecordForDayRecordPanelActivity, (activityRecordWithActivity as TimeActivityRecord).Value.Hours, (activityRecordWithActivity as TimeActivityRecord).Value.Minutes,
                (activityRecordWithActivity as TimeActivityRecord).Value.Seconds),

                ActivitiesTypes.ClockActivity => new ClockActivityRecordForDayRecordPanel(activityRecordWithActivity.Id, activityRecordWithActivity.DayRecordId, activityRecordWithActivity.Order.Order,
                activityRecordForDayRecordPanelActivity, (activityRecordWithActivity as ClockActivityRecord).Value.Hour,
                (activityRecordWithActivity as ClockActivityRecord).Value.Minute),

                ActivitiesTypes.QuantityActivity => new QuantityActivityRecordForDayRecordPanel(activityRecordWithActivity.Id, activityRecordWithActivity.DayRecordId, activityRecordWithActivity.Order.Order,
                activityRecordForDayRecordPanelActivity, (activityRecordWithActivity as QuantityActivityRecord).Value.Quantity),

                ActivitiesTypes.OccurrenceActivity => new OccurrenceActivityRecordForDayRecordPanel(activityRecordWithActivity.Id, activityRecordWithActivity.DayRecordId, activityRecordWithActivity.Order.Order,
                activityRecordForDayRecordPanelActivity),

                _ => throw new NotImplementedException($"Maping {typeof(ActivityRecord)} of type {activityRecordWithActivity.Activity.Type} to {nameof(ActivityRecordForDayRecordPanel)} is not implemented.")
            };
        }
    }
}
