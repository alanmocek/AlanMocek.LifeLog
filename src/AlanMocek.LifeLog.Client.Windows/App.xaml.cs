using AlanMocek.LifeLog.Application.Activities;
using AlanMocek.LifeLog.Client.Application.ViewModels;
using AlanMocek.LifeLog.Client.Application.ViewModels.ActivitiesPanel;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
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
                services.AddDbContext<LifeLogContext>(options => options.UseSqlite("Data Source = UserData.db"));

                services.AddScoped<IDispatcher, Dispatcher>();

                services.AddScoped<MainViewModel>();

                services.AddScoped<ActivitiesPanelViewModel>();

                services.AddScoped<MainWindow>();

                services.AddActivitiesServices();

                services.AddTransient<ActivitiesPanelCreateActivityDialogViewModel>();
                services.AddTransient<ActivitiesPanelDeleteActivityDialogViewModel>();
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
