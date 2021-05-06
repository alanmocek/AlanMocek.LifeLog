using System;

namespace AlanMocek.LifeLog.Application.DayRecords.DTOs
{
    public record DayRecordForDayRecordPanel
    {
        public Guid Id { get; init; }
        public DateTime Date { get; init; }


        public DayRecordForDayRecordPanel(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }
    }
}
