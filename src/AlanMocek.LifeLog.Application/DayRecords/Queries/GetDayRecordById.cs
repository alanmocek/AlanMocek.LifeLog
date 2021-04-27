using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.Queries
{
    public record GetDayRecordById
    {
        public Guid Id { get; init; }


        public GetDayRecordById(Guid id)
        {
            Id = id;
        }
    }
}
