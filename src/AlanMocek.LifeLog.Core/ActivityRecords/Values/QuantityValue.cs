using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords.Values
{
    public record QuantityValue : ActivityRecordValue
    {
        public int Quantity { get; init; }


        public QuantityValue(int quantity)
        {
            if (quantity <= 0) 
            {
                throw new CoreException("Quantity can not be less or equal to zero.");
            }


            if(quantity > 99999)
            {
                throw new CoreException("Quantity can not be greater then 99999.");
            }

            Quantity = quantity;
        }
    }
}
