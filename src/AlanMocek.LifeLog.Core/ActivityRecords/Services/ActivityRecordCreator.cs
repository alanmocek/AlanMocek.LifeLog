using AlanMocek.LifeLog.Core.Activities;
using AlanMocek.LifeLog.Core.Activities.Services;
using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords.Services
{
    public class ActivityRecordCreator
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;


        public ActivityRecordCreator(
            IActivityRecordsRepository activityRecordsRepository)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
        }


        public async Task<ActivityRecord> CreateAsync(Guid id, Activity activity, Guid dayRecordId, ActivityRecordValue value)
        {
            var nextOrder = await GetNextOrderAsync(dayRecordId);

            return activity.Type switch
            { 
                ActivitiesTypes.OccurrenceActivity => new OccurrenceActivityRecord(id, activity, dayRecordId, nextOrder),
                ActivitiesTypes.QuantityActivity => new QuantityActivityRecord(id, activity, dayRecordId, nextOrder, value as QuantityValue),
                ActivitiesTypes.TimeActivity => new TimeActivityRecord(id, activity, dayRecordId, nextOrder, value as TimeValue),
                ActivitiesTypes.ClockActivity => new ClockActivityRecord(id, activity, dayRecordId, nextOrder, value as ClockValue),
                _ => throw new NotImplementedException($"Creating {nameof(ActivityRecord)} for activity of type {activity.Type} is not implemented.")
            };
        }


        private async Task<ActivityRecordOrder> GetNextOrderAsync(Guid dayRecordId)
        {
            var activityRecordCountInDayRecord = await _activityRecordsRepository.GetCountForDayRecordWithIdAsync(dayRecordId);

            var activityRecordOrder = new ActivityRecordOrder(activityRecordCountInDayRecord + 1);

            return activityRecordOrder;
        }
    }
}
