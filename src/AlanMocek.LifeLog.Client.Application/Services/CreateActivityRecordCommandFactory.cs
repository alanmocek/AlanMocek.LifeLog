using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Client.Application.Services
{
    public class CreateActivityRecordCommandFactory
    {
        public CreateActivityRecord FactorCreateActivityRecordCommand(Guid commandId, DayRecordViewModel dayRecord, ActivityViewModel activity, ActivityRecordValueViewModel value)
        {
            return activity.ActivityType switch
            {
                "activity_time" => new CreateTimeActivityRecord(commandId, activity.ActivityId, dayRecord.DayRecordId, 
                new TimeSpan((value as TimeActivityRecordValueViewModel).Hours, (value as TimeActivityRecordValueViewModel).Minutes, (value as TimeActivityRecordValueViewModel).Seconds)),
                
                "activity_quantity" => new CreateQuantityActivityRecord(commandId, activity.ActivityId, dayRecord.DayRecordId, (value as QuantityActivityRecordValueViewModel).Quantity),

                "activity_occurrence" => new CreateOccurrenceActivityRecord(commandId, activity.ActivityId, dayRecord.DayRecordId),

                "activity_clock" => new CreateClockActivityRecord(commandId, activity.ActivityId, dayRecord.DayRecordId,
                (value as ClockActivityRecordValueViewModel).Hour, (value as ClockActivityRecordValueViewModel).Minute),

                _ => throw new ArgumentException($"Factoring creation command of activity record for activity of type {activity.ActivityType} is not implemented.")
            };
        }
    }
}
