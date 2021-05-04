using AlanMocek.LifeLog.Core.ActivityRecords;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using Microsoft.EntityFrameworkCore;
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
            _lifeLogContext.Add(activityRecord);
        }

        public async Task<IEnumerable<IActivityRecordWithActivity>> BrowseWithActivityAsync(BrowseWithActivityQuery query)
        {
            IQueryable<IActivityRecordWithActivity> contextQuery = _lifeLogContext.ActivityRecords;

            contextQuery = contextQuery.Include(activityRecord => activityRecord.Activity);

            if (query.DayRecordId.HasValue)
            {
                contextQuery = contextQuery.Where(activityRecord => activityRecord.DayRecordId == query.DayRecordId.Value);
            }

            return await contextQuery.ToListAsync();
        }

        public async Task<IEnumerable<ActivityRecord>> GetAllForDayRecordWithIdAsync(Guid dayRecordId)
        {
            return await _lifeLogContext.ActivityRecords.Where(activityRecord => activityRecord.DayRecordId == dayRecordId).ToListAsync();
        }

        public async Task<ActivityRecord> GetByIdAsync(Guid id)
        {
            var activityRecord = await _lifeLogContext.ActivityRecords.FirstOrDefaultAsync(activityRecord => activityRecord.Id == id);

            if(activityRecord is null)
            {
                throw new CoreException("Activity not found.");
            }

            return activityRecord;
        }

        public async Task<int> GetCountForDayRecordWithIdAsync(Guid dayRecordId)
        {
            return await _lifeLogContext.ActivityRecords.CountAsync(activityRecord => activityRecord.DayRecordId == dayRecordId);
        }

        public async Task<IActivityRecordWithActivity> GetWithActivityByIdAsync(Guid id)
        {
            var activityRecord = await _lifeLogContext.ActivityRecords
                .Include(activityRecord => (activityRecord as IActivityRecordWithActivity).Activity)
                .FirstOrDefaultAsync(activityRecord => activityRecord.Id == id);

            if (activityRecord is null)
            {
                throw new CoreException("Activity not found.");
            }

            return activityRecord;
        }
    }
}
