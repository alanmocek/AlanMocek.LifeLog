using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Application.ActivityRecords.DTOs;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanelViewModels
{
    public abstract class DayRecordPanelActivityRecordItem : ViewModel
    {
        private readonly IDispatcher _dispatcher;


        public event Func<Task> OrderChanged;


        public ActivityRecordForDayRecordPanel ActivityRecord { get; private set; }


        public ICommand ChangeOrderUpCommand { get; private set; }
        public ICommand ChangeOrderDownCommand { get; private set; }


        public DayRecordPanelActivityRecordItem(
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;


            ActivityRecord = null;


            ChangeOrderUpCommand = new AsyncCommand(ChangeOrderUpCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
            ChangeOrderDownCommand = new AsyncCommand(ChangeOrderDownCommandExecutionAsync, (ex) => ExceptionDispatchInfo.Capture(ex).Throw());
        }


        public Task InitializeAsync(ActivityRecordForDayRecordPanel activityRecord)
        {
            ActivityRecord = activityRecord;
            
            return Task.CompletedTask;
        }


        private async Task ChangeOrderUpCommandExecutionAsync(object parameter)
        {
            var changeOrderUpCommand = new ChangeActivityRecordOrder(ActivityRecord.Id, ActivityRecord.Order + 1);
            var changeOrderUpCommandResult = await _dispatcher.DispatchCommandAndGetResultAsync(changeOrderUpCommand);

            if(changeOrderUpCommandResult.Successful == false)
            {
                // TODO
                return;
            }

            ActivityRecord = ActivityRecord with { Order = ActivityRecord.Order + 1 };
            RaisePropertyChanged(nameof(ActivityRecord));

            await OrderChanged?.Invoke();
        }

        private async Task ChangeOrderDownCommandExecutionAsync(object parameter)
        {
            var changeOrderUpCommand = new ChangeActivityRecordOrder(ActivityRecord.Id, ActivityRecord.Order - 1);
            var changeOrderUpCommandResult = await _dispatcher.DispatchCommandAndGetResultAsync(changeOrderUpCommand);

            if (changeOrderUpCommandResult.Successful == false)
            {
                // TODO
                return;
            }

            ActivityRecord = ActivityRecord with { Order = ActivityRecord.Order - 1 };
            RaisePropertyChanged(nameof(ActivityRecord));

            await OrderChanged?.Invoke();
        }
    }


    public class DayRecordPanelQuantityActivityRecordItem : DayRecordPanelActivityRecordItem
    {
        public QuantityActivityRecordForDayRecordPanel QuantityActivityRecord
            => ActivityRecord as QuantityActivityRecordForDayRecordPanel;


        public DayRecordPanelQuantityActivityRecordItem(IDispatcher dispatcher)
            : base(dispatcher)
        {

        }
    }

    public class DayRecordPanelOccurredActivityRecordItem : DayRecordPanelActivityRecordItem
    {
        public OccurredActivityRecordForDayRecordPanel OccurredActivityRecord
            => ActivityRecord as OccurredActivityRecordForDayRecordPanel;


        public DayRecordPanelOccurredActivityRecordItem(IDispatcher dispatcher)
            : base(dispatcher)
        {

        }
    }

    public class DayRecordPanelTimeActivityRecordItem : DayRecordPanelActivityRecordItem
    {
        public TimeActivityRecordForDayRecordPanel TimeActivityRecord
            => ActivityRecord as TimeActivityRecordForDayRecordPanel;


        public DayRecordPanelTimeActivityRecordItem(IDispatcher dispatcher)
            : base(dispatcher)
        {

        }
    }

    public class DayRecordPanelClockActivityRecordItem : DayRecordPanelActivityRecordItem
    {
        public ClockActivityRecordForDayRecordPanel ClockActivityRecord
            => ActivityRecord as ClockActivityRecordForDayRecordPanel;


        public DayRecordPanelClockActivityRecordItem(IDispatcher dispatcher)
            : base(dispatcher)
        {

        }
    }
}
