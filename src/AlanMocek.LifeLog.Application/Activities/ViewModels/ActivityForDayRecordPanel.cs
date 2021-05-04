using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.ViewModels
{
    public class ActivityForDayRecordPanel : ViewModel
    {
        public Guid ActivityId { get; private set; }
        public string ActivityName { get; private set; }
        public string ActivityType { get; private set; }
        public bool ActivityHasValue { get; private set; }


        public ActivityForDayRecordPanel(Guid activityId, string activityName, string activityType, bool activityHasValue)
        {
            ActivityId = activityId;
            ActivityName = activityName;
            ActivityType = activityType;
            ActivityHasValue = activityHasValue;
        }
    }
}
