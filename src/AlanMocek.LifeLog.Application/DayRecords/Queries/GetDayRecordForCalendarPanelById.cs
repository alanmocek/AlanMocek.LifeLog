using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
