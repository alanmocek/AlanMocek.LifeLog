using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public class ClockActivityRecord : ActivityRecord
    {
        public ClockValue Value { get; private set; }


        public ClockActivityRecord() { }

        public ClockActivityRecord(Guid id, Guid activityId, Guid dayRecordId, ActivityRecordOrder order, ClockValue value) 
            : base(id, activityId, dayRecordId, order, "activity_record_clock")
        {
            Value = value;
        }


        public void ChangeValue(ClockValue newValue)
        {
            Value = newValue;
        }
    }
}
