using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.CommandHandlers
{
    public class CreateOccurrenceActivityRecordHandler : ICommandHandler<CreateOccurrenceActivityRecord>
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;
        private readonly LifeLogContext _lifeLogContext;
        private readonly ActivityRecordCreator _activityRecordCreator;


        public CreateOccurrenceActivityRecordHandler(
            IActivityRecordsRepository activityRecordsRepository,
            LifeLogContext lifeLogContext,
            ActivityRecordCreator activityRecordCreator)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
            _lifeLogContext = lifeLogContext ?? throw new ArgumentNullException(nameof(lifeLogContext));
            _activityRecordCreator = activityRecordCreator ?? throw new ArgumentNullException(nameof(activityRecordCreator));
        }


        public async Task HandleAsync(CreateOccurrenceActivityRecord command)
        {
            var activityRecord = await _activityRecordCreator.CreateOccurrenceActivityRecordAsync(command.Id, command.ActivityId, command.DayRecordId);

            _activityRecordsRepository.Add(activityRecord);

            await _lifeLogContext.SaveChangesAsync();
        }
    }
}
