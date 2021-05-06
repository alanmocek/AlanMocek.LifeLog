using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.Activities.Services
{
    public class ActivitiesFactory
    {
        internal Activity FactorActivityByType(Guid id, string name, string type)
        {
            Activity activity = type switch
            {
                ActivitiesTypes.ClockActivity => new ClockActivity(id, name),
                ActivitiesTypes.OccurrenceActivity => new OccurrenceActivity(id, name),
                ActivitiesTypes.QuantityActivity => new QuantityActivity(id, name),
                ActivitiesTypes.TimeActivity => new TimeActivity(id, name),
                _ => throw new NotImplementedException($"Activity factoring of type '{type}' is not implemented.")
            };

            return activity;
        }
    }
}
