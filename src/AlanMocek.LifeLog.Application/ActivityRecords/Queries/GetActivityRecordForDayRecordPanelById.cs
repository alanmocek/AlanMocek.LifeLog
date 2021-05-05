using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Queries
{
    public record GetActivityRecordForDayRecordPanelById : ILifeLogQuery<ActivityRecordForDayRecordPanel>
    {
        public Guid Id { get; init; }


        public GetActivityRecordForDayRecordPanelById(Guid id)
        {
            Id = id;
        }
    }
}
