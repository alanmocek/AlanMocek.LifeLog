using AlanMocek.LifeLog.Core.Activities;
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


        private QuantityActivityRecord() { }

        internal QuantityActivityRecord(Guid id, Activity activity, Guid dayRecordId, ActivityRecordOrder order, QuantityValue value) 
            : base(id, activity, dayRecordId, order)
        {
            if (activity.Type != ActivitiesTypes.QuantityActivity)
            {
                throw new Exception($"Can not create {nameof(QuantityActivityRecord)} for activity type other than {ActivitiesTypes.QuantityActivity}.");
            }

            Value = value;
        }


        public void ChangeValue(QuantityValue newValue)
        {
            Value = newValue;
        }
    }
}
