using AlanMocek.LifeLog.Application.DayRecords.DTOs;
using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Core.DayRecords.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.QueryHandlers
{
    public class GetDayRecordForDayRecordPanelByIdHandler : IQueryHandler<GetDayRecordForDayRecordPanelById, DayRecordForDayRecordPanel>
    {
        private readonly IDayRecordsRepository _dayRecordsRepository;


        public GetDayRecordForDayRecordPanelByIdHandler(
            IDayRecordsRepository dayRecordsRepository)
        {
            _dayRecordsRepository = dayRecordsRepository ?? throw new ArgumentNullException(nameof(dayRecordsRepository));
        }


        public async Task<DayRecordForDayRecordPanel> HandleAndGetResultAsync(GetDayRecordForDayRecordPanelById query)
        {
            var dayRecord = await _dayRecordsRepository.GetByIdAsync(query.Id);

            var dayRecordForDayRecordPanel = new DayRecordForDayRecordPanel(dayRecord.Id, dayRecord.Date);

            return dayRecordForDayRecordPanel;
        }
    }
}
