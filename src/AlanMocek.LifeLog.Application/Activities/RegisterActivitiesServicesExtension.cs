using AlanMocek.LifeLog.Application.Activities.CommandHandlers;
using AlanMocek.LifeLog.Application.Activities.Commands;
using AlanMocek.LifeLog.Application.Activities.DTOs;
using AlanMocek.LifeLog.Application.Activities.Queries;
using AlanMocek.LifeLog.Application.Activities.QueryHandlers;
using AlanMocek.LifeLog.Application.Activities.Services;
using AlanMocek.LifeLog.Core.Activities.Services;
using AlanMocek.LifeLog.Data.Repositories;
using AlanMocek.LifeLog.Infrastructure.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities
{
    public static class RegisterActivitiesServicesExtension
    {
        public static IServiceCollection AddActivitiesServices(
             this IServiceCollection services)
        {
            // Application
            services.AddScoped<IQueryHandler<GetActivityForActivitiesPanelById, ActivityForActivitiesPanel>, GetActivityForActivitiesPanelByIdHandler>();
            services.AddScoped<IQueryHandler<BrowseActivitiesForActivitiesPanel, IEnumerable<ActivityForActivitiesPanel>>, BrowseActivitiesForActivitiesPanelHandler>();
            services.AddScoped<IQueryHandler<BrowseActivitiesForDayRecordPanel, IEnumerable<ActivityForDayRecordPanel>>, BrowseActivitiesForDayRecordPanelHandler>();

            services.AddScoped<ICommandHandler<CreateActivity>, CreateActivityHandler>();
            services.AddScoped<ICommandHandler<DeleteActivity>, DeleteActivityHandler>();

            services.AddScoped<ActivityForActivitiesPanelMapper>();


            // Core
            services.AddScoped<ActivitiesCreator>();
            services.AddScoped<ActivitiesFactory>();
            
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();

            return services;
        }
    }
}
