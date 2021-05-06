using AlanMocek.LifeLog.Application.DayRecords.DTOs;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;

namespace AlanMocek.LifeLog.Application.DayRecords.Queries
{
    public record GetDayRecordForCalendarPanelById : ILifeLogQuery<DayRecordForCalendarPanel>
    {
        public Guid Id { get; init; }


        public GetDayRecordForCalendarPanelById(Guid id)
        {
            Id = id;
        }
    }
}
