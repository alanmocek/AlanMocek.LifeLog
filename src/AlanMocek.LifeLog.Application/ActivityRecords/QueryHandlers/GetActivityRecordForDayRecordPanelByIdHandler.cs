using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Application.ActivityRecords.Queries;
using AlanMocek.LifeLog.Application.ActivityRecords.Services;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.QueryHandlers
{
    public class GetActivityRecordForDayRecordPanelByIdHandler
        : IQueryHandler<GetActivityRecordForDayRecordPanelById, ActivityRecordForDayRecordPanel>
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;
        private readonly ActivityRecordWithActivityToActivityRecordForDayRecordPanelMapper _activityRecordForDayRecordPanelMapper;


        public GetActivityRecordForDayRecordPanelByIdHandler(
            IActivityRecordsRepository activityRecordsRepository,
            ActivityRecordWithActivityToActivityRecordForDayRecordPanelMapper activityRecordForDayRecordPanelMapper)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
            _activityRecordForDayRecordPanelMapper = activityRecordForDayRecordPanelMapper ?? throw new ArgumentNullException(nameof(activityRecordForDayRecordPanelMapper));
        }


        public async Task<ActivityRecordForDayRecordPanel> HandleAndGetResultAsync(GetActivityRecordForDayRecordPanelById query)
        {
            var activityRecordWithActivity = await _activityRecordsRepository.GetWithActivityByIdAsync(query.Id);

            var activityRecordForDayRecordPanel = _activityRecordForDayRecordPanelMapper.Map(activityRecordWithActivity);

            return activityRecordForDayRecordPanel;
        }
    }
}
