using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AlanMocek.LifeLog.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using AlanMocek.LifeLog.Infrastructure.Types;

namespace AlanMocek.LifeLog.Client.Application.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly LifeLogContext _lifeLogContext;
        private readonly NavigationService _navigationService;


        public PanelViewModel CurrentPanelViewModel { get; private set; }
        
        
        public bool IsApplicationInitialized { get; private set; }


        public ICommand InitializeApplicationCommand { get; private set; }
        public ICommand ChangePanelCommand { get; private set; }


        public MainViewModel(
            LifeLogContext dbContext,
            NavigationService navigationService)
        {
            _lifeLogContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService)); ;

            IsApplicationInitialized = false;

            InitializeApplicationCommand = new AsyncCommand(InitializeApplicationCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            ChangePanelCommand = new AsyncCommand(ChangePanelCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());


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
            
            IsApplicationInitialized = true;
        }

        private async Task ChangePanelCommandExecutionAsync(object parameter)
        {
            var panelType = (string)parameter;

            switch(panelType)
            {
                case "calendar":
                    {
                        await _navigationService.ChangePanelAsync(typeof(CalendarPanel.CalendarPanel));
                        break;
                    }

                case "activities":
                    {
                        await _navigationService.ChangePanelAsync(typeof(ActivitiesPanel.ActivitiesPanel));
                        break;
                    }

                default:
                    {
                        throw new ArgumentException($"Panel of type {panelType} is not implemented.");
                    }
            }
        }

        private async Task InitializeDatabaseAsync()
        {
            await _lifeLogContext.Database.MigrateAsync();
        }

        private async Task InitializePrimaryPanelAsync()
        {
            await _navigationService.ChangePanelAsync(typeof(CalendarPanel.CalendarPanel));
        }

        private Task OnCurrentPanelChanged()
        {
            CurrentPanelViewModel = _navigationService.CurrentPanel;
            RaisePropertyChanged(nameof(CurrentPanelViewModel));
            return Task.CompletedTask;
        }
    }
}
