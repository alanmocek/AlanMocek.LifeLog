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
        Task<IEnumerable<DayRecord>> BrowseAsync(BrowseQuery query);
    }


    public record BrowseQuery
    {
        public int? Year { get; init; }
        public int? Month { get; init; }


        public BrowseQuery(int? year, int? month)
        {
            Year = year;
            Month = month;
        }
    }
}
