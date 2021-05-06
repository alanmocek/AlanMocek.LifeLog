using AlanMocek.LifeLog.Application.Activities.DTOs;
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
    public class ActivitiesPanelActivityItem : ViewModel
    {
        public ActivityForActivitiesPanel Activity { get; private set; }


        public event Func<ActivityDeletionRequestedEventArgs, Task> ActivityDeletionRequested;


        public ICommand RequestActivityDeletionCommand { get; private set; }


        public ActivitiesPanelActivityItem()
        {
            RequestActivityDeletionCommand = new AsyncCommand(RequestActivityDeletionCommandExecution, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public void Initialize(ActivityForActivitiesPanel activity)
        {
            Activity = activity;
            RaisePropertyChanged(nameof(Activity));
        }


        private async Task RequestActivityDeletionCommandExecution(object parameter)
        {
            await ActivityDeletionRequested(new ActivityDeletionRequestedEventArgs(Activity));
        }
    }


    public class ActivityDeletionRequestedEventArgs : EventArgs
    {
        public ActivityForActivitiesPanel Activity { get; private set; }


        public ActivityDeletionRequestedEventArgs(ActivityForActivitiesPanel activity)
        {
            Activity = activity;
        }
    }
}
