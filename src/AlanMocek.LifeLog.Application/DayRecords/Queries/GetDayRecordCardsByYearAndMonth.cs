using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.Queries
{
    public record GetDayRecordCardsByYearAndMonth
    {
        public int Year { get; init; }
        public int Month { get; init; }


        public GetDayRecordCardsByYearAndMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }
    }
}
