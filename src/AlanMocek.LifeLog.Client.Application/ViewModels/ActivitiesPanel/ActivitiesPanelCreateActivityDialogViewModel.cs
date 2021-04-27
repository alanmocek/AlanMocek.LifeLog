using AlanMocek.LifeLog.Application.Activities.Commands;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.ActivitiesPanel
{
    public class ActivitiesPanelCreateActivityDialogViewModel : PanelDialogViewModel
    {
        private readonly IDispatcher _dispatcher;


        private string _newActivityName;
        private string _newActivityType;


        public event Action DialogClosed;
        public event Func<ActivityCreatedEventArgs,Task> ActivityCreated;


        public string NewActivityName
        {
            get => _newActivityName;
            set
            {
                _newActivityName = value;
                RaisePropertyChanged(nameof(NewActivityName));
            }
        }
        public string NewActivityType
        {
            get => _newActivityType;
            set
            {
                _newActivityType = value;
                RaisePropertyChanged(nameof(NewActivityType));
            }
        }


        public List<string> AvailableActivityTypes { get; private set; }


        public string ErrorMessage { get; private set; }


        public ICommand CreateActivityCommand { get; private set; }
        public ICommand CloseDialogCommand { get; private set; }


        public ActivitiesPanelCreateActivityDialogViewModel(
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;


            _newActivityName = string.Empty;
            _newActivityType = null;


            AvailableActivityTypes = new List<string>()
            {
                "activity_time",
                "activity_clock",
                "activity_occurrence",
                "activity_quantity"
            };


            CreateActivityCommand = new AsyncCommand(CreateActivityCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            CloseDialogCommand = new AsyncCommand(CloseDialogExectuion, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        private async Task CreateActivityCommandExecutionAsync(object parameter)
        {
            var createActivityCommand = new CreateActivity(Guid.NewGuid(), NewActivityName, NewActivityType);
            var createActivityCommandResult = await _dispatcher.DispatchCommandAndGetResultAsync(createActivityCommand);

            if(createActivityCommandResult.Successful == false)
            {
                // TODO
                ErrorMessage = createActivityCommandResult.ErrorCode;
            }

            await ActivityCreated?.Invoke(new ActivityCreatedEventArgs(createActivityCommand.Id));
        }

        private Task CloseDialogExectuion(object parameter)
        {
            DialogClosed?.Invoke();
            return Task.CompletedTask;
        }
    }


    public class ActivityCreatedEventArgs : EventArgs
    { 
        public Guid CreatedActivityId { get; private set; }


        public ActivityCreatedEventArgs(Guid createdActivityId)
        {
            CreatedActivityId = createdActivityId;
        }
    }
}
