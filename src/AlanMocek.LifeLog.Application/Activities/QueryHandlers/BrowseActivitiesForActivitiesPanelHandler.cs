using AlanMocek.LifeLog.Application.Activities.DTOs;
using AlanMocek.LifeLog.Application.Activities.Queries;
using AlanMocek.LifeLog.Application.Activities.Services;
using AlanMocek.LifeLog.Core.Activities.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.QueryHandlers
{
    public class BrowseActivitiesForActivitiesPanelHandler : IQueryHandler<BrowseActivitiesForActivitiesPanel, IEnumerable<ActivityForActivitiesPanel>>
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly ActivityForActivitiesPanelMapper _activityForActivitiesPanelMapper;


        public BrowseActivitiesForActivitiesPanelHandler(
            IActivitiesRepository activitiesRepository,
            ActivityForActivitiesPanelMapper activityForActivitiesPanelMapper)
        {
            _activitiesRepository = activitiesRepository ?? throw new ArgumentNullException(nameof(activitiesRepository));
            _activityForActivitiesPanelMapper = activityForActivitiesPanelMapper ?? throw new ArgumentNullException(nameof(activityForActivitiesPanelMapper));
        }


        public async Task<IEnumerable<ActivityForActivitiesPanel>> HandleAndGetResultAsync(BrowseActivitiesForActivitiesPanel query)
        {
            var activities = await _activitiesRepository.BrowseAsync(new BrowseQuery());

            var activitiesForActivitiesPanel = activities.Select(activity => _activityForActivitiesPanelMapper.Map(activity));

            return activitiesForActivitiesPanel;
        }
    }
}
