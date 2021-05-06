using AlanMocek.LifeLog.Core.Activities;
using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public class OccurrenceActivityRecord : ActivityRecord
    {
        private OccurrenceActivityRecord() { }

        internal OccurrenceActivityRecord(Guid id, Activity activity, Guid dayRecordId, ActivityRecordOrder order) : base(id, activity, dayRecordId, order)
        {
            if (activity.Type != ActivitiesTypes.OccurrenceActivity)
            {
                throw new Exception($"Can not create {nameof(OccurrenceActivityRecord)} for activity type other than {ActivitiesTypes.OccurrenceActivity}.");
            }
        }
    }
}
