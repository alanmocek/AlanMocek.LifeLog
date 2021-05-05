using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.CommandHandlers
{
    public class CreateQuantityActivityRecordHandler : ICommandHandler<CreateQuantityActivityRecord>
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;
        private readonly LifeLogContext _lifeLogContext;
        private readonly ActivityRecordCreator _activityRecordCreator;


        public CreateQuantityActivityRecordHandler(
            IActivityRecordsRepository activityRecordsRepository,
            LifeLogContext lifeLogContext,
            ActivityRecordCreator activityRecordCreator)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
            _lifeLogContext = lifeLogContext ?? throw new ArgumentNullException(nameof(lifeLogContext));
            _activityRecordCreator = activityRecordCreator ?? throw new ArgumentNullException(nameof(activityRecordCreator));
        }


        public async Task HandleAsync(CreateQuantityActivityRecord command)
        {
            var quantity = new QuantityValue(command.Quantity);
            var activityRecord = await _activityRecordCreator.CreateQuantityActivityRecordAsync(command.Id, command.ActivityId, command.DayRecordId, quantity);

            _activityRecordsRepository.Add(activityRecord);

            await _lifeLogContext.SaveChangesAsync();
        }
    }
}
