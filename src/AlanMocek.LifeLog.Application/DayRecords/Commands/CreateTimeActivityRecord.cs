using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.Commands
{
    public record CreateTimeActivityRecord
    {
        public Guid DayRecordId { get; init; }
        public Guid ActivityId { get; init; }
        public TimeSpan Time { get; init; }


        public CreateTimeActivityRecord(Guid dayRecordId, Guid activityId, TimeSpan time)
        {
            DayRecordId = dayRecordId;
            ActivityId = activityId;
            Time = time;
        }
    }
}
