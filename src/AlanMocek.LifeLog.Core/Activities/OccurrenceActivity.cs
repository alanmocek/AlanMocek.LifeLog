using System;
using System.Collections.Generic;
using System.Text;

namespace AlanMocek.LifeLog.Core.Activities
{
    public class OccurrenceActivity : Activity
    {
        public OccurrenceActivity(Guid id, string name) 
            : base(id, name, "activity_occurrence")
        {

        }
    }
}
