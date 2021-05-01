﻿using AlanMocek.LifeLog.Application.DayRecords.CommandHandlers;
using AlanMocek.LifeLog.Application.DayRecords.Commands;
using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Application.DayRecords.QueryHandlers;
using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Core.DayRecords.Services;
using AlanMocek.LifeLog.Data.Repositories;
using AlanMocek.LifeLog.Infrastructure.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords
{
    public static class RegisterDayRecordsServicesExtension
    {
        public static IServiceCollection AddDayRecordsServices(
             this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetDayRecordCardsByYearAndMonth, IEnumerable<DayRecordCardViewModel>>, GetDayRecordCardsByYearAndMonthHandler>();
            services.AddScoped<IQueryHandler<GetDayRecordCardById, DayRecordCardViewModel>, GetDayRecordCardByIdHandler>();
            services.AddScoped<IQueryHandler<GetDayRecordById, DayRecordViewModel>, GetDayRecordByIdHandler>();


            services.AddScoped<ICommandHandler<CreateDayRecord>, CreateDayRecordHandler>();


            services.AddScoped<IDayRecordsRepository, DayRecordsRepository>();
            services.AddScoped<DayRecordsCreator>();


            return services;
        }
    }
}