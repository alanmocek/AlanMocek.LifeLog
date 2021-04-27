using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public class TimeActivityRecord : ActivityRecord
    {
        public TimeValue Value { get; private set; }


        public TimeActivityRecord(Guid id, Guid dayRecordId, ActivityRecordOrder order, TimeValue value)
            : base(id, dayRecordId, order)
        {
            Value = value;
        }


        public void ChangeValue(TimeValue newValue)
        {
            Value = newValue;
        }
    }
}
