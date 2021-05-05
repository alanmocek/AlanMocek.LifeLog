using AlanMocek.LifeLog.Infrastructure.Types;
using System;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Commands
{
    public abstract record CreateActivityRecord : ILifeLogCommand
    {
        public Guid Id { get; init; }
        public Guid ActivityId { get; init; }
        public Guid DayRecordId { get; init; }


        public CreateActivityRecord(Guid id, Guid activityId, Guid dayReportId)
        {
            Id = id;
            ActivityId = activityId;
            DayRecordId = dayReportId;
        }
    }


    public record CreateClockActivityRecord : CreateActivityRecord
    {
        public int Hour { get; init; }
        public int Minute { get; init; }


        public CreateClockActivityRecord(Guid id, Guid activityId, Guid dayReportId, int hour, int minute)
            : base(id, activityId, dayReportId)
        {
            Hour = hour;
            Minute = minute;
        }
    }


    public record CreateOccurrenceActivityRecord : CreateActivityRecord
    {
        public CreateOccurrenceActivityRecord(Guid id, Guid activityId, Guid dayReportId) : base(id, activityId, dayReportId)
        {
        }
    }


    public record CreateQuantityActivityRecord : CreateActivityRecord
    {
        public int Quantity { get; init; }


        public CreateQuantityActivityRecord(Guid id, Guid activityId, Guid dayReportId, int quantity) : base(id, activityId, dayReportId)
        {
            Quantity = quantity;
        }
    }


    public record CreateTimeActivityRecord : CreateActivityRecord
    {
        public TimeSpan Time { get; init; }


        public CreateTimeActivityRecord(Guid id, Guid activityId, Guid dayReportId, TimeSpan time)
            : base(id, activityId, dayReportId)
        {
            Time = time;
        }
    }
}
