using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.CommandHandlers
{
    public class DeleteActivityRecordHandler : ICommandHandler<DeleteActivityRecord>
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;
        private readonly ActivityRecordsDeleter _activityRecordsDeleter;
        private readonly LifeLogContext _lifeLogContext;


        public DeleteActivityRecordHandler(
            IActivityRecordsRepository activityRecordsRepository,
            ActivityRecordsDeleter activityRecordsDeleter,
            LifeLogContext lifeLogContext)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
            _activityRecordsDeleter = activityRecordsDeleter ?? throw new ArgumentNullException(nameof(activityRecordsDeleter));
            _lifeLogContext = lifeLogContext ?? throw new ArgumentNullException(nameof(lifeLogContext));
        }


        public async Task HandleAsync(DeleteActivityRecord command)
        {
            var activityRecord = await _activityRecordsRepository.GetByIdAsync(command.Id);

            await _activityRecordsDeleter.DeleteAsync(activityRecord);

            await _lifeLogContext.SaveChangesAsync();
        }
    }
}
