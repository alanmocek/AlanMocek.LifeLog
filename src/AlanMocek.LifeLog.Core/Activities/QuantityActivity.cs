using System;
using System.Collections.Generic;
using System.Text;

namespace AlanMocek.LifeLog.Core.Activities
{
    public class QuantityActivity : Activity
    {
        public QuantityActivity(Guid id, string name) 
            : base(id, name, "activity_quantity", true)
        {

        }
    }
}
