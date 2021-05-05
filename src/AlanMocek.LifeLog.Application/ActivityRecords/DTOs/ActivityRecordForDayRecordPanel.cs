using System;

namespace AlanMocek.LifeLog.Application.ActivityRecords.DTOs
{
    public abstract record ActivityRecordForDayRecordPanel
    {
        public Guid Id { get; init; }
        public Guid DayRecordId { get; init; }
        public int Order { get; init; }
        public ActivityRecordForDayRecordPanelActivity Activity { get; init; }
        

        public ActivityRecordForDayRecordPanel(Guid id, Guid dayRecordId, int order, ActivityRecordForDayRecordPanelActivity activity)
        {
            Id = id;
            DayRecordId = dayRecordId;
            Order = order;
            Activity = activity;
        }
    }


    public record TimeActivityRecordForDayRecordPanel : ActivityRecordForDayRecordPanel
    {
        public TimeSpan TimeValue { get; init; }


        public TimeActivityRecordForDayRecordPanel(Guid id, Guid dayRecordId, int order,
            ActivityRecordForDayRecordPanelActivity activity, TimeSpan timeValue)
            : base(id, dayRecordId, order, activity)
        {
            TimeValue = timeValue;
        }
    }

    public record ClockActivityRecordForDayRecordPanel : ActivityRecordForDayRecordPanel
    {
        public int HourValue { get; init; }
        public int MinuteValue { get; init; }


        public ClockActivityRecordForDayRecordPanel(Guid id, Guid dayRecordId, int order,
            ActivityRecordForDayRecordPanelActivity activity, int hourValue, int minuteValue)
            : base(id, dayRecordId, order, activity)
        {
            HourValue = hourValue;
            MinuteValue = minuteValue;
        }
    }

    public record QuantityActivityRecordForDayRecordPanel : ActivityRecordForDayRecordPanel
    {
        public int QuantityValue { get; init; }


        public QuantityActivityRecordForDayRecordPanel(Guid id, Guid dayRecordId, int order,
            ActivityRecordForDayRecordPanelActivity activity, int quantityValue)
            : base(id, dayRecordId, order, activity)
        {
            QuantityValue = quantityValue;
        }
    }

    public record OccurredActivityRecordForDayRecordPanel : ActivityRecordForDayRecordPanel
    {
        public OccurredActivityRecordForDayRecordPanel(Guid id, Guid dayRecordId, int order,
            ActivityRecordForDayRecordPanelActivity activity)
            : base(id, dayRecordId, order, activity)
        {

        }
    }


    public record ActivityRecordForDayRecordPanelActivity
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }


        public ActivityRecordForDayRecordPanelActivity(Guid id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
