using AlanMocek.LifeLog.Application.Activities.Queries;
using AlanMocek.LifeLog.Application.Activities.Services;
using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Core.Activities.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.QueryHandlers
{
    public class GetAllActivitiesHandler : IQueryHandler<GetAllActivities, IEnumerable<ActivityViewModel>>
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly ActivityViewModelsFactory _activityViewModelsFactory;


        public GetAllActivitiesHandler(
            IActivitiesRepository activitiesRepository,
            ActivityViewModelsFactory activityViewModelsFactory)
        {
            _activitiesRepository = activitiesRepository;
            _activityViewModelsFactory = activityViewModelsFactory;
        }


        public async Task<IEnumerable<ActivityViewModel>> HandleAndGetResultAsync(GetAllActivities query)
        {
            var activities = await _activitiesRepository.GetAllAsync();

            var activityViewModels = activities.Select(activity => _activityViewModelsFactory.FactorActivityViewModel(activity));

            return activityViewModels;
        }
    }
}
