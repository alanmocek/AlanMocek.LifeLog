using AlanMocek.LifeLog.Application.ActivityRecords.ViewModels;
using AlanMocek.LifeLog.Core.ActivityRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Services
{
    public class ActivityRecordForDayRecordPanelMapper
    {
        public ActivityRecordForDayRecordPanel Map(IActivityRecordWithActivity activityRecordWithActivity)
        {
            var activityRecordForDayRecordPanelActivity =
                new ActivityRecordForDayRecordPanelActivity(activityRecordWithActivity.Activity.Id, activityRecordWithActivity.Activity.Name);

            return activityRecordWithActivity.Activity.Type switch
            {
                "activity_time" => new TimeActivityRecordForDayRecordPanel(activityRecordWithActivity.Id, activityRecordWithActivity.DayRecordId,
                activityRecordForDayRecordPanelActivity, (activityRecordWithActivity as TimeActivityRecord).Value.Time),

                "activity_clock" => new ClockActivityRecordForDayRecordPanel(activityRecordWithActivity.Id, activityRecordWithActivity.DayRecordId,
                activityRecordForDayRecordPanelActivity, (activityRecordWithActivity as ClockActivityRecord).Value.Hour,
                (activityRecordWithActivity as ClockActivityRecord).Value.Minute),

                "activity_quantity" => new QuantityActivityRecordForDayRecordPanel(activityRecordWithActivity.Id, activityRecordWithActivity.DayRecordId,
                activityRecordForDayRecordPanelActivity, (activityRecordWithActivity as QuantityActivityRecord).Value.Quantity),

                "activity_occurrence" => new OccurredActivityRecordForDayRecordPanel(activityRecordWithActivity.Id, activityRecordWithActivity.DayRecordId,
                activityRecordForDayRecordPanelActivity),

                _ => throw new ArgumentException($"Maping {typeof(ActivityRecord)} of type {activityRecordWithActivity.Activity.Type} to {nameof(ActivityRecordForDayRecordPanel)} is not implemented.")
            };
        }
    }
}
