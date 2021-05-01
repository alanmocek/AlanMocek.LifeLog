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
        //Task<IEnumerable<IActivityRecordWithActivity>> GetAllWithActivityForDayRecordWithIdAsync(Guid dayRecordId);
    }
}
