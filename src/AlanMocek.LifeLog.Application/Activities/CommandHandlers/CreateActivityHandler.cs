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
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly ActivitiesCreator _activitiesCreator;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly LifeLogContext _lifeLogContext;


        public CreateActivityHandler(
            ActivitiesCreator activitiesCreator,
            IActivitiesRepository activitiesRepository,
            LifeLogContext lifeLogContext)
        {
            _activitiesCreator = activitiesCreator;
            _activitiesRepository = activitiesRepository;
            _lifeLogContext = lifeLogContext;
        }


        public async Task HandleAsync(CreateActivity command)
        {
            var activity = await _activitiesCreator.CreateAsync(command.Id, command.Name, command.Type);

            _activitiesRepository.Add(activity);

            await _lifeLogContext.SaveChangesAsync();
        }
    }
}
