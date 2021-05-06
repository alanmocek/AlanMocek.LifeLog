using AlanMocek.LifeLog.Core.Activities;
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


        private TimeActivityRecord() { }

        internal TimeActivityRecord(Guid id, Activity activity, Guid dayRecordId, ActivityRecordOrder order, TimeValue value) 
            : base(id, activity, dayRecordId, order)
        {
            if (activity.Type != ActivitiesTypes.TimeActivity)
            {
                throw new Exception($"Can not create {nameof(TimeActivityRecord)} for activity type other than {ActivitiesTypes.TimeActivity}.");
            }

            Value = value;
        }


        public void ChangeValue(TimeValue newValue)
        {
            Value = newValue;
        }
    }
}
