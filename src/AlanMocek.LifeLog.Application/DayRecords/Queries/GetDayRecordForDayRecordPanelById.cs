using AlanMocek.LifeLog.Application.DayRecords.DTOs;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;

namespace AlanMocek.LifeLog.Application.DayRecords.Queries
{
    public record GetDayRecordForDayRecordPanelById : ILifeLogQuery<DayRecordForDayRecordPanel>
    {
        public Guid Id { get; init; }


        public GetDayRecordForDayRecordPanelById(Guid id)
        {
            Id = id;
        }
    }
}
