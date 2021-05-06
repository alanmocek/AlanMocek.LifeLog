using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanelViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Client.Application.Services
{
    public class DayRecordPanelAddActivityRecordDialogValueItemGetter
    {
        public IServiceProvider _serviceProvider;


        public DayRecordPanelAddActivityRecordDialogValueItemGetter(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public DayRecordPanelActivityRecordValueItem GetFromActivityType(string activityType)
        {
            return activityType switch
            {
                "activity_quantity" => _serviceProvider.GetRequiredService<DayRecordPanelQuantityActivityRecordValueItem>(),
                "activity_clock" => _serviceProvider.GetRequiredService<DayRecordPanelClockActivityRecordValueItem>(),
                "activity_time" => _serviceProvider.GetRequiredService<DayRecordPanelTimeActivityRecordValueItem>(),
                "activity_occurrence" => _serviceProvider.GetRequiredService<DayRecordPanelOccurrenceActivityRecordValueItem>(),
                _ => throw new ArgumentException($"DayRecordPanelAddActivityRecordDialogValueItem getting for activity of type '{activityType}' is not implemented.")
            };
        }
    }
}
