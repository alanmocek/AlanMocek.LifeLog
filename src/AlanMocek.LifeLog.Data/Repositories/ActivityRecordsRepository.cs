using AlanMocek.LifeLog.Core.ActivityRecords;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Data.Repositories
{
    public class ActivityRecordsRepository : IActivityRecordsRepository
    {
        private readonly LifeLogContext _lifeLogContext;


        public ActivityRecordsRepository(LifeLogContext lifeLogContext)
        {
            _lifeLogContext = lifeLogContext;
        }


        public void Add(ActivityRecord activityRecord)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActivityRecord>> GetAllForDayRecordWithIdAsync(Guid dayRecordId)
        {
            throw new NotImplementedException();
        }

        //public Task<IEnumerable<IActivityRecordWithActivity>> GetAllWithActivityForDayRecordWithIdAsync(Guid dayRecordId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
