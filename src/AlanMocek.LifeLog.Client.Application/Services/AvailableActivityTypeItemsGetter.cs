using AlanMocek.LifeLog.Client.Application.ViewModels.ActivitiesPanel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Client.Application.Services
{
    public class AvailableActivityTypeItemsGetter
    {
        private readonly IServiceProvider _serviceProvider;


        public AvailableActivityTypeItemsGetter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public IEnumerable<AvailableActivityTypeItem> GetAll()
        {
            var timeActivityTypeItem = _serviceProvider.GetRequiredService<AvailableActivityTypeItem>();
            timeActivityTypeItem.Initialize("activity_time", "Time");

            var quantityActivityTypeItem = _serviceProvider.GetRequiredService<AvailableActivityTypeItem>();
            quantityActivityTypeItem.Initialize("activity_quantity", "Quantity");

            var occurrenceActivityTypeItem = _serviceProvider.GetRequiredService<AvailableActivityTypeItem>();
            occurrenceActivityTypeItem.Initialize("activity_occurrence", "Occurrence");

            var clockActivityTypeItem = _serviceProvider.GetRequiredService<AvailableActivityTypeItem>();
            clockActivityTypeItem.Initialize("activity_clock", "Clock");


            return new AvailableActivityTypeItem[]
            {
                timeActivityTypeItem,
                quantityActivityTypeItem,
                occurrenceActivityTypeItem,
                clockActivityTypeItem
            };
        }
    }
}
