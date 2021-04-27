using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Core.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.Services
{
    public class ActivityViewModelsFactory
    {
        public ActivityViewModel FactorActivityViewModel(Activity activity)
        {
            ActivityViewModel activityViewModel = null;

            if(activity is ClockActivity)
            {
                activityViewModel = new ClockActivityViewModel(activity.Id, activity.Name);
            }

            if (activity is TimeActivity)
            {
                activityViewModel = new TimeActivityViewModel(activity.Id, activity.Name);
            }

            if (activity is OccurrenceActivity)
            {
                activityViewModel = new OccurenceActivityViewModel(activity.Id, activity.Name);
            }

            if (activity is QuantityActivity)
            {
                activityViewModel = new QuantityActivityViewModel(activity.Id, activity.Name);
            }

            if (activityViewModel is null)
            {
                throw new ArgumentException($"Activity of type '{activity.GetType()}' is not supported.");
            }
            
            return activityViewModel;
        }
    }
}
