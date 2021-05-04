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


        private bool _isInitialized;


        public PanelDialogViewModel CurrentDialog { get; private set; }
        public ObservableCollection<ActivityForActivitiesPanel> Activities { get; private set; }


        public ICommand OpenCreateActivityDialogCommand { get; private set; }
        public ICommand OpenDeleteActivityDialogCommand { get; private set; }


        public ActivitiesPanelViewModel(
            IDispatcher dispatcher,
            IServiceProvider serviceProvider)
        {
            _dispatcher = dispatcher;
            _serviceProvider = serviceProvider;


            _isInitialized = false;

            CurrentDialog = null;
            Activities = new ObservableCollection<ActivityForActivitiesPanel>();


            OpenCreateActivityDialogCommand = new AsyncCommand(OpenCreateActivityDialogCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            OpenDeleteActivityDialogCommand = new AsyncCommand(OpenDeleteActivityDialogCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public override async Task InitializeAsync()
        {
            if (_isInitialized == true)
                return;

            await LoadActivitiesAsync();
            _isInitialized = true;
        }

        private async Task LoadActivitiesAsync()
        {
            var getAllActivitiesQuery = new BrowseActivitiesForActivitiesPanel();
            var getAllActivitiesResult = await _dispatcher.DispatchQueryAndGetResultAsync<IEnumerable<ActivityForActivitiesPanel>, BrowseActivitiesForActivitiesPanel>(getAllActivitiesQuery);
            
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

        private Task OpenDeleteActivityDialogCommandExecutionAsync(object parameter)
        {
            var deleteActivityDialog = _serviceProvider.GetRequiredService<ActivitiesPanelDeleteActivityDialogViewModel>();
            var activityToDelete = (parameter as ActivityForActivitiesPanel);
            deleteActivityDialog.Initialize(activityToDelete.ActivityId, activityToDelete.ActivityName);
            deleteActivityDialog.DialogClosed += OnDialogClosed;
            deleteActivityDialog.ActivityDeleted += OnActivityDeleted;
            CurrentDialog = deleteActivityDialog;
            RaisePropertyChanged(nameof(CurrentDialog));
            return Task.CompletedTask;
        }

        private void OnDialogClosed()
        {
            CurrentDialog = null;
            RaisePropertyChanged(nameof(CurrentDialog));
        }

        private void OnActivityDeleted(ActivityDeletedEventArgs args)
        {
            CurrentDialog = null;
            RaisePropertyChanged(nameof(CurrentDialog));

            var deletedActivity = Activities.FirstOrDefault(activity => activity.ActivityId == args.DeletedActivityId);
            if (deletedActivity is null)
                return;

            Activities.Remove(deletedActivity);
        }

        private async Task OnActivityCreatedAsync(ActivityCreatedEventArgs args)
        {
            CurrentDialog = null;
            RaisePropertyChanged(nameof(CurrentDialog));

            var getCreatedActivityQuery = new GetActivityForActivitiesPanelById(args.CreatedActivityId);
            var getCreatedActivityQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<ActivityForActivitiesPanel, GetActivityForActivitiesPanelById> (getCreatedActivityQuery);

            if(getCreatedActivityQueryResult.Successful == false)
            {
                // TODO
            }

            Activities.Add(getCreatedActivityQueryResult.Result);
        }
    }
}
