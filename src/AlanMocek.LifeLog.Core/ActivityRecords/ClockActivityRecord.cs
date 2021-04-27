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


        public ClockActivityRecord(Guid id, Guid dayRecordId, ActivityRecordOrder order, ClockValue value) 
            : base(id, dayRecordId, order)
        {
            Value = value;
        }


        public void ChangeValue(ClockValue newValue)
        {
            Value = newValue;
        }
    }
}
