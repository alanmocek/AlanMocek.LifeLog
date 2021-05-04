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
        public CreateActivityRecord FactorCreateActivityRecordCommand(Guid commandId, Guid dayRecordId, Guid activityId, string activityType, ActivityRecordValueViewModel value)
        {
            return activityType switch
            {
                "activity_time" => new CreateTimeActivityRecord(commandId, activityId, dayRecordId, 
                new TimeSpan((value as TimeActivityRecordValueViewModel).Hours, (value as TimeActivityRecordValueViewModel).Minutes, (value as TimeActivityRecordValueViewModel).Seconds)),
                
                "activity_quantity" => new CreateQuantityActivityRecord(commandId, activityId, dayRecordId, (value as QuantityActivityRecordValueViewModel).Quantity),

                "activity_occurrence" => new CreateOccurrenceActivityRecord(commandId, activityId, dayRecordId),

                "activity_clock" => new CreateClockActivityRecord(commandId, activityId, dayRecordId,
                (value as ClockActivityRecordValueViewModel).Hour, (value as ClockActivityRecordValueViewModel).Minute),

                _ => throw new ArgumentException($"Factoring creation command of activity record for activity of type {activityType} is not implemented.")
            };
        }
    }
}
