using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Core.Activities.Services;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.CommandHandlers
{
    public class CreateOccurrenceActivityRecordHandler : ICommandHandler<CreateOccurrenceActivityRecord>
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly LifeLogContext _lifeLogContext;
        private readonly ActivityRecordCreator _activityRecordCreator;


        public CreateOccurrenceActivityRecordHandler(
            IActivityRecordsRepository activityRecordsRepository,
            IActivitiesRepository activitiesRepository,
            LifeLogContext lifeLogContext,
            ActivityRecordCreator activityRecordCreator)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
            _activitiesRepository = activitiesRepository ?? throw new ArgumentNullException(nameof(activitiesRepository));
            _lifeLogContext = lifeLogContext ?? throw new ArgumentNullException(nameof(lifeLogContext));
            _activityRecordCreator = activityRecordCreator ?? throw new ArgumentNullException(nameof(activityRecordCreator));
        }


        public async Task HandleAsync(CreateOccurrenceActivityRecord command)
        {
            var forActivity = await _activitiesRepository.GetByIdAsync(command.ActivityId);

            var activityRecord = await _activityRecordCreator.CreateAsync(command.Id, forActivity, command.DayRecordId, null);

            _activityRecordsRepository.Add(activityRecord);

            await _lifeLogContext.SaveChangesAsync();
        }
    }
}
