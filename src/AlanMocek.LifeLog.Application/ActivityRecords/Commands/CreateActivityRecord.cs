using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Commands
{
    public abstract record CreateActivityRecord : ILifeLogCommand
    {
        public Guid Id { get; init; }
        public Guid ActivityId { get; init; }
        public Guid DayRecordId { get; init; }


        public CreateActivityRecord(Guid id, Guid activityId, Guid dayReportId)
        {
            Id = id;
            ActivityId = activityId;
            DayRecordId = dayReportId;
        }
    }
}
