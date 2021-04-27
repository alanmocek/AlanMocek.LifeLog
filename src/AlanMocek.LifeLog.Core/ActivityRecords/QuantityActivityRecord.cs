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


        public QuantityActivityRecord(Guid id, Guid dayRecordId, ActivityRecordOrder order, QuantityValue value)
            : base(id, dayRecordId, order)
        {
            Value = value;
        }


        public void ChangeValue(QuantityValue newValue)
        {
            Value = newValue;
        }
    }
}
