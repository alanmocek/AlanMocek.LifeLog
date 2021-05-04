using AlanMocek.LifeLog.Application.Activities.Queries;
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
    public class BrowseActivitiesForDayRecordPanelHandler : IQueryHandler<BrowseActivitiesForDayRecordPanel, IEnumerable<ActivityForDayRecordPanel>>
    {
        private readonly IActivitiesRepository _activitiesRepository;


        public BrowseActivitiesForDayRecordPanelHandler(
            IActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;
        }


        public async Task<IEnumerable<ActivityForDayRecordPanel>> HandleAndGetResultAsync(BrowseActivitiesForDayRecordPanel query)
        {
            var activities = await _activitiesRepository.BrowseAsync(new BrowseQuery());

            var activitiesForDayRecordPanel = activities.Select(activity => new ActivityForDayRecordPanel(activity.Id, activity.Name, activity.Type, activity.HasValue));

            return activitiesForDayRecordPanel;
        }
    }
}
