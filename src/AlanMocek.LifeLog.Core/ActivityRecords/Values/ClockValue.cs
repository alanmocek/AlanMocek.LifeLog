using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.ActivityRecords.Values
{
    public record ClockValue : ActivityRecordValue
    {
        public int Hour { get; init; }
        public int Minute { get; init; }


        public ClockValue(int hour, int minute)
        {
            if(hour < 0 || hour > 23)
            {
                throw new CoreException("Hour can not be less than zero or greater than 23."); // todo core exception
            }

            if(minute < 0 || minute > 59)
            {
                throw new CoreException("Minut can not be less than zero or greater than 59."); // todo core exception
            }

            Hour = hour;
            Minute = minute;
        }
    }
}
