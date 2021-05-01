using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.ViewModels
{
    public class QuantityActivityRecordViewModel : ActivityRecordViewModel
    {
        public int Quantity { get; private set; }


        public QuantityActivityRecordViewModel(Guid activityRecordId, Guid activityRecordActivityId, string activityRecordActivityName,
            int quantity) 
            : base(activityRecordId, activityRecordActivityId, activityRecordActivityName)
        {
            Quantity = quantity;
        }
    }
}
