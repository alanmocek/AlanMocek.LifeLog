using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using AlanMocek.LifeLog.Core.DayRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public abstract class ActivityRecord
    {
        public Guid Id { get; private set; }
        public Guid DayRecordId { get; private set; }
        public ActivityRecordOrder Order { get; private set; }


        public ActivityRecord(Guid id, Guid dayRecordId, ActivityRecordOrder order)
        {
            Id = id;
            DayRecordId = dayRecordId;
            Order = order;
        }


        internal void SetNewOrder(ActivityRecordOrder newOrder)
        {
            Order = newOrder;
        }
    }
}
