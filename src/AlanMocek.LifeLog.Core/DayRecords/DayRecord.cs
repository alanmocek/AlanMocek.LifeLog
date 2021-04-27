using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.DayRecords
{
    public class DayRecord
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }


        public DayRecord(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }
    }
}
