using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public class OccurrenceActivityRecord : ActivityRecord
    {
        public OccurrenceActivityRecord() { }

        internal OccurrenceActivityRecord(Guid id, Guid activityId, Guid dayRecordId, ActivityRecordOrder order)
            : base(id, activityId, dayRecordId, order, "activity_record_occurrence")
        {
            
        }
    }
}
