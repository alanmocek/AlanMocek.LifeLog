using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
