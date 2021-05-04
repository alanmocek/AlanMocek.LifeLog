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


        public async Task<TimeActivityRecord> CreateTimeActivityRecordAsync(Guid id, Guid activityId,
            Guid dayRecordId, TimeValue time)
        {
            var order = await GetOrderAsync(dayRecordId);
            
            var activityRecord = new TimeActivityRecord(id, activityId, dayRecordId, order, time);

            return activityRecord;
        }

        public async Task<QuantityActivityRecord> CreateQuantityActivityRecordAsync(Guid id, Guid activityId,
            Guid dayRecordId, QuantityValue quantity)
        {
            var order = await GetOrderAsync(dayRecordId);

            var activityRecord = new QuantityActivityRecord(id, activityId, dayRecordId, order, quantity);

            return activityRecord;
        }

        public async Task<OccurrenceActivityRecord> CreateOccurrenceActivityRecordAsync(Guid id, Guid activityId,
            Guid dayRecordId)
        {
            var order = await GetOrderAsync(dayRecordId);

            var activityRecord = new OccurrenceActivityRecord(id, activityId, dayRecordId, order);

            return activityRecord;
        }

        public async Task<ClockActivityRecord> CreateClockActivityRecordAsync(Guid id, Guid activityId,
            Guid dayRecordId, ClockValue clock)
        {
            var order = await GetOrderAsync(dayRecordId);

            var activityRecord = new ClockActivityRecord(id, activityId, dayRecordId, order, clock);

            return activityRecord;
        }


        private async Task<ActivityRecordOrder> GetOrderAsync(Guid dayRecordId)
        {
            var activityRecordCountInDayRecord = await _activityRecordsRepository.GetCountForDayRecordWithIdAsync(dayRecordId);

            var activityRecordOrder = new ActivityRecordOrder(activityRecordCountInDayRecord + 1);

            return activityRecordOrder;
        }
    }
}
