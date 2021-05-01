using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.ViewModels
{
    public class ClockActivityRecordViewModel : ActivityRecordViewModel
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }


        public ClockActivityRecordViewModel(Guid activityRecordId, Guid activityRecordActivityId, string activityRecordActivityName, int hour, int minute) 
            : base(activityRecordId, activityRecordActivityId, activityRecordActivityName)
        {
            Hour = hour;
            Minute = minute;
        }
    }
}
