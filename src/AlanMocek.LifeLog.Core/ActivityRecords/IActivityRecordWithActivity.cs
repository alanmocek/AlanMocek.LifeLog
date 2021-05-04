using AlanMocek.LifeLog.Core.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    /// <summary>
    /// Should be obtained only from repository.
    /// Must include <see cref="Activities.Activity"/>.
    /// </summary>
    public interface IActivityRecordWithActivity
    {
        public Guid Id { get; }
        public Guid ActivityId { get; }
        public Guid DayRecordId { get; }
        public ActivityRecordOrder Order { get; }


        public Activity Activity { get; }
    }
}
