using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.ViewModels
{
    public abstract class ActivityRecordForDayRecordPanel : ViewModel
    {
        public Guid ActivityRecordId { get; private set; }
        public Guid ActivityRecordDayRecordId { get; private set; }
        public ActivityRecordForDayRecordPanelActivity ActivityRecordActivity { get; private set; }


        public ActivityRecordForDayRecordPanel(Guid activityRecordId, Guid activityRecordDayRecordId, ActivityRecordForDayRecordPanelActivity activityRecordActivity)
        {
            ActivityRecordId = activityRecordId;
            ActivityRecordDayRecordId = activityRecordDayRecordId;
            ActivityRecordActivity = activityRecordActivity;
        }
    }


    public class TimeActivityRecordForDayRecordPanel : ActivityRecordForDayRecordPanel
    {
        public TimeSpan ActivityRecordTimeValue { get; private set; }


        public TimeActivityRecordForDayRecordPanel(Guid activityRecordId, Guid activityRecordDayRecordId, 
            ActivityRecordForDayRecordPanelActivity activityRecordActivity, TimeSpan activityRecordTimeValue) 
            : base(activityRecordId, activityRecordDayRecordId, activityRecordActivity)
        {
            ActivityRecordTimeValue = activityRecordTimeValue;
        }
    }

    public class ClockActivityRecordForDayRecordPanel : ActivityRecordForDayRecordPanel
    {
        public int ActivityRecordHourValue { get; private set; }
        public int ActivityRecordMinuteValue { get; private set; }


        public ClockActivityRecordForDayRecordPanel(Guid activityRecordId, Guid activityRecordDayRecordId,
            ActivityRecordForDayRecordPanelActivity activityRecordActivity, int activityRecordHourValue, int activityRecordMinuteValue)
            : base(activityRecordId, activityRecordDayRecordId, activityRecordActivity)
        {
            ActivityRecordHourValue = activityRecordHourValue;
            ActivityRecordMinuteValue = activityRecordMinuteValue;
        }
    }

    public class QuantityActivityRecordForDayRecordPanel : ActivityRecordForDayRecordPanel
    {
        public int ActivityRecordQuantityValue { get; private set; }


        public QuantityActivityRecordForDayRecordPanel(Guid activityRecordId, Guid activityRecordDayRecordId,
            ActivityRecordForDayRecordPanelActivity activityRecordActivity, int activityRecordQuantityValue)
            : base(activityRecordId, activityRecordDayRecordId, activityRecordActivity)
        {
            ActivityRecordQuantityValue = activityRecordQuantityValue;
        }
    }

    public class OccurredActivityRecordForDayRecordPanel : ActivityRecordForDayRecordPanel
    {
        public OccurredActivityRecordForDayRecordPanel(Guid activityRecordId, Guid activityRecordDayRecordId, 
            ActivityRecordForDayRecordPanelActivity activityRecordActivity) 
            : base(activityRecordId, activityRecordDayRecordId, activityRecordActivity)
        {

        }
    }


    public class ActivityRecordForDayRecordPanelActivity : ViewModel 
    {
        public Guid ActivityId { get; private set; }
        public string ActivityName { get; private set; }


        public ActivityRecordForDayRecordPanelActivity(Guid activityId, string activityName)
        {
            ActivityId = activityId;
            ActivityName = activityName;
        }
    }

}
