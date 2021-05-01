using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.Queries
{
    public record GetDayRecordCardById : ILifeLogQuery<DayRecordCardViewModel>
    {
        public Guid Id { get; init; }


        public GetDayRecordCardById(Guid id)
        {
            Id = id;
        }
    }
}
