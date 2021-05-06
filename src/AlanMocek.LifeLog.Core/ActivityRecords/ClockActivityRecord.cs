using AlanMocek.LifeLog.Core.Activities;
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


        private ClockActivityRecord() { }

        public ClockActivityRecord(Guid id, Activity activity, Guid dayRecordId, ActivityRecordOrder order, ClockValue value) 
            : base(id, activity, dayRecordId, order)
        {
            if (activity.Type != ActivitiesTypes.ClockActivity)
            {
                throw new Exception($"Can not create {nameof(ClockActivityRecord)} for activity type other than {ActivitiesTypes.ClockActivity}.");
            }

            Value = value;
        }


        public void ChangeValue(ClockValue newValue)
        {
            Value = newValue;
        }
    }
}
