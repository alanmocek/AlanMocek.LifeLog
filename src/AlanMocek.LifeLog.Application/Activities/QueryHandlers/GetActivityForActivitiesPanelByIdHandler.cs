using AlanMocek.LifeLog.Application.Activities.DTOs;
using AlanMocek.LifeLog.Application.Activities.Queries;
using AlanMocek.LifeLog.Application.Activities.Services;
using AlanMocek.LifeLog.Core.Activities.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.QueryHandlers
{
    public class GetActivityForActivitiesPanelByIdHandler : IQueryHandler<GetActivityForActivitiesPanelById, ActivityForActivitiesPanel>
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly ActivityForActivitiesPanelMapper _activityForActivitiesPanelMapper;


        public GetActivityForActivitiesPanelByIdHandler(
            IActivitiesRepository activitiesRepository,
            ActivityForActivitiesPanelMapper activityForActivitiesPanelMapper)
        {
            _activitiesRepository = activitiesRepository ?? throw new ArgumentNullException(nameof(activitiesRepository));
            _activityForActivitiesPanelMapper = activityForActivitiesPanelMapper ?? throw new ArgumentNullException(nameof(activityForActivitiesPanelMapper));
        }


        public async Task<ActivityForActivitiesPanel> HandleAndGetResultAsync(GetActivityForActivitiesPanelById query)
        {
            var activity = await _activitiesRepository.GetByIdAsync(query.Id);

            var activityForActivitiesPanel = _activityForActivitiesPanelMapper.Map(activity);

            return activityForActivitiesPanel;
        }
    }
}
