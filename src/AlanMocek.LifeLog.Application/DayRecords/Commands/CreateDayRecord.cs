using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.Commands
{
    public record CreateDayRecord : ILifeLogCommand
    {
        public Guid Id { get; init; }
        public DateTime Date { get; init; }


        public CreateDayRecord(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }
    }
}
