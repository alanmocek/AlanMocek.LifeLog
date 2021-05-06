using AlanMocek.LifeLog.Application.DayRecords.DTOs;
using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Core.DayRecords.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.QueryHandlers
{
    public class BrowseDayRecordsForCalendarPanelHandler : IQueryHandler<BrowseDayRecordsForCalendarPanel,
        IEnumerable<DayRecordForCalendarPanel>>
    {
        private readonly IDayRecordsRepository _dayRecordsRepository;


        public BrowseDayRecordsForCalendarPanelHandler(
            IDayRecordsRepository dayRecordsRepository)
        {
            _dayRecordsRepository = dayRecordsRepository ?? throw new ArgumentNullException(nameof(dayRecordsRepository));
        }


        public async Task<IEnumerable<DayRecordForCalendarPanel>> HandleAndGetResultAsync(BrowseDayRecordsForCalendarPanel query)
        {
            var dayRecords = await _dayRecordsRepository.BrowseAsync(new BrowseQuery(query.Year, query.Month));

            var dayRecordsForCalendarPanel = dayRecords.Select(dayRecord => new DayRecordForCalendarPanel(dayRecord.Id, dayRecord.Date));

            return dayRecordsForCalendarPanel;
        }
    }
}
