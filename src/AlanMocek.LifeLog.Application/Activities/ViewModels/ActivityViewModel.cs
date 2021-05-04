using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.ViewModels
{
    public abstract class ActivityViewModel : ViewModel
    {
        public Guid ActivityId { get; protected set; }
        public string ActivityName { get; protected set; }
        public bool ActivityHasValue { get; protected set; }
        public string ActivityType { get; protected set; }


        internal ActivityViewModel(Guid activityId, string activityName, string acctivityType, bool activityHasValue)
        {
            ActivityId = activityId;
            ActivityName = activityName;
            ActivityType = acctivityType;
            ActivityHasValue = activityHasValue;
        }
    }
}
