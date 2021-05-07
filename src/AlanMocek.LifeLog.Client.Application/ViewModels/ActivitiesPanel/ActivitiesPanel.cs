using AlanMocek.LifeLog.Application.Activities.Commands;
using AlanMocek.LifeLog.Application.Activities.Queries;
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
using AlanMocek.LifeLog.Application.Activities.DTOs;
using AlanMocek.LifeLog.Client.Application.Services;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.ActivitiesPanel
{
    public class ActivitiesPanel : PanelViewModel
    {
        private readonly IDispatcher _dispatcher;
        private readonly IServiceProvider _serviceProvider;


        private bool _isInitialized;


        public PanelDialogViewModel CurrentDialog { get; private set; }
        public ObservableCollection<ActivitiesPanelActivityItem> ActivityItems { get; private set; }


        public ICommand OpenCreateActivityDialogCommand { get; private set; }


        public ActivitiesPanel(
            IDispatcher dispatcher,
            IServiceProvider serviceProvider)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            

            _isInitialized = false;

            CurrentDialog = null;
            ActivityItems = new ObservableCollection<ActivitiesPanelActivityItem>();


            OpenCreateActivityDialogCommand = new AsyncCommand(OpenCreateActivityDialogCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
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
            
            foreach(var activity in getAllActivitiesResult.Result)
            {
                AddActivityItem(activity);
            }
        }


        private Task OpenCreateActivityDialogCommandExecutionAsync(object parameter)
        {
            var createActivityDialog = _serviceProvider.GetRequiredService<ActivitiesPanelCreateActivityDialog>();
            createActivityDialog.DialogClosed += OnDialogClosed;
            createActivityDialog.ActivityCreated += OnActivityCreatedAsync;
            createActivityDialog.Initialize();
            CurrentDialog = createActivityDialog;
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

            var deletedActivity = ActivityItems.FirstOrDefault(activityItem => activityItem.Activity.Id == args.DeletedActivityId);
            if (deletedActivity is null)
            {
                return;
            }

            ActivityItems.Remove(deletedActivity);
        }

        private async Task OnActivityCreatedAsync(ActivityCreatedEventArgs args)
        {
            OnDialogClosed();

            var getCreatedActivityQuery = new GetActivityForActivitiesPanelById(args.CreatedActivityId);
            var getCreatedActivityQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<ActivityForActivitiesPanel, GetActivityForActivitiesPanelById> (getCreatedActivityQuery);

            if(getCreatedActivityQueryResult.Successful == false)
            {
                // TODO
            }

            var createdActivity = getCreatedActivityQueryResult.Result;

            AddActivityItem(createdActivity);
        }


        private void AddActivityItem(ActivityForActivitiesPanel activity)
        {
            var activityItem = _serviceProvider.GetRequiredService<ActivitiesPanelActivityItem>();
            activityItem.ActivityDeletionRequested += OnActivityDeletionRequestedAsync;
            activityItem.Initialize(activity);
            ActivityItems.Add(activityItem);
        }

        private async Task OnActivityDeletionRequestedAsync(ActivityDeletionRequestedEventArgs args)
        {
            await OpenDeleteActivityDialognAsync(args.Activity);
        }

        private Task OpenDeleteActivityDialognAsync(ActivityForActivitiesPanel activity)
        {
            var deleteActivityDialog = _serviceProvider.GetRequiredService<ActivitiesPanelDeleteActivityDialog>();
            deleteActivityDialog.Initialize(activity.Id, activity.Name);
            deleteActivityDialog.DialogClosed += OnDialogClosed;
            deleteActivityDialog.ActivityDeleted += OnActivityDeleted;
            CurrentDialog = deleteActivityDialog;
            RaisePropertyChanged(nameof(CurrentDialog));
            return Task.CompletedTask;
        }
    }
}
