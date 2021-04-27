using System;
using System.Collections.Generic;
using System.Text;

namespace AlanMocek.LifeLog.Core.Activities
{
    public class TimeActivity : Activity
    {
        public TimeActivity(Guid id, string name) 
            : base(id, name, "activity_time")
        {

        }
    }
}
