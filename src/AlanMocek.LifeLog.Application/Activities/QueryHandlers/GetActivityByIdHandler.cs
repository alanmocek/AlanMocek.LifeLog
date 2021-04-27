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
    public class GetActivityByIdHandler : IQueryHandler<GetActivityById, ActivityViewModel>
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly ActivityViewModelsFactory _activityViewModelsFactory;


        public GetActivityByIdHandler(
            IActivitiesRepository activitiesRepository,
            ActivityViewModelsFactory activityViewModelsFactory)
        {
            _activitiesRepository = activitiesRepository ?? throw new ArgumentNullException(nameof(activitiesRepository));
            _activityViewModelsFactory = activityViewModelsFactory ?? throw new ArgumentNullException(nameof(activityViewModelsFactory));
        }


        public async Task<ActivityViewModel> HandleAndGetResultAsync(GetActivityById query)
        {
            var activity = await _activitiesRepository.GetByIdAsync(query.Id);
            
            var activityViewModel = _activityViewModelsFactory.FactorActivityViewModel(activity);
            
            return activityViewModel;
        }
    }
}
