using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.ViewModels
{
    public class DayRecordCardViewModel
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }


        public DayRecordCardViewModel(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }
    }
}
