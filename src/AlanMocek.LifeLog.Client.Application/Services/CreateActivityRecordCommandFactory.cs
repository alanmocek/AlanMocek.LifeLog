using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanelViewModels;
using System;

namespace AlanMocek.LifeLog.Client.Application.Services
{
    public class CreateActivityRecordCommandFactory
    {
        public CreateActivityRecord FactorCreateActivityRecordCommand(Guid commandId, Guid dayRecordId, Guid activityId, string activityType, DayRecordPanelActivityRecordValueItem value)
        {
            return activityType switch
            {
                "activity_time" => new CreateTimeActivityRecord(commandId, activityId, dayRecordId, 
                new TimeSpan((value as DayRecordPanelTimeActivityRecordValueItem).Hours, (value as DayRecordPanelTimeActivityRecordValueItem).Minutes, (value as DayRecordPanelTimeActivityRecordValueItem).Seconds)),
                
                "activity_quantity" => new CreateQuantityActivityRecord(commandId, activityId, dayRecordId, (value as DayRecordPanelQuantityActivityRecordValueItem).Quantity),


                "activity_clock" => new CreateClockActivityRecord(commandId, activityId, dayRecordId,
                (value as DayRecordPanelClockActivityRecordValueItem).Hour, (value as DayRecordPanelClockActivityRecordValueItem).Minute),

                "activity_occurred" => new CreateOccurrenceActivityRecord(commandId, activityId, dayRecordId),

                _ => throw new ArgumentException($"Factoring creation command of activity record for activity of type {activityType} is not implemented.")
            };
        }
    }
}
