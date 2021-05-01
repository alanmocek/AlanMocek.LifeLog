using AlanMocek.LifeLog.Application.ActivityRecords.ViewModels;
using AlanMocek.LifeLog.Core.ActivityRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Services
{
    public class ActivityRecordViewModelFactory
    {
        public ActivityRecordViewModel FactorActivityRecordViewModel(ActivityRecord activityRecord)
        {
            ActivityRecordViewModel activityRecordViewModel = null;

            if (activityRecord is ClockActivityRecord)
            {
                activityRecordViewModel = new ClockActivityRecordViewModel(activityRecord.Id, activityRecord.ActivityId, string.Empty, 
                    (activityRecord as ClockActivityRecord).Value.Hour, (activityRecord as ClockActivityRecord).Value.Minute);
            }

            if (activityRecord is TimeActivityRecord)
            {
                activityRecordViewModel = new TimeActivityRecordViewModel(activityRecord.Id, activityRecord.ActivityId, string.Empty,
                    (activityRecord as TimeActivityRecord).Value.Time);
            }

            if (activityRecord is OccurrenceActivityRecord)
            {
                activityRecordViewModel = new OccurrenceActivityRecordViewModel(activityRecord.Id, activityRecord.ActivityId, string.Empty);
            }

            if (activityRecord is QuantityActivityRecord)
            {
                activityRecordViewModel = new QuantityActivityRecordViewModel(activityRecord.Id, activityRecord.ActivityId, string.Empty,
                    (activityRecord as QuantityActivityRecord).Value.Quantity);
            }

            if (activityRecordViewModel is null)
            {
                throw new ArgumentException($"Activity Record of type '{activityRecord.GetType()}' is not supported.");
            }

            return activityRecordViewModel;
        }
    }
}
