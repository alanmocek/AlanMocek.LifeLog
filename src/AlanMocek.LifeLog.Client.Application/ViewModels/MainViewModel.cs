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

namespace AlanMocek.LifeLog.Client.Application.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly LifeLogContext _lifeLogContext;


        public PanelViewModel CurrentPanelViewModel { get; private set; }
        public bool IsApplicationInitialized { get; private set; }


        public ICommand InitializeApplicationCommand { get; private set; }


        public MainViewModel(
            IServiceProvider serviceProvider,
            LifeLogContext dbContext)
        {
            _serviceProvider = serviceProvider;
            _lifeLogContext = dbContext;

            IsApplicationInitialized = false;

            InitializeApplicationCommand = new AsyncCommand(InitializeApplicationCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
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
            var primaryPanel = _serviceProvider.GetRequiredService<ActivitiesPanelViewModel>();
            await primaryPanel.InitializePanelAsync();
            CurrentPanelViewModel = primaryPanel;
            IsApplicationInitialized = true;
            RaisePropertyChanged(nameof(CurrentPanelViewModel));
            RaisePropertyChanged(nameof(IsApplicationInitialized));
        }
    }
}
