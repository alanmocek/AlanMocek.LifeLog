using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.DayRecords.Services
{
    public class DayRecordsCreator
    {
        private readonly IDayRecordsRepository _dayRecordsRepository;


        public DayRecordsCreator(
            IDayRecordsRepository dayRecordsRepository)
        {
            _dayRecordsRepository = dayRecordsRepository ?? throw new ArgumentNullException(nameof(dayRecordsRepository));
        }


        public async Task<DayRecord> CreateDayRecordForDateAsync(Guid id, DateTime date)
        {
            var isDayRecordAlreadyExsitingForDate = await _dayRecordsRepository.GetIsExistingForDateAsync(date);

            if(isDayRecordAlreadyExsitingForDate == true)
            {
                throw new CoreException("Day record already exist for that date.");
            }

            var dayRecord = new DayRecord(id, date);

            return dayRecord;
        }
    }
}
