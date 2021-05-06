using AlanMocek.LifeLog.Application.ActivityRecords.CommandHandlers;
using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Application.ActivityRecords.Queries;
using AlanMocek.LifeLog.Application.ActivityRecords.QueryHandlers;
using AlanMocek.LifeLog.Application.ActivityRecords.Services;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Data.Repositories;
using AlanMocek.LifeLog.Infrastructure.Types;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AlanMocek.LifeLog.Application.ActivityRecords
{
    public static class RegisterActivityRecordsServicesExtension
    {
        public static IServiceCollection AddActivityRecordsServices(
             this IServiceCollection services)
        {
            // Application
            services.AddScoped<IQueryHandler<GetActivityRecordForDayRecordPanelById, ActivityRecordForDayRecordPanel>, GetActivityRecordForDayRecordPanelByIdHandler>();
            services.AddScoped<IQueryHandler<BrowseActivityRecordsForDayRecordPanel, IEnumerable<ActivityRecordForDayRecordPanel>>, BrowseActivityRecordsForDayRecordPanelHandler>();

            services.AddScoped<ICommandHandler<CreateTimeActivityRecord>, CreateTimeActivityRecordHandler>();
            services.AddScoped<ICommandHandler<CreateQuantityActivityRecord>, CreateQuantityActivityRecordHandler>();
            services.AddScoped<ICommandHandler<CreateOccurrenceActivityRecord>, CreateOccurrenceActivityRecordHandler>();
            services.AddScoped<ICommandHandler<CreateClockActivityRecord>, CreateClockActivityRecordHandler>();

            services.AddScoped<ICommandHandler<ChangeActivityRecordOrder>, ChangeActivityRecordOrderHandler>();

            services.AddScoped<ICommandHandler<DeleteActivityRecord>, DeleteActivityRecordHandler>();

            services.AddScoped<ActivityRecordWithActivityToActivityRecordForDayRecordPanelMapper>();


            // Core
            services.AddScoped<IActivityRecordsRepository, ActivityRecordsRepository>();
            
            services.AddScoped<ActivityRecordsDeleter>();
            services.AddScoped<ActivityRecordCreator>();
            services.AddScoped<ActivityRecordOrderChanger>();

            return services;
        }
    }
}
