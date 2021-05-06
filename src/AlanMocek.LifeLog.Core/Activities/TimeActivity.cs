using System;
using System.Collections.Generic;
using System.Text;

namespace AlanMocek.LifeLog.Core.Activities
{
    public class TimeActivity : Activity
    {
        /// <summary>
        /// Internal constructor for <see cref="Services.ActivitiesFactory"/> use.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        internal TimeActivity(Guid id, string name) 
            : base(id, name, ActivitiesTypes.TimeActivity, true)
        {

        }
    }
}
