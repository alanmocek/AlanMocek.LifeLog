using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.ViewModels
{
    public class TimeActivityRecordViewModel : ActivityRecordViewModel
    {
        public TimeSpan Time { get; private set; }


        public TimeActivityRecordViewModel(Guid activityRecordId, Guid activityRecordActivityId, string activityRecordActivityName,
            TimeSpan time) 
            : base(activityRecordId, activityRecordActivityId, activityRecordActivityName)
        {
            Time = time;
        }
    }
}
