using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Commands
{
    public record CreateClockActivityRecord : CreateActivityRecord
    {
        public int Hour { get; init; }
        public int Minute { get; init; }


        public CreateClockActivityRecord(Guid id, Guid activityId, Guid dayReportId, int hour, int minute) 
            : base(id, activityId, dayReportId)
        {
            Hour = hour;
            Minute = minute;
        }
    }
}
