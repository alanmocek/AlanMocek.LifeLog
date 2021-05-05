using System;
using System.Collections.Generic;
using System.Text;

namespace AlanMocek.LifeLog.Core.Activities
{
    public class OccurredActivity : Activity
    {
        public OccurredActivity(Guid id, string name) 
            : base(id, name, "activity_occurred", false)
        {

        }
    }
}
