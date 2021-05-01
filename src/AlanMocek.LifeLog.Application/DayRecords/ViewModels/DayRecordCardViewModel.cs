using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.ViewModels
{
    public class DayRecordCardViewModel
    {
        public Guid DayRecordId { get; private set; }
        public DateTime DayRecordDate { get; private set; }


        public DayRecordCardViewModel(Guid id, DateTime date)
        {
            DayRecordId = id;
            DayRecordDate = date;
        }
    }
}
