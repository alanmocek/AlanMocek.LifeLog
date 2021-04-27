using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public record ActivityRecordOrder
    {
        public int Order { get; init; }


        public ActivityRecordOrder(int order)
        {
            if(order <= 0)
            {
                throw new Exception("Order can not be less or equal to zero."); // TODO to core exception
            }

            Order = order;
        }
    }
}
