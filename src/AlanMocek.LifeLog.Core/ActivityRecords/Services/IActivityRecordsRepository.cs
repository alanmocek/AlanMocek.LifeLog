using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords.Services
{
    public interface IActivityRecordsRepository
    {
        void Add(ActivityRecord activityRecord);
        Task<IEnumerable<ActivityRecord>> GetAllForDayRecordWithIdAsync(Guid dayRecordId);
        Task<ActivityRecord> GetByIdAsync(Guid id);
        Task<int> GetCountForDayRecordWithIdAsync(Guid dayRecordId);
        Task<IActivityRecordWithActivity> GetWithActivityByIdAsync(Guid id);
        Task<IEnumerable<IActivityRecordWithActivity>> BrowseWithActivityAsync(BrowseWithActivityQuery query);
        //Task<IEnumerable<IActivityRecordWithActivity>> GetAllWithActivityForDayRecordWithIdAsync(Guid dayRecordId);
    }


    public record BrowseWithActivityQuery
    { 
        public Guid? DayRecordId { get; init; }


        public BrowseWithActivityQuery(Guid? dayRecordId)
        {
            DayRecordId = dayRecordId;
        }
    }

}
