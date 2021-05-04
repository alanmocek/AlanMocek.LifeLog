using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Commands
{
    public record CreateTimeActivityRecord : CreateActivityRecord
    {
        public TimeSpan Time { get; init; }


        public CreateTimeActivityRecord(Guid id, Guid activityId, Guid dayReportId, TimeSpan time) 
            : base(id, activityId, dayReportId)
        {
            Time = time;
        }
    }
}
