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
        public string ActivityType { get; private set; }
        public Guid DayRecordId { get; private set; }
        public ActivityRecordOrder Order { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime UpdatedAtUtc { get; private set; }


        Activity IActivityRecordWithActivity.Activity => _IActivityRecordWithActivity_Activity;


        protected ActivityRecord() { }

        internal ActivityRecord(Guid id, Activity activity, Guid dayRecordId, ActivityRecordOrder order)
        {
            Id = id;
            ActivityId = activity.Id;
            ActivityType = activity.Type;
            DayRecordId = dayRecordId;
            Order = order;
            var nowUtc = DateTime.UtcNow;
            CreatedAtUtc = nowUtc;
            UpdatedAtUtc = nowUtc;
        }


        internal void SetNewOrder(ActivityRecordOrder newOrder)
        {
            Order = newOrder;
        }
    }
}
