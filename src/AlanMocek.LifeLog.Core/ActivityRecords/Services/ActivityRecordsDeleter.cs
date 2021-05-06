using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords.Services
{
    public class ActivityRecordsDeleter
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;


        public ActivityRecordsDeleter(
            IActivityRecordsRepository activityRecordsRepository)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
        }


        public async Task DeleteAsync(ActivityRecord activityRecord)
        {
            var allActivityRecordsInDayRecord = await _activityRecordsRepository.BrowseAsync(new BrowseQuery(activityRecord.DayRecordId));

            var allActivityRecordsWithGreaterOrder = allActivityRecordsInDayRecord.Where(activityRecordFromDayRecord => activityRecordFromDayRecord.Order > activityRecord.Order).ToList();

            allActivityRecordsWithGreaterOrder.ForEach(activityRecordWithGreaterOrder => activityRecordWithGreaterOrder.SetNewOrder(activityRecordWithGreaterOrder.Order.Smaller()));

            _activityRecordsRepository.Remove(activityRecord);
        }
    }
}
