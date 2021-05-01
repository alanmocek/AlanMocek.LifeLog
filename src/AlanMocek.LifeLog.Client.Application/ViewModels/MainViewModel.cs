using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using AlanMocek.LifeLog.Client.Application.ViewModels.ActivitiesPanel;
using AlanMocek.LifeLog.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using AlanMocek.LifeLog.Client.Application.ViewModels.CalendarPanel;
using AlanMocek.LifeLog.Infrastructure.Types;

namespace AlanMocek.LifeLog.Client.Application.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly LifeLogContext _lifeLogContext;
        private readonly NavigationService _navigationService;


        public PanelViewModel CurrentPanelViewModel { get; private set; }
        
        
        public bool IsApplicationInitialized { get; private set; }


        public ICommand InitializeApplicationCommand { get; private set; }


        public MainViewModel(
            IServiceProvider serviceProvider,
            LifeLogContext dbContext,
            NavigationService navigationService)
        {
            _serviceProvider = serviceProvider;
            _lifeLogContext = dbContext;
            _navigationService = navigationService;

            IsApplicationInitialized = false;

            InitializeApplicationCommand = new AsyncCommand(InitializeApplicationCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());

            _navigationService.CurrentPanelChanged += OnCurrentPanelChanged;
        }


        private async Task InitializeApplicationCommandExecutionAsync(object parameter)
        {
            if (IsApplicationInitialized == true)
            {
                return;
            }

            await InitializeDatabaseAsync();
            await InitializePrimaryPanelAsync();
        }


        private async Task InitializeDatabaseAsync()
        {
            await _lifeLogContext.Database.MigrateAsync();
        }

        private async Task InitializePrimaryPanelAsync()
        {
            await _navigationService.ChangePanelAsync(typeof(CalendarPanelViewModel));
            //var primaryPanel = _serviceProvider.GetRequiredService<ActivitiesPanelViewModel>();
            //var primaryPanel = _serviceProvider.GetRequiredService<CalendarPanelViewModel>();
            //await primaryPanel.InitializePanelAsync();
            //CurrentPanelViewModel = primaryPanel;
            //IsApplicationInitialized = true;
            //RaisePropertyChanged(nameof(CurrentPanelViewModel));
            //RaisePropertyChanged(nameof(IsApplicationInitialized));
        }

        private Task OnCurrentPanelChanged()
        {
            CurrentPanelViewModel = _navigationService.CurrentPanel;
            RaisePropertyChanged(nameof(CurrentPanelViewModel));
            return Task.CompletedTask;
        }
    }
}
