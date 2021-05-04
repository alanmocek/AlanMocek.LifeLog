using AlanMocek.LifeLog.Application.Activities.Queries;
using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Client.Application.Services;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanel
{
    public class DayRecordAddActivityRecordDialogViewModel : PanelDialogViewModel
    {
        private readonly IDispatcher _dispatcher;
        private readonly ActivityRecordValueViewModelsFactory _activityRecordValueViewModelsFactory;
        private readonly CreateActivityRecordCommandFactory _createActivityRecordCommandFactory;


        private Guid _dayRecordId;
        private ActivityForDayRecordPanel _selectedActivity;


        public event Action DialogClosed;
        public event Func<ActivityRecordCreatedEventArgs, Task> ActivityRecordCreated;


        public ActivityForDayRecordPanel SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                _selectedActivity = value;
                RaisePropertyChanged(nameof(SelectedActivity));
                UpdateActivityValueWhenSelectedActivityChanged();
            }
        }

        public ActivityRecordValueViewModel SelectedActivityRecordValue { get; private set; }

        public ObservableCollection<ActivityForDayRecordPanel> AvailableActivities { get; private set; }
        
        
        public ICommand CloseDialogCommand { get; private set; }
        public ICommand CreateActivityRecordCommand { get; private set; }


        public DayRecordAddActivityRecordDialogViewModel(
            IDispatcher dispatcher,
            ActivityRecordValueViewModelsFactory activityRecordValueViewModelsFactory,
            CreateActivityRecordCommandFactory createActivityRecordCommandFactory)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _activityRecordValueViewModelsFactory = activityRecordValueViewModelsFactory ?? throw new ArgumentNullException(nameof(activityRecordValueViewModelsFactory));
            _createActivityRecordCommandFactory = createActivityRecordCommandFactory ?? throw new ArgumentNullException(nameof(_createActivityRecordCommandFactory));


            SelectedActivity = null;
            AvailableActivities = new ObservableCollection<ActivityForDayRecordPanel>();
            SelectedActivityRecordValue = null;


            CloseDialogCommand = new AsyncCommand(CloseDialogCommandExecution, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            CreateActivityRecordCommand = new AsyncCommand(CreateActivityRecordCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public async Task InitializeDialogAsync(Guid dayRecordId)
        {
            _dayRecordId = dayRecordId;
            await LoadAvailableActivitiesAsync();
        }


        private async Task LoadAvailableActivitiesAsync()
        {
            var getAvailableActivitiesQuery = new BrowseActivitiesForDayRecordPanel();
            var getAvailableActivitiesQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<IEnumerable<ActivityForDayRecordPanel>, BrowseActivitiesForDayRecordPanel>(getAvailableActivitiesQuery);

            if(getAvailableActivitiesQueryResult.Successful == false)
            {
                // TODO - show error notyfication
                return;
            }

            foreach(var availableActivity in getAvailableActivitiesQueryResult.Result)
            {
                AvailableActivities.Add(availableActivity);
            }
        }

        private Task CloseDialogCommandExecution(object parameter)
        {
            DialogClosed?.Invoke();
            
            return Task.CompletedTask;
        }

        private async Task CreateActivityRecordCommandExecutionAsync(object parameter)
        {
            if(SelectedActivity is null)
            {
                // TODO - show error notyfication
                return;
            }

            var createActivityRecordCommand = _createActivityRecordCommandFactory.FactorCreateActivityRecordCommand(Guid.NewGuid(),
                _dayRecordId, SelectedActivity.ActivityId, SelectedActivity.ActivityType, SelectedActivityRecordValue);

            var createActivityRecordCommandResult = await _dispatcher.DispatchCommandAndGetResultAsync(createActivityRecordCommand);

            if(createActivityRecordCommandResult.Successful == false)
            {
                return;
            }

            await ActivityRecordCreated?.Invoke(new ActivityRecordCreatedEventArgs(createActivityRecordCommand.Id));
        }

        private void UpdateActivityValueWhenSelectedActivityChanged()
        {
            if(SelectedActivity is null || SelectedActivity.ActivityHasValue == false)
            {
                SelectedActivityRecordValue = null;
                RaisePropertyChanged(nameof(SelectedActivityRecordValue));
                return;
            }

            SelectedActivityRecordValue = _activityRecordValueViewModelsFactory.FactorActivityRecordValueViewModelForActivityViewModel(SelectedActivity.ActivityType);
            RaisePropertyChanged(nameof(SelectedActivityRecordValue));
        }
    }


    public class ActivityRecordCreatedEventArgs : EventArgs
    {
        public Guid CreatedActivityRecordId { get; private set; }


        public ActivityRecordCreatedEventArgs(Guid activityRecordId)
        {
            CreatedActivityRecordId = activityRecordId;
        }
    }

}
