using AlanMocek.LifeLog.Application.DayRecords.DTOs;
using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Core.DayRecords.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.QueryHandlers
{
    public class GetDayRecordForCalendarPanelByIdHandler : IQueryHandler<GetDayRecordForCalendarPanelById, DayRecordForCalendarPanel>
    {
        private readonly IDayRecordsRepository _dayRecordsRepository;


        public GetDayRecordForCalendarPanelByIdHandler(
            IDayRecordsRepository dayRecordsRepository)
        {
            _dayRecordsRepository = dayRecordsRepository ?? throw new ArgumentNullException(nameof(dayRecordsRepository));
        }


        public async Task<DayRecordForCalendarPanel> HandleAndGetResultAsync(GetDayRecordForCalendarPanelById query)
        {
            var dayRecord = await _dayRecordsRepository.GetByIdAsync(query.Id);

            var dayRecordForCalendarPanel = new DayRecordForCalendarPanel(dayRecord.Id, dayRecord.Date);

            return dayRecordForCalendarPanel;

        }
    }
}
