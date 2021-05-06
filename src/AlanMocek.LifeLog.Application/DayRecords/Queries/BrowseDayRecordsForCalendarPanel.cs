using AlanMocek.LifeLog.Application.DayRecords.DTOs;
using AlanMocek.LifeLog.Infrastructure.Types;
using System.Collections.Generic;

namespace AlanMocek.LifeLog.Application.DayRecords.Queries
{
    public record BrowseDayRecordsForCalendarPanel : ILifeLogQuery<IEnumerable<DayRecordForCalendarPanel>>
    {
        public int Year { get; init; }
        public int Month { get; init; }


        public BrowseDayRecordsForCalendarPanel(int year, int month)
        {
            Year = year;
            Month = month;
        }
    }
}
