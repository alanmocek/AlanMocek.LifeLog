using AlanMocek.LifeLog.Core.ActivityRecords.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public class OccuredActivityRecord : ActivityRecord
    {
        public OccuredActivityRecord(Guid id, Guid dayRecordId, ActivityRecordOrder order)
            : base(id, dayRecordId, order)
        {
            
        }
    }
}
