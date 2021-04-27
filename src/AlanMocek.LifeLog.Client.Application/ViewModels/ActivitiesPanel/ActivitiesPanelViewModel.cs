using AlanMocek.LifeLog.Application.Activities.Commands;
using AlanMocek.LifeLog.Application.Activities.Queries;
using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.ActivitiesPanel
{
    public class ActivitiesPanelViewModel : PanelViewModel
    {
        private readonly IDispatcher _dispatcher;
        private readonly IServiceProvider _serviceProvider;


        public PanelDialogViewModel CurrentDialog { get; private set; }
        public ObservableCollection<ActivityViewModel> Activities { get; private set; }


        public ICommand OpenCreateActivityDialogCommand { get; private set; }


        public ActivitiesPanelViewModel(
            IDispatcher dispatcher,
            IServiceProvider serviceProvider)
        {
            _dispatcher = dispatcher;
            _serviceProvider = serviceProvider;


            CurrentDialog = null;
            Activities = new ObservableCollection<ActivityViewModel>();


            OpenCreateActivityDialogCommand = new AsyncCommand(OpenCreateActivityDialogCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public async Task InitializePanelAsync()
        {
            await LoadActivitiesAsync();
        }


        private async Task LoadActivitiesAsync()
        {
            var getAllActivitiesQuery = new GetAllActivities();
            var getAllActivitiesResult = await _dispatcher.DispatchQueryAndGetResultAsync<IEnumerable<ActivityViewModel>, GetAllActivities>(getAllActivitiesQuery);
            
            if(getAllActivitiesResult.Successful == false)
            {
                // TODO
                return;
            }
            
            foreach(var activityViewModel in getAllActivitiesResult.Result)
            {
                Activities.Add(activityViewModel);
            }
        }


        /// <summary>
        /// Execution part of <see cref="OpenCreateActivityDialogCommand"/>.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private Task OpenCreateActivityDialogCommandExecutionAsync(object parameter)
        {
            var createActivityDialog = _serviceProvider.GetRequiredService<ActivitiesPanelCreateActivityDialogViewModel>();
            createActivityDialog.DialogClosed += OnDialogClosed;
            createActivityDialog.ActivityCreated += OnActivityCreatedAsync;
            CurrentDialog = createActivityDialog;
            RaisePropertyChanged(nameof(CurrentDialog));
            return Task.CompletedTask;
        }

        private void OnDialogClosed()
        {
            CurrentDialog = null;
            RaisePropertyChanged(nameof(CurrentDialog));
        }

        private async Task OnActivityCreatedAsync(ActivityCreatedEventArgs args)
        {
            CurrentDialog = null;
            RaisePropertyChanged(nameof(CurrentDialog));

            var getCreatedActivityQuery = new GetActivityById(args.CreatedActivityId);
            var getCreatedActivityQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<ActivityViewModel, GetActivityById> (getCreatedActivityQuery);

            if(getCreatedActivityQueryResult.Successful == false)
            {
                // TODO
            }

            Activities.Add(getCreatedActivityQueryResult.Result);
        }
    }
}
