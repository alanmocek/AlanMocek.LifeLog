using System;
using System.Collections.Generic;
using System.Text;

namespace AlanMocek.LifeLog.Core.Activities
{
    public class OccurrenceActivity : Activity
    {
        /// <summary>
        /// Internal constructor for <see cref="Services.ActivitiesFactory"/> use.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        internal OccurrenceActivity(Guid id, string name) 
            : base(id, name, ActivitiesTypes.OccurrenceActivity, false)
        {

        }
    }
}
