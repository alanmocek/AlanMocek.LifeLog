using System;
using System.Collections.Generic;
using System.Text;

namespace AlanMocek.LifeLog.Core.Activities
{
    public class ClockActivity : Activity
    {
        public ClockActivity(Guid id, string name) 
            : base(id, name, "activity_clock", true)
        {
        }
    }
}
