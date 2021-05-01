using AlanMocek.LifeLog.Application.DayRecords.Commands;
using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Client.Application.Types;
using AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanel;
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

namespace AlanMocek.LifeLog.Client.Application.ViewModels.CalendarPanel
{
    public class CalendarPanelViewModel : PanelViewModel
    {
        private readonly IDispatcher _dispatcher;
        private readonly NavigationService _navigationService;
        private readonly TemporaryApplicationValues _temporaryApplicationValues;


        private bool _isInitialized;
        private int _selectedYear;
        private int _selectedMonth;


        public ObservableCollection<CalendarPanelDayCardViewModel> Days { get; private set; }
        public int SelectedYear
        {
            get => _selectedYear;
            set
            {
                _selectedYear = value;
                RaisePropertyChanged(nameof(SelectedYear));
            }
        }
        public int SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                _selectedMonth = value;
                RaisePropertyChanged(nameof(SelectedMonth));
            }
        }


        public ICommand CreateDayRecordForDayCardCommand { get; private set; }
        public ICommand GoToDayRecordPanelOfDayRecordCardCommand { get; private set; }


        public CalendarPanelViewModel(
            IDispatcher dispatcher,
            NavigationService navigationService,
            TemporaryApplicationValues temporaryApplicationValues)
        {
            _dispatcher = dispatcher;
            _navigationService = navigationService;
            _temporaryApplicationValues = temporaryApplicationValues;


            Days = new ObservableCollection<CalendarPanelDayCardViewModel>();


            _isInitialized = false;

            var currentDate = DateTime.Now;
            _selectedYear = currentDate.Year;
            _selectedMonth = currentDate.Month;


            CreateDayRecordForDayCardCommand = new AsyncCommand(CreateDayRecordForDayCardCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            GoToDayRecordPanelOfDayRecordCardCommand = new AsyncCommand(GotoDayRecordPanelOfDayRecordCardCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public override async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            await LoadDaysAsync();
        }


        private async Task LoadDaysAsync()
        {
            var getDayRecordForSelectedYearAndMonthQuery = new GetDayRecordCardsByYearAndMonth(SelectedYear, SelectedMonth);
            var getDayRecordForSelectedYearAndMonthQueryResult =
                await _dispatcher.DispatchQueryAndGetResultAsync<IEnumerable<DayRecordCardViewModel>, GetDayRecordCardsByYearAndMonth>(getDayRecordForSelectedYearAndMonthQuery);

            if(getDayRecordForSelectedYearAndMonthQueryResult.Successful == false)
            {
                // TODO
                return;
            }

            var dayRecords = getDayRecordForSelectedYearAndMonthQueryResult.Result;

            var daysInMonth = DateTime.DaysInMonth(SelectedYear, SelectedMonth);

            var weekOfMonthAsNumber = 1;
            for (int i=1;i<=daysInMonth;i++)
            {
                var dayDate = new DateTime(SelectedYear, SelectedMonth, i);
                var dayOfWeekAsNumber = GetDayOfWeekAsNumber(dayDate.DayOfWeek);
                
                var dayRecordForDay = dayRecords.FirstOrDefault(dayRecord => dayRecord.DayRecordDate.Year == dayDate.Year
                && dayRecord.DayRecordDate.Month == dayDate.Month
                && dayRecord.DayRecordDate.Day == dayDate.Day);

                if(dayRecordForDay is null)
                {
                    Days.Add(new CalendarPanelNotRecordedDayCardViewModel(i, dayOfWeekAsNumber, weekOfMonthAsNumber));
                }

                if(dayRecordForDay is not null)
                {
                    Days.Add(new CalendarPanelRecordedDayCardViewModel(dayRecordForDay, dayOfWeekAsNumber, weekOfMonthAsNumber));
                }

                if (dayOfWeekAsNumber == 7)
                {
                    // Go to next week
                    weekOfMonthAsNumber++;
                }
            }
        }


        private async Task CreateDayRecordForDayCardCommandExecutionAsync(object parameter)
        {
            var dayCard = parameter as CalendarPanelNotRecordedDayCardViewModel;
            
            var createDayRecordCommand = new CreateDayRecord(Guid.NewGuid(), new DateTime(SelectedYear, SelectedMonth, dayCard.Day));
            var createDayRecordCommandResult = await _dispatcher.DispatchCommandAndGetResultAsync(createDayRecordCommand);

            if(createDayRecordCommandResult.Successful == false)
            {
                // TODO
                return;
            }

            var dayCardIndex = Days.IndexOf(dayCard);

            var getCreatedDayRecordQuery = new GetDayRecordCardById(createDayRecordCommand.Id);
            var getCreatedDayRecordQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<DayRecordCardViewModel, GetDayRecordCardById>(getCreatedDayRecordQuery);

            if(getCreatedDayRecordQueryResult.Successful == false)
            {
                // TODO
                return;
            }

            var createdDayRecord = getCreatedDayRecordQueryResult.Result;

            Days[dayCardIndex] = new CalendarPanelRecordedDayCardViewModel(createdDayRecord, dayCard.DayOfWeekAsNumber, dayCard.WeekOfMonthAsNumber);

            await GotoDayRecordPanelOfDayRecordCardCommandExecutionAsync(createdDayRecord);
        }

        private async Task GotoDayRecordPanelOfDayRecordCardCommandExecutionAsync(object parameter)
        {
            var dayRecordCard = parameter as DayRecordCardViewModel;

            _temporaryApplicationValues.DayRecordIdToOpen = dayRecordCard.DayRecordId;
            await _navigationService.ChangePanelAsync(typeof(DayRecordPanelViewModel));
        }


        private int GetDayOfWeekAsNumber(DayOfWeek day)
        {
            return day switch
            {
                DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday or
                DayOfWeek.Thursday or DayOfWeek.Friday or DayOfWeek.Saturday => (int)day,
                DayOfWeek.Sunday => 7,
                _ => throw new ArgumentException($"{day} is unknow Day of week.")
            };
        }
    }


    public abstract class CalendarPanelDayCardViewModel : ViewModel
    {
        public int DayOfWeekAsNumber { get; private set; }
        public int WeekOfMonthAsNumber { get; private set; }
        
        public int DayOfWeekAsNumberForGrid => DayOfWeekAsNumber - 1;
        public int WeekOfMonthAsNumberForGrid => WeekOfMonthAsNumber - 1;


        public CalendarPanelDayCardViewModel(int dayOfWeekAsNumber, int weekOfMonthAsNumber)
        {
            DayOfWeekAsNumber = dayOfWeekAsNumber;
            WeekOfMonthAsNumber = weekOfMonthAsNumber;
        }
    }


    public class CalendarPanelNotRecordedDayCardViewModel : CalendarPanelDayCardViewModel
    {
        public int Day { get; private set; }


        public CalendarPanelNotRecordedDayCardViewModel(int day, int dayOfWeekNumber, int weekOfMonthNumber)
            : base(dayOfWeekNumber, weekOfMonthNumber) 
        {
            Day = day;
        }
    }


    public class CalendarPanelRecordedDayCardViewModel : CalendarPanelDayCardViewModel
    {
        public DayRecordCardViewModel DayRecordCard { get; private set; }


        public CalendarPanelRecordedDayCardViewModel(DayRecordCardViewModel dayRecord, int dayOfWeekNumber, int weekOfMonthNumber)
            : base(dayOfWeekNumber, weekOfMonthNumber)
        {
            DayRecordCard = dayRecord;
        }
    }
}
