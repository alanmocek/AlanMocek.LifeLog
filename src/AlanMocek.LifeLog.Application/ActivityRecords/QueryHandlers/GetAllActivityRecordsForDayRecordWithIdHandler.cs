using AlanMocek.LifeLog.Application.ActivityRecords.Queries;
using AlanMocek.LifeLog.Application.ActivityRecords.ViewModels;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.QueryHandlers
{
    public class GetAllActivityRecordsForDayRecordWithIdHandler : IQueryHandler<GetAllActivityRecordsForDayRecordWithId, IEnumerable<ActivityRecordViewModel>>
    {
        private readonly IActivityRecordsRepository _activityRecordsRepository;


        public GetAllActivityRecordsForDayRecordWithIdHandler(
            IActivityRecordsRepository activityRecordsRepository)
        {
            _activityRecordsRepository = activityRecordsRepository ?? throw new ArgumentNullException(nameof(activityRecordsRepository));
        }


        public async Task<IEnumerable<ActivityRecordViewModel>> HandleAndGetResultAsync(GetAllActivityRecordsForDayRecordWithId query)
        {
            var activityRecords = await _activityRecordsRepository.GetAllForDayRecordWithIdAsync(query.DayRecordId);

            //var activityRecordsViewModels = // factory

            throw new NotImplementedException();
        }
    }
}
