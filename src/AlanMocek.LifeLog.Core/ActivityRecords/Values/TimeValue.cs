using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords.Values
{
    public record TimeValue : ActivityRecordValue
    {
        public int Hours { get; init; }
        public int Minutes { get; init; }
        public int Seconds { get; init; }


        public TimeValue(int hours, int minutes, int seconds)
        {
            if (hours < 0 || hours > 999) 
            {
                throw new CoreException("Hours can not be less than 0 or greater than 999.");
            }

            if (minutes < 0 | minutes > 59) 
            {
                throw new CoreException("Minutes can not be less than 0 or greater than 59.");
            }

            if (seconds < 0 | seconds > 59)
            {
                throw new CoreException("Seconds can not be less than 0 or greater than 59.");
            }

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
    }
}
