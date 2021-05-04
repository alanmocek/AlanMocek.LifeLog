using AlanMocek.LifeLog.Core.Activities;
using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using AlanMocek.LifeLog.Core.DayRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public abstract class ActivityRecord : IActivityRecordWithActivity
    {
        private Activity _IActivityRecordWithActivity_Activity;


        public Guid Id { get; private set; }
        public Guid ActivityId { get; private set; }
        public Guid DayRecordId { get; private set; }
        public string Type { get; private set; }
        public ActivityRecordOrder Order { get; private set; }


        Activity IActivityRecordWithActivity.Activity => _IActivityRecordWithActivity_Activity;


        public ActivityRecord() { }

        public ActivityRecord(Guid id, Guid activityId, Guid dayRecordId, ActivityRecordOrder order, string type)
        {
            Id = id;
            ActivityId = activityId;
            DayRecordId = dayRecordId;
            Order = order;
            Type = type;
        }


        internal void SetNewOrder(ActivityRecordOrder newOrder)
        {
            Order = newOrder;
        }
    }
}
