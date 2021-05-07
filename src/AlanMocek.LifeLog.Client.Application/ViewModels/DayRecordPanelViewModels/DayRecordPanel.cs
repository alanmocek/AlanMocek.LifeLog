using AlanMocek.LifeLog.Application.ActivityRecords.Queries;
using AlanMocek.LifeLog.Application.DayRecords.Queries;
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
using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Client.Application.Services;
using System.Windows.Data;
using AlanMocek.LifeLog.Application.DayRecords.DTOs;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanelViewModels
{
    public class DayRecordPanel : PanelViewModel
    {
        private readonly TemporaryApplicationValues _temporaryApplicationValues;
        private readonly IDispatcher _dispatcher;
        private readonly NavigationService _navigationService;
        private readonly IServiceProvider _serviceProvider;
        private readonly DayRecordPanelActivityRecordItemGetter _dayRecordPanelActivityRecordItemGetter;

       
        public PanelDialogViewModel CurrentDialog { get; private set; }
        public DayRecordForDayRecordPanel DayRecord { get; private set; }
        public ObservableCollection<DayRecordPanelActivityRecordItem> ActivityRecords { get; private set; }


        public ICommand OpenAddActivityRecordDialogCommand { get; private set; }


        public DayRecordPanel(
            TemporaryApplicationValues temporaryApplicationValues,
            IDispatcher dispatcher,
            NavigationService navigationService,
            IServiceProvider serviceProvider,
            DayRecordPanelActivityRecordItemGetter dayRecordPanelActivityRecordItemGetter)
        {
            _temporaryApplicationValues = temporaryApplicationValues ?? throw new ArgumentNullException(nameof(temporaryApplicationValues));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _dayRecordPanelActivityRecordItemGetter = dayRecordPanelActivityRecordItemGetter ?? throw new ArgumentNullException(nameof(dayRecordPanelActivityRecordItemGetter));


            CurrentDialog = null;
            DayRecord = null;
            ActivityRecords = new ObservableCollection<DayRecordPanelActivityRecordItem>();


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
                throw new Exception("No day record id found to open day record panel.");
            }

            var getDayRecordQuery = new GetDayRecordForDayRecordPanelById(_temporaryApplicationValues.DayRecordIdToOpen.Value);
            var getDayRecordQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<DayRecordForDayRecordPanel, GetDayRecordForDayRecordPanelById>(getDayRecordQuery);

            if (getDayRecordQueryResult.Successful == false)
            {
                await _navigationService.ChangePanelAsync(typeof(CalendarPanel.CalendarPanel));
            }

            DayRecord = getDayRecordQueryResult.Result;
            RaisePropertyChanged(nameof(DayRecord));
        }

        private async Task LoadActivityRecords()
        {
            var browseActivityRecordsWithActivityQuery = new BrowseActivityRecordsForDayRecordPanel(DayRecord.Id);
            var getActivityRecordsQueryResult = 
                await _dispatcher.DispatchQueryAndGetResultAsync<IEnumerable<ActivityRecordForDayRecordPanel>, BrowseActivityRecordsForDayRecordPanel>(browseActivityRecordsWithActivityQuery);

            if (getActivityRecordsQueryResult.Successful == false)
            {
                // TODO - show error notyfication
                return;
            }

            foreach(var activityRecord in getActivityRecordsQueryResult.Result)
            {
                await AddActivityRecordItemAsync(activityRecord);
            }
        }

        private async Task OpenAddActivityRecordDialogCommandExecutionAsync(object parameter)
        {
            var addActivityRecordDialog = _serviceProvider.GetRequiredService<DayRecordPanelAddActivityRecordDialog>();
            addActivityRecordDialog.DialogClosed += OnDialogClosed;
            addActivityRecordDialog.ActivityRecordCreated += OnActivityRecordCreatedAsync;
            await addActivityRecordDialog.InitializeDialogAsync(this.DayRecord.Id);
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

            await AddActivityRecordItemAsync(getCreatedActivityRecordResult.Result);
            OnDialogClosed();
        }

        private async Task OnActivityRecordItemOrderChangedAsync()
        {
            ActivityRecords.Clear();
            await LoadActivityRecords(); // TODO to change
        }

        private async Task OnActivityRecordDeletedAsync(ActivityRecordDeletedEventArgs args)
        {
            var activityRecordItem = ActivityRecords.FirstOrDefault(activityRecordItem => activityRecordItem.ActivityRecord.Id == args.ActivityRecordId);
            ActivityRecords.Remove(activityRecordItem);
            await OnActivityRecordItemOrderChangedAsync();
        }

        private async Task AddActivityRecordItemAsync(ActivityRecordForDayRecordPanel activityRecord)
        {
            var activityRecordItem = _dayRecordPanelActivityRecordItemGetter.GetFromActivityType(activityRecord.Activity.Type);
            activityRecordItem.OrderChanged += OnActivityRecordItemOrderChangedAsync;
            activityRecordItem.Deleted += OnActivityRecordDeletedAsync;
            await activityRecordItem.InitializeAsync(activityRecord);
            ActivityRecords.Add(activityRecordItem);
        }
    }
}
