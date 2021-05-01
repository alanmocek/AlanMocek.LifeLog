using AlanMocek.LifeLog.Application.DayRecords.Queries;
using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Client.Application.Types;
using AlanMocek.LifeLog.Client.Application.ViewModels.CalendarPanel;
using AlanMocek.LifeLog.Infrastructure.Dispatchers;
using AlanMocek.LifeLog.Infrastructure.Types;
using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanel
{
    public class DayRecordPanelViewModel : PanelViewModel
    {
        private readonly TemporaryApplicationValues _temporaryApplicationValues;
        private readonly IDispatcher _dispatcher;
        private readonly NavigationService _navigationService;


        public DayRecordViewModel DayRecord { get; private set; }


        public DayRecordPanelViewModel(
            TemporaryApplicationValues temporaryApplicationValues,
            IDispatcher dispatcher,
            NavigationService navigationService)
        {
            _temporaryApplicationValues = temporaryApplicationValues ?? throw new ArgumentNullException(nameof(temporaryApplicationValues));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _navigationService = navigationService;


            DayRecord = null;
        }

         
        public override async Task InitializeAsync()
        {
            if(_temporaryApplicationValues.DayRecordIdToOpen.HasValue == false)
            {
                throw new Exception("No day record id find to open day record panel.");
            }
            var getDayRecordQuery = new GetDayRecordById(_temporaryApplicationValues.DayRecordIdToOpen.Value);
            var getDayRecordQueryResult = await _dispatcher.DispatchQueryAndGetResultAsync<DayRecordViewModel, GetDayRecordById>(getDayRecordQuery);

            if(getDayRecordQueryResult.Successful == false)
            {
                await _navigationService.ChangePanelAsync(typeof(CalendarPanelViewModel));
            }

            DayRecord = getDayRecordQueryResult.Result;
            RaisePropertyChanged(nameof(DayRecord));
        }
    }
}
