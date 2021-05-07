using AlanMocek.LifeLog.Application.Activities.Commands;
using AlanMocek.LifeLog.Client.Application.Services;
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
    public class ActivitiesPanelCreateActivityDialog : PanelDialogViewModel
    {
        private readonly IDispatcher _dispatcher;
        private readonly AvailableActivityTypeItemsGetter _availableActivityTypeItemsGetter;


        private string _newActivityName;
        private AvailableActivityTypeItem _newActivityType;


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
        public AvailableActivityTypeItem NewActivityTypeItem
        {
            get => _newActivityType;
            set
            {
                _newActivityType = value;
                RaisePropertyChanged(nameof(NewActivityTypeItem));
            }
        }


        public List<AvailableActivityTypeItem> AvailableActivityTypeItems { get; private set; }


        public string ErrorMessage { get; private set; }


        public ICommand CreateActivityCommand { get; private set; }
        public ICommand CloseDialogCommand { get; private set; }


        public ActivitiesPanelCreateActivityDialog(
            IDispatcher dispatcher,
            AvailableActivityTypeItemsGetter availableActivityTypeItemsGetter)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _availableActivityTypeItemsGetter = availableActivityTypeItemsGetter ?? throw new ArgumentNullException(nameof(availableActivityTypeItemsGetter));


            _newActivityName = string.Empty;
            _newActivityType = null;


            AvailableActivityTypeItems = new List<AvailableActivityTypeItem>();


            CreateActivityCommand = new AsyncCommand(CreateActivityCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            CloseDialogCommand = new AsyncCommand(CloseDialogExectuion, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public void Initialize()
        {
            var availableTypeItems = _availableActivityTypeItemsGetter.GetAll();
            foreach(var availableTypeItem in availableTypeItems)
            {
                AvailableActivityTypeItems.Add(availableTypeItem);
            }
        }


        private async Task CreateActivityCommandExecutionAsync(object parameter)
        {
            var createActivityCommand = new CreateActivity(Guid.NewGuid(), NewActivityName, NewActivityTypeItem.Type);
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

    public class AvailableActivityTypeItem : ViewModel 
    { 
        public string Type { get; private set; }
        public string Name { get; private set; }


        public AvailableActivityTypeItem()
        {

        }


        public void Initialize(string type, string name)
        {
            Type = type;
            Name = name;
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
