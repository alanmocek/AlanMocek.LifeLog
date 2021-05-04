using AlanMocek.LifeLog.Application.ActivityRecords.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Queries
{
    public record BrowseActivityRecordsForDayRecordPanel 
        : ILifeLogQuery<IEnumerable<ActivityRecordForDayRecordPanel>>
    {
        public Guid DayRecordId { get; init; }


        public BrowseActivityRecordsForDayRecordPanel(Guid dayRecordId)
        {
            DayRecordId = dayRecordId;
        }
    }
}
