using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Core.DayRecords.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.QueryHandlers
{
    public class GetDayRecordCardsByYearAndMonthHandler : IQueryHandler<GetDayRecordCardsByYearAndMonth, IEnumerable<DayRecordCardViewModel>>
    {
        private readonly IDayRecordsRepository _dayRecordsRepository;


        public GetDayRecordCardsByYearAndMonthHandler(
            IDayRecordsRepository dayRecordsRepository)
        {
            _dayRecordsRepository = dayRecordsRepository;
        }


        public async Task<IEnumerable<DayRecordCardViewModel>> HandleAndGetResultAsync(GetDayRecordCardsByYearAndMonth query)
        {
            var dayRecords = await _dayRecordsRepository.GetBrowsedByYearAndMonthAsync(query.Year, query.Month);

            var dayRecordCardViewModels = dayRecords.Select(dayRecord => new DayRecordCardViewModel(dayRecord.Id, dayRecord.Date));

            return dayRecordCardViewModels;
        }
    }
}
