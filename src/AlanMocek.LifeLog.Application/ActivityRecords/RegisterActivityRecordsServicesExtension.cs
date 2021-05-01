using AlanMocek.LifeLog.Application.ActivityRecords.Queries;
using AlanMocek.LifeLog.Application.ActivityRecords.QueryHandlers;
using AlanMocek.LifeLog.Application.ActivityRecords.Services;
using AlanMocek.LifeLog.Application.ActivityRecords.ViewModels;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Data.Repositories;
using AlanMocek.LifeLog.Infrastructure.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords
{
    public static class RegisterActivityRecordsServicesExtension
    {
        public static IServiceCollection AddActivityRecordsServices(
             this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetAllActivityRecordsForDayRecordWithId, IEnumerable<ActivityRecordViewModel>>, GetAllActivityRecordsForDayRecordWithIdHandler>();


            services.AddScoped<ActivityRecordViewModelFactory>();


            services.AddScoped<IActivityRecordsRepository, ActivityRecordsRepository>();
            
            return services;
        }
    }
}
