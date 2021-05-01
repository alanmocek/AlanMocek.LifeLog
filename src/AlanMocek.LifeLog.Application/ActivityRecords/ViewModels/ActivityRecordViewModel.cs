using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.ViewModels
{
    public abstract class ActivityRecordViewModel : ViewModel
    {
        public Guid ActivityRecordId { get; private set; }
        public Guid ActivityRecordActivityId { get; private set; }
        public string ActivityRecordActivityName { get; private set; }


        public ActivityRecordViewModel(Guid activityRecordId, Guid activityRecordActivityId, string activityRecordActivityName)
        {
            ActivityRecordId = activityRecordId;
            ActivityRecordActivityId = activityRecordActivityId;
            ActivityRecordActivityName = activityRecordActivityName;
        }
    }
}
