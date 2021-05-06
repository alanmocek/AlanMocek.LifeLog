using System;

namespace AlanMocek.LifeLog.Application.DayRecords.DTOs
{
    public record DayRecordForCalendarPanel
    {
        public Guid Id { get; init; }
        public DateTime Date { get; init; }


        public DayRecordForCalendarPanel(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }
    }
}
