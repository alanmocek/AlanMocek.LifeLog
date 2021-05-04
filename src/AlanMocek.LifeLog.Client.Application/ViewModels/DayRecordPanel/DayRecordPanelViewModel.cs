using AlanMocek.LifeLog.Application.ActivityRecords.Queries;
using AlanMocek.LifeLog.Application.ActivityRecords.ViewModels;
using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Client.Application.Types;
using AlanMocek.LifeLog.Client.Application.ViewModels.CalendarPanel;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.Types;
using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanel
{
    public class DayRecordPanelViewModel : PanelViewModel
    {
        private readonly TemporaryApplicationValues _temporaryApplicationValues;
        private readonly IDispatcher _dispatcher;
        private readonly NavigationService _navigationService;
        private readonly IServiceProvider _serviceProvider;

       
        public PanelDialogViewModel CurrentDialog { get; private set; }
        public DayRecordForDayRecordPanel DayRecord { get; private set; }
        public ObservableCollection<ActivityRecordForDayRecordPanel> ActivityRecords { get; private set; }


        public ICommand OpenAddActivityRecordDialogCommand { get; private set; }


        public DayRecordPanelViewModel(
            TemporaryApplicationValues temporaryApplicationValues,
            IDispatcher dispatcher,
            NavigationService navigationService,
            IServiceProvider serviceProvider)
        {
            _temporaryApplicationValues = temporaryApplicationValues ?? throw new ArgumentNullException(nameof(temporaryApplicationValues));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));


            CurrentDialog = null;
            DayRecord = null;
            ActivityRecords = new ObservableCollection<ActivityRecordForDayRecordPanel>();


            OpenAddActivityRecordDialogCommand = new AsyncCommand(OpenAddActivityRecordDialogCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }

         
        public override async Task InitializeAsync()
        {
            await LoadDayRecord();
            await LoadActivityRecords();
        }


        private async Task LoadDayRecord()
        {
            if (_temporaryApplicationValues.DayRecordIdToOpen.HasValue == false)
            {
                throw new Exception("No day record id find to open day record panel.");
            }

            var getDayRecordQuery = new GetDayRecordForDayRecordPanelById(_temporaryApplicationValues.DayRecordIdToOpen.Value);
            var getDayRecordQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<DayRecordForDayRecordPanel, GetDayRecordForDayRecordPanelById>(getDayRecordQuery);

            if (getDayRecordQueryResult.Successful == false)
            {
                await _navigationService.ChangePanelAsync(typeof(CalendarPanelViewModel));
            }

            DayRecord = getDayRecordQueryResult.Result;
            RaisePropertyChanged(nameof(DayRecord));
        }

        private async Task LoadActivityRecords()
        {
            var browseActivityRecordsWithActivityQuery = new BrowseActivityRecordsForDayRecordPanel(DayRecord.DayRecordId);
            var getActivityRecordsQueryResult = 
                await _dispatcher.DispatchQueryAndGetResultAsync<IEnumerable<ActivityRecordForDayRecordPanel>, BrowseActivityRecordsForDayRecordPanel>(browseActivityRecordsWithActivityQuery);

            if (getActivityRecordsQueryResult.Successful == false)
            {
                // TODO - show error notyfication
                return;
            }

            foreach(var activityRecord in getActivityRecordsQueryResult.Result)
            {
                ActivityRecords.Add(activityRecord);
            }
        }

        private async Task OpenAddActivityRecordDialogCommandExecutionAsync(object parameter)
        {
            var addActivityRecordDialog = _serviceProvider.GetRequiredService<DayRecordAddActivityRecordDialogViewModel>();
            addActivityRecordDialog.DialogClosed += OnDialogClosed;
            addActivityRecordDialog.ActivityRecordCreated += OnActivityRecordCreatedAsync;
            await addActivityRecordDialog.InitializeDialogAsync(this.DayRecord.DayRecordId);
            CurrentDialog = addActivityRecordDialog;
            RaisePropertyChanged(nameof(CurrentDialog));
        }

        private void OnDialogClosed()
        {
            CurrentDialog = null;
            RaisePropertyChanged(nameof(CurrentDialog));
        }

        private async Task OnActivityRecordCreatedAsync(ActivityRecordCreatedEventArgs args)
        {
            
            var getCreatedActivityRecord= new GetActivityRecordForDayRecordPanelById(args.CreatedActivityRecordId);
            var getCreatedActivityRecordResult = await _dispatcher.DispatchQueryAndGetResultAsync<ActivityRecordForDayRecordPanel, GetActivityRecordForDayRecordPanelById>(getCreatedActivityRecord);

            if(getCreatedActivityRecordResult.Successful == false)
            {
                // TODO - show error notyfication
                return;
            }

            ActivityRecords.Add(getCreatedActivityRecordResult.Result);
            OnDialogClosed();
        }
    }
}
