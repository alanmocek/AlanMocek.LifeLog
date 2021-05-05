using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;

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
