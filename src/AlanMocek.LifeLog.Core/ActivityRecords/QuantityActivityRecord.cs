using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public class QuantityActivityRecord : ActivityRecord
    {
        public QuantityValue Value { get; private set; }


        public QuantityActivityRecord() { }

        public QuantityActivityRecord(Guid id, Guid activityId, Guid dayRecordId, ActivityRecordOrder order, QuantityValue value)
            : base(id, activityId, dayRecordId, order, "activity_record_quantity")
        {
            Value = value;
        }


        public void ChangeValue(QuantityValue newValue)
        {
            Value = newValue;
        }
    }
}
