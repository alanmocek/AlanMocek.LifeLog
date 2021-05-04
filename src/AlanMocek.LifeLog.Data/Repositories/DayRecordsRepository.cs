using AlanMocek.LifeLog.Core.DayRecords;
using AlanMocek.LifeLog.Core.DayRecords.Services;
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
    public class DayRecordsRepository : IDayRecordsRepository
    {
        private readonly LifeLogContext _lifeLogContext;


        public DayRecordsRepository(
            LifeLogContext lifeLogContext)
        {
            _lifeLogContext = lifeLogContext ?? throw new ArgumentNullException(nameof(lifeLogContext));
        }


        public void Add(DayRecord dayRecord)
        {
            _lifeLogContext.DayRecords.Add(dayRecord);
        }

        public async Task<IEnumerable<DayRecord>> BrowseAsync(BrowseQuery query)
        {
            IQueryable<DayRecord> contextQuery = _lifeLogContext.DayRecords;

            if(query.Year.HasValue)
            {
                contextQuery = contextQuery.Where(dayRecord => dayRecord.Date.Year == query.Year.Value);
            }

            if (query.Month.HasValue)
            {
                contextQuery = contextQuery.Where(dayRecord => dayRecord.Date.Month == query.Month.Value);
            }

            return await contextQuery.ToListAsync();
        }

        public async Task<IEnumerable<DayRecord>> GetBrowsedByYearAndMonthAsync(int year, int month)
        {
            return await _lifeLogContext.DayRecords.Where(dayRecord => dayRecord.Date.Year == year && dayRecord.Date.Month == month).ToListAsync();
        }

        public async Task<DayRecord> GetByIdAsync(Guid id)
        {
            var dayRecord = await _lifeLogContext.DayRecords.FirstOrDefaultAsync(dayRecord => dayRecord.Id == id);
            
            if(dayRecord is null)
            {
                throw new CoreException("DayRecordNotFound");
            }
            
            return dayRecord;
        }

        public async Task<bool> GetIsExistingForDateAsync(DateTime date)
        {
            return await _lifeLogContext.DayRecords.AnyAsync(dayRecord => 
            dayRecord.Date.Year == date.Year 
            && dayRecord.Date.Month == date.Month 
            && dayRecord.Date.Day == date.Day);
        }
    }
}
