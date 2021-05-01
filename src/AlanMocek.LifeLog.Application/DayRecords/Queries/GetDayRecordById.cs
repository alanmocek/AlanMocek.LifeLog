using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.Queries
{
    public record GetDayRecordById : ILifeLogQuery<DayRecordViewModel>
    {
        public Guid Id { get; init; }


        public GetDayRecordById(Guid id)
        {
            Id = id;
        }
    }
}
