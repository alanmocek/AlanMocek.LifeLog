using AlanMocek.LifeLog.Core.DayRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords.Services
{
    public class ActivityRecordOrderChanger
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;


        public ActivityRecordOrderChanger(
            IActivityRecordsRepository activityRecordsRepository)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
        }


        public async Task ChangeOrderAsync(Guid activityRecordId, ActivityRecordOrder newOrder)
        {
            var activityRecord = await _activityRecordsRepository.GetByIdAsync(activityRecordId);

            var oldOrder = activityRecord.Order;

            // VS bug?
            if(oldOrder == newOrder)
            {
                return;
            }

            var allDayRecordActivityRecords = await _activityRecordsRepository.BrowseAsync(new BrowseQuery(activityRecord.DayRecordId));

            List<ActivityRecord> activityRecordsToChange = new List<ActivityRecord>();

            if(newOrder < oldOrder)
            {
                activityRecordsToChange = allDayRecordActivityRecords.Where(dayRecord => dayRecord.Order >= newOrder 
                && dayRecord.Order < oldOrder).ToList();
                
                activityRecordsToChange.ForEach(activityRecord => activityRecord.SetNewOrder(activityRecord.Order.Greater()));
            }

            if (newOrder > oldOrder)
            {
                var maxOrder = allDayRecordActivityRecords.Max(activityRecord => activityRecord.Order);

                if (oldOrder == maxOrder)
                {
                    return;
                }

                activityRecordsToChange = allDayRecordActivityRecords.Where(dayRecord => dayRecord.Order > oldOrder 
                && dayRecord.Order <= newOrder).ToList();

                activityRecordsToChange.ForEach(activityRecord => activityRecord.SetNewOrder(activityRecord.Order.Smaller()));
            }

            activityRecord.SetNewOrder(newOrder);
        }
    }
}
