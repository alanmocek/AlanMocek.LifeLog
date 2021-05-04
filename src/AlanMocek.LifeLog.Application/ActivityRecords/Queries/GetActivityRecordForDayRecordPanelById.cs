using AlanMocek.LifeLog.Application.ActivityRecords.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
