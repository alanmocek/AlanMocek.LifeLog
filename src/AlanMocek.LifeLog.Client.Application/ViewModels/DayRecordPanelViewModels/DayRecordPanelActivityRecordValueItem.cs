using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Client.Application.ViewModels.DayRecordPanelViewModels
{
    public abstract class DayRecordPanelActivityRecordValueItem : ViewModel
    {
        public DayRecordPanelActivityRecordValueItem()
        {

        }
    }

    public class DayRecordPanelQuantityActivityRecordValueItem : DayRecordPanelActivityRecordValueItem
    {
        public int Quantity { get; set; }


        public DayRecordPanelQuantityActivityRecordValueItem()
        {
            Quantity = 0;
        }
    }

    public class DayRecordPanelClockActivityRecordValueItem : DayRecordPanelActivityRecordValueItem
    {
        public int Hour { get; set; }
        public int Minute { get; set; }


        public DayRecordPanelClockActivityRecordValueItem()
        {
            Hour = 0;
            Minute = 0;
        }
    }

    public class DayRecordPanelTimeActivityRecordValueItem : DayRecordPanelActivityRecordValueItem
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }


        public DayRecordPanelTimeActivityRecordValueItem()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }
    }

    public class DayRecordPanelOccurrenceActivityRecordValueItem : DayRecordPanelActivityRecordValueItem
    {
        public DayRecordPanelOccurrenceActivityRecordValueItem()
        {
            
        }
    }
}
