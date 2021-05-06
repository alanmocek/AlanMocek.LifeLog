using AlanMocek.LifeLog.Core.DayRecords.Services;
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
        public DateTime CreatedAtUtc { get; private set; }


        private DayRecord() { }

        /// <summary>
        /// Internal constructor for <see cref="DayRecordsCreator"/> use.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        internal DayRecord(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
            CreatedAtUtc = DateTime.UtcNow;
        }
    }
}
