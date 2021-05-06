using System;
using System.Collections.Generic;
using System.Text;

namespace AlanMocek.LifeLog.Core.Activities
{
    public class QuantityActivity : Activity
    {
        /// <summary>
        /// Internal constructor for <see cref="Services.ActivitiesFactory"/> use.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        internal QuantityActivity(Guid id, string name) 
            : base(id, name, ActivitiesTypes.QuantityActivity, true)
        {

        }
    }
}
