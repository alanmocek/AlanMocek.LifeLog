﻿using AlanMocek.LifeLog.Application.Activities;
using AlanMocek.LifeLog.Application.ActivityRecords;
using AlanMocek.LifeLog.Application.DayRecords;
using AlanMocek.LifeLog.Client.Application.Types;
using AlanMocek.LifeLog.Client.Application.ViewModels;
using AlanMocek.LifeLog.Client.Application.ViewModels.ActivitiesPanel;
using AlanMocek.LifeLog.Client.Application.ViewModels.CalendarPanel;
using AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanel;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AlanMocek.LifeLog.Client.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly IHost _host;

        //public IConfiguration Configuration { get; private set; }


        public App()
        {
            _host = CreateHostBuilder(Array.Empty<string>()).Build();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Add core services
                services.AddDbContext<LifeLogContext>(options => options.UseSqlite("Data Source = UserData.db"));
                services.AddScoped<IDispatcher, Dispatcher>();


                // Add main panels view models
                services.AddScoped<ActivitiesPanelViewModel>();
                services.AddScoped<CalendarPanelViewModel>();
                services.AddScoped<DayRecordPanelViewModel>();


                // Add main window
                services.AddScoped<MainWindow>();
                services.AddScoped<MainViewModel>();


                // Add app main services
                services.AddActivitiesServices();
                services.AddDayRecordsServices();
                services.AddActivityRecordsServices();
                

                // Add dialogs view models
                services.AddTransient<ActivitiesPanelCreateActivityDialogViewModel>();
                services.AddTransient<ActivitiesPanelDeleteActivityDialogViewModel>();

                // Add client services
                services.AddSingleton<NavigationService>();
                services.AddSingleton<TemporaryApplicationValues>();
            });

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainViewModel = _host.Services.GetService<MainViewModel>();
            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromMilliseconds(100));
            }
        }
    }
}
