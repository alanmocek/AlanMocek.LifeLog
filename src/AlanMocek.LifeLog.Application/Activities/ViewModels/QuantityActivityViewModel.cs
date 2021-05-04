using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.ViewModels
{
    public class QuantityActivityViewModel : ActivityViewModel
    {
        internal QuantityActivityViewModel(Guid activityId, string activityName, string activityType, bool activityHasValue)
            : base(activityId, activityName, activityType, activityHasValue)
        {

        }
    }
}
