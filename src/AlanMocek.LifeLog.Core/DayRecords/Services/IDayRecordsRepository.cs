using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.DayRecords.Services
{
    public interface IDayRecordsRepository
    {
        void Add(DayRecord dayRecord);
        Task<IEnumerable<DayRecord>> GetBrowsedByYearAndMonthAsync(int year, int month);
        Task<DayRecord> GetByIdAsync(Guid id);
        Task<bool> GetIsExistingForDateAsync(DateTime date);
    }
}
