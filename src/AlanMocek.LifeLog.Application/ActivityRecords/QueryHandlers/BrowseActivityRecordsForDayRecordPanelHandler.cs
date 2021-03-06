using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Application.ActivityRecords.Queries;
using AlanMocek.LifeLog.Application.ActivityRecords.Services;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.QueryHandlers
{
    public class BrowseActivityRecordsForDayRecordPanelHandler
        : IQueryHandler<BrowseActivityRecordsForDayRecordPanel, IEnumerable<ActivityRecordForDayRecordPanel>>
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;
        private readonly ActivityRecordWithActivityToActivityRecordForDayRecordPanelMapper _activityRecordForDayRecordPanelMapper;


        public BrowseActivityRecordsForDayRecordPanelHandler(
            IActivityRecordsRepository activityRecordsRepository,
            ActivityRecordWithActivityToActivityRecordForDayRecordPanelMapper activityRecordForDayRecordPanelMapper)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
            _activityRecordForDayRecordPanelMapper = activityRecordForDayRecordPanelMapper ?? throw new ArgumentNullException(nameof(activityRecordForDayRecordPanelMapper));
        }


        public async Task<IEnumerable<ActivityRecordForDayRecordPanel>> HandleAndGetResultAsync(BrowseActivityRecordsForDayRecordPanel query)
        {
            var activityRecordsWithActivity = await _activityRecordsRepository.BrowseWithActivityAsync(
                new BrowseWithActivityQuery(query.DayRecordId));

            var activityRecordsForDayRecordPanel = activityRecordsWithActivity.Select(activityRecordWithActivity => _activityRecordForDayRecordPanelMapper.Map(activityRecordWithActivity));

            return activityRecordsForDayRecordPanel;
        }
    }
}
