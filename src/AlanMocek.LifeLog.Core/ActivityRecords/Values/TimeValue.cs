using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords.Values
{
    public record TimeValue
    {
        public TimeSpan Time { get; init; }


        public TimeValue(TimeSpan time)
        {
            Time = time;
        }
    }
}
