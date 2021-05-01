using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.ViewModels
{
    public class OccurrenceActivityRecordViewModel : ActivityRecordViewModel
    {
        public OccurrenceActivityRecordViewModel(Guid activityRecordId, Guid activityRecordActivityId, string activityRecordActivityName) 
            : base(activityRecordId, activityRecordActivityId, activityRecordActivityName)
        {

        }
    }
}
