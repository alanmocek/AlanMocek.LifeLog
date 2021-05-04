using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Commands
{
    public record CreateOccurrenceActivityRecord : CreateActivityRecord
    {
        public CreateOccurrenceActivityRecord(Guid id, Guid activityId, Guid dayReportId) : base(id, activityId, dayReportId)
        {
        }
    }
}
