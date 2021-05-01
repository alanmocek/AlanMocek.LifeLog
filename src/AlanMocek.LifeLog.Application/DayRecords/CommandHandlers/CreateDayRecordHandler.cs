using AlanMocek.LifeLog.Application.DayRecords.Commands;
using AlanMocek.LifeLog.Core.DayRecords.Services;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.CommandHandlers
{
    public class CreateDayRecordHandler : ICommandHandler<CreateDayRecord>
    {
        private readonly DayRecordsCreator _dayRecordsCreator;
        private readonly IDayRecordsRepository _dayRecordsRepository;
        private readonly LifeLogContext _lifeLogContext;


        public CreateDayRecordHandler(
            DayRecordsCreator dayRecordsCreator,
            IDayRecordsRepository dayRecordsRepository,
            LifeLogContext lifeLogContext)
        {
            _dayRecordsCreator = dayRecordsCreator ?? throw new ArgumentNullException(nameof(dayRecordsCreator));
            _dayRecordsRepository = dayRecordsRepository ?? throw new ArgumentNullException(nameof(dayRecordsRepository));
            _lifeLogContext = lifeLogContext ?? throw new ArgumentNullException(nameof(_lifeLogContext));
        }


        public async Task HandleAsync(CreateDayRecord command)
        {
            var dayRecord = await _dayRecordsCreator.CreateDayRecordForDateAsync(command.Id, command.Date);

            _dayRecordsRepository.Add(dayRecord);

            await _lifeLogContext.SaveChangesAsync();
        }
    }
}
