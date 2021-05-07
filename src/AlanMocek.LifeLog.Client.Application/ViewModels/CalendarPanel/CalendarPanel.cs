using AlanMocek.LifeLog.Application.DayRecords.Commands;
using AlanMocek.LifeLog.Application.DayRecords.DTOs;
using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Client.Application.Types;
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
    public class CalendarPanel : PanelViewModel
    {
        private readonly IDispatcher _dispatcher;
        private readonly NavigationService _navigationService;
        private readonly TemporaryApplicationValues _temporaryApplicationValues;


        private bool _isInitialized;
        private int _selectedYear;
        private int _selectedMonth;


        public ObservableCollection<CalendarPanelDayElement> Days { get; private set; }
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


        public CalendarPanel(
            IDispatcher dispatcher,
            NavigationService navigationService,
            TemporaryApplicationValues temporaryApplicationValues)
        {
            _dispatcher = dispatcher;
            _navigationService = navigationService;
            _temporaryApplicationValues = temporaryApplicationValues;


            Days = new ObservableCollection<CalendarPanelDayElement>();


            _isInitialized = false;

            var currentDate = DateTime.Now;
            _selectedYear = currentDate.Year;
            _selectedMonth = currentDate.Month;


            CreateDayRecordForDayCardCommand = new AsyncCommand(CreateDayRecordForDayCardCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            GoToDayRecordPanelOfDayRecordCardCommand = new AsyncCommand(GotoDayRecordPanelCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public override async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            await LoadDaysAsync();
        }


        private async Task LoadDaysAsync()
        {
            var browseDayRecords = new BrowseDayRecordsForCalendarPanel(SelectedYear, SelectedMonth);
            var browseDayRecordsResult = await _dispatcher.DispatchQueryAndGetResultAsync<IEnumerable<DayRecordForCalendarPanel>, BrowseDayRecordsForCalendarPanel>(browseDayRecords);

            if(browseDayRecordsResult.Successful == false)
            {
                // TODO
                return;
            }

            var dayRecords = browseDayRecordsResult.Result;

            var daysInMonth = DateTime.DaysInMonth(SelectedYear, SelectedMonth);

            var weekOfMonthAsNumber = 1;
            for (int day=1;day<=daysInMonth;day++)
            {
                int dayOfWeekAsNumber = AddDayElement(dayRecords, weekOfMonthAsNumber, day);

                if (dayOfWeekAsNumber == 7)
                {
                    // Increase week number
                    weekOfMonthAsNumber++;
                }
            }
        }

        private int AddDayElement(IEnumerable<DayRecordForCalendarPanel> dayRecords, int weekOfMonthAsNumber, int i)
        {
            var dayDate = new DateTime(SelectedYear, SelectedMonth, i);
            var dayOfWeekAsNumber = GetDayOfWeekAsNumber(dayDate.DayOfWeek);
            var isToday = dayDate.Day == DateTime.Now.Day && dayDate.Month == DateTime.Now.Month && dayDate.Year == DateTime.Now.Year;


            var dayRecordForDay = dayRecords.FirstOrDefault(dayRecord => dayRecord.Date.Year == dayDate.Year
            && dayRecord.Date.Month == dayDate.Month
            && dayRecord.Date.Day == dayDate.Day);

            var DayRecordForDayExist = dayRecordForDay is not null;

            if (DayRecordForDayExist == false)
            {
                Days.Add(new CalendarPanelNotRecordedDayElement(i, dayOfWeekAsNumber, weekOfMonthAsNumber, isToday));
            }

            if (DayRecordForDayExist == true)
            {
                Days.Add(new CalendarPanelRecordedDayElement(dayRecordForDay, dayOfWeekAsNumber, weekOfMonthAsNumber, isToday));
            }

            return dayOfWeekAsNumber;
        }

        private async Task CreateDayRecordForDayCardCommandExecutionAsync(object parameter)
        {
            var dayCard = parameter as CalendarPanelNotRecordedDayElement;
            
            var createDayRecordCommand = new CreateDayRecord(Guid.NewGuid(), new DateTime(SelectedYear, SelectedMonth, dayCard.Day));
            var createDayRecordCommandResult = await _dispatcher.DispatchCommandAndGetResultAsync(createDayRecordCommand);

            if(createDayRecordCommandResult.Successful == false)
            {
                // TODO
                return;
            }

            var dayCardIndex = Days.IndexOf(dayCard);

            var getCreatedDayRecordQuery = new GetDayRecordForCalendarPanelById(createDayRecordCommand.Id);
            var getCreatedDayRecordQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<DayRecordForCalendarPanel, GetDayRecordForCalendarPanelById>(getCreatedDayRecordQuery);

            if(getCreatedDayRecordQueryResult.Successful == false)
            {
                // TODO
                return;
            }

            var createdDayRecord = getCreatedDayRecordQueryResult.Result;

            Days[dayCardIndex] = new CalendarPanelRecordedDayElement(createdDayRecord, dayCard.DayOfWeekAsNumber, dayCard.WeekOfMonthAsNumber, dayCard.IsToday);

            await GotoDayRecordPanelCommandExecutionAsync(createdDayRecord.Id);
        }

        private async Task GotoDayRecordPanelCommandExecutionAsync(object parameter)
        {
            var dayRecordId = (Guid)parameter;

            _temporaryApplicationValues.DayRecordIdToOpen = dayRecordId;
            await _navigationService.ChangePanelAsync(typeof(DayRecordPanelViewModels.DayRecordPanel));
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


    public abstract class CalendarPanelDayElement : ViewModel
    {
        public int DayOfWeekAsNumber { get; private set; }
        public int WeekOfMonthAsNumber { get; private set; }
        
        public int DayOfWeekAsNumberForGrid => DayOfWeekAsNumber - 1;
        public int WeekOfMonthAsNumberForGrid => WeekOfMonthAsNumber - 1;

        public bool IsToday { get; private set; }


        public CalendarPanelDayElement(int dayOfWeekAsNumber, int weekOfMonthAsNumber, bool isToday)
        {
            DayOfWeekAsNumber = dayOfWeekAsNumber;
            WeekOfMonthAsNumber = weekOfMonthAsNumber;
            IsToday = isToday;
        }
    }


    public class CalendarPanelNotRecordedDayElement : CalendarPanelDayElement
    {
        public int Day { get; private set; }


        public CalendarPanelNotRecordedDayElement(int day, int dayOfWeekNumber, int weekOfMonthNumber, bool isToday)
            : base(dayOfWeekNumber, weekOfMonthNumber, isToday) 
        {
            Day = day;
        }
    }


    public class CalendarPanelRecordedDayElement : CalendarPanelDayElement
    {
        public DayRecordForCalendarPanel DayRecord { get; private set; }


        public CalendarPanelRecordedDayElement(DayRecordForCalendarPanel dayRecord, int dayOfWeekNumber, int weekOfMonthNumber, bool isToday)
            : base(dayOfWeekNumber, weekOfMonthNumber, isToday)
        {
            DayRecord = dayRecord;
        }
    }
}
