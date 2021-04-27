using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.Types;
using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.ActivitiesPanel
{
    public class ActivitiesPanelDeleteActivityDialogViewModel : PanelDialogViewModel
    {
        private readonly IDispatcher _dispatcher;


        public event Action DialogClosed;


        public ActivityViewModel ActivityToDelete { get; private set; }


        public ICommand CancelActivityDeletionCommand { get; private set; }
        public ICommand ConfirmActivityDeletionCommand { get; private set; }


        public ActivitiesPanelDeleteActivityDialogViewModel(
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }


        public void Initialize(ActivityViewModel activityToDelete)
        {
            ActivityToDelete = activityToDelete;
        }


        
    }
}
