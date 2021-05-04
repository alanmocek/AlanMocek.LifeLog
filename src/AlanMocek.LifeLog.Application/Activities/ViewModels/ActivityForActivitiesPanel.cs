using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.ViewModels
{
    public abstract class ActivityForActivitiesPanel : ViewModel
    {
        public Guid ActivityId { get; protected set; }
        public string ActivityName { get; protected set; }
        public bool ActivityHasValue { get; protected set; }
        public string ActivityType { get; protected set; }


        internal ActivityForActivitiesPanel(Guid activityId, string activityName, string acctivityType, bool activityHasValue)
        {
            ActivityId = activityId;
            ActivityName = activityName;
            ActivityType = acctivityType;
            ActivityHasValue = activityHasValue;
        }
    }

    public class TimeActivityForActivitiesPanel : ActivityForActivitiesPanel
    {
        public TimeActivityForActivitiesPanel(Guid activityId, string activityName, string acctivityType, bool activityHasValue) 
            : base(activityId, activityName, acctivityType, activityHasValue)
        {
        }
    }

    public class QuantityActivityForActivitiesPanel : ActivityForActivitiesPanel
    {
        public QuantityActivityForActivitiesPanel(Guid activityId, string activityName, string acctivityType, bool activityHasValue)
            : base(activityId, activityName, acctivityType, activityHasValue)
        {

        }
    }

    public class OccurredActivityForActivitiesPanel : ActivityForActivitiesPanel
    {
        public OccurredActivityForActivitiesPanel(Guid activityId, string activityName, string acctivityType, bool activityHasValue)
            : base(activityId, activityName, acctivityType, activityHasValue)
        {

        }
    }

    public class ClockActivityForActivitiesPanel : ActivityForActivitiesPanel
    {
        public ClockActivityForActivitiesPanel(Guid activityId, string activityName, string acctivityType, bool activityHasValue)
            : base(activityId, activityName, acctivityType, activityHasValue)
        {

        }
    }
}
