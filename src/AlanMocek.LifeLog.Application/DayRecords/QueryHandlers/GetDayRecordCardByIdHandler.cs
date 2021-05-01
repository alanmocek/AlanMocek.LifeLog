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
    public class GetDayRecordCardByIdHandler : IQueryHandler<GetDayRecordCardById, DayRecordCardViewModel>
    {
        private readonly IDayRecordsRepository _dayRecordsRepository;


        public GetDayRecordCardByIdHandler(
            IDayRecordsRepository dayRecordsRepository)
        {
            _dayRecordsRepository = dayRecordsRepository ?? throw new ArgumentNullException(nameof(dayRecordsRepository));
        }


        public async Task<DayRecordCardViewModel> HandleAndGetResultAsync(GetDayRecordCardById query)
        {
            var dayRecord = await _dayRecordsRepository.GetByIdAsync(query.Id);
            
            var dayRecordCard = new DayRecordCardViewModel(dayRecord.Id, dayRecord.Date);

            return dayRecordCard;
        }
    }
}
