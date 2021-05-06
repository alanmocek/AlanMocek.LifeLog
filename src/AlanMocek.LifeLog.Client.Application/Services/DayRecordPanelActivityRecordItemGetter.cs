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
    public class DayRecordPanelActivityRecordItemGetter
    {
        public IServiceProvider _serviceProvider;


        public DayRecordPanelActivityRecordItemGetter(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public DayRecordPanelActivityRecordItem GetFromActivityType(string activityType)
        {
            return activityType switch
            {
                "activity_quantity" => _serviceProvider.GetRequiredService<DayRecordPanelQuantityActivityRecordItem>(),
                "activity_clock" => _serviceProvider.GetRequiredService<DayRecordPanelClockActivityRecordItem>(),
                "activity_time" => _serviceProvider.GetRequiredService<DayRecordPanelTimeActivityRecordItem>(),
                "activity_occurrence" => _serviceProvider.GetRequiredService<DayRecordPanelOccurrenceActivityRecordItem>(),
                _ => throw new ArgumentException($"DayRecordPanelActivityRecordItem getting for activity of type '{activityType}' is not implemented.")
            };
        }
    }
}
