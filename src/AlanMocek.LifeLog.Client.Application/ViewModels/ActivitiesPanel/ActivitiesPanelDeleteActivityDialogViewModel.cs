﻿using AlanMocek.LifeLog.Application.Activities.Commands;
using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.Types;
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
    public class ActivitiesPanelDeleteActivityDialogViewModel : PanelDialogViewModel
    {
        private readonly IDispatcher _dispatcher;


        public event Action DialogClosed;
        public event Action<ActivityDeletedEventArgs> ActivityDeleted;


        public ActivityViewModel ActivityToDelete { get; private set; }


        public ICommand CancelActivityDeletionCommand { get; private set; }
        public ICommand ConfirmActivityDeletionCommand { get; private set; }


        public ActivitiesPanelDeleteActivityDialogViewModel(
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));


            CancelActivityDeletionCommand = new AsyncCommand(CancelActivityDeletionCommandExecution, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            ConfirmActivityDeletionCommand = new AsyncCommand(ConfirmActivityDeletionCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public void Initialize(ActivityViewModel activityToDelete)
        {
            ActivityToDelete = activityToDelete;
        }


        private Task CancelActivityDeletionCommandExecution(object parameter)
        {
            DialogClosed?.Invoke();
            return Task.CompletedTask;
        }

        private async Task ConfirmActivityDeletionCommandExecutionAsync(object paramter)
        {
            var deleteActivityCommand = new DeleteActivity(ActivityToDelete.ActivityId);

            var deleteActivityCommandResult = await _dispatcher.DispatchCommandAndGetResultAsync(deleteActivityCommand);

            if(deleteActivityCommandResult.Successful == false)
            {
                // TODO
            }

            ActivityDeleted?.Invoke(new ActivityDeletedEventArgs(ActivityToDelete.ActivityId));
        }
    }


    public class ActivityDeletedEventArgs : EventArgs
    {
        public Guid DeletedActivityId { get; private set; }


        public ActivityDeletedEventArgs(Guid deletedActivityId)
        {
            DeletedActivityId = deletedActivityId;
        }
    }
}
