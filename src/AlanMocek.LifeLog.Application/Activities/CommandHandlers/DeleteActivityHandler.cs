using AlanMocek.LifeLog.Application.Activities.Commands;
using AlanMocek.LifeLog.Core.Activities.Services;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.CommandHandlers
{
    public class DeleteActivityHandler : ICommandHandler<DeleteActivity>
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly LifeLogContext _lifeLogContext;


        public DeleteActivityHandler(
            IActivitiesRepository activitiesRepository,
            LifeLogContext lifeLogContext)
        {
            _activitiesRepository = activitiesRepository ?? throw new ArgumentNullException(nameof(activitiesRepository));
            _lifeLogContext = lifeLogContext ?? throw new ArgumentNullException(nameof(lifeLogContext));
        }


        public async Task HandleAsync(DeleteActivity command)
        {
            var activity = await _activitiesRepository.GetByIdAsync(command.Id);

            _activitiesRepository.Remove(activity);

            await _lifeLogContext.SaveChangesAsync();
        }
    }
}
