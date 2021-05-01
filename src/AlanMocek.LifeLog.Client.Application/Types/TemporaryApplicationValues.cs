using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Client.Application.Types
{
    public class TemporaryApplicationValues
    {
        public Guid? DayRecordIdToOpen { get; set; }


        public TemporaryApplicationValues()
        {
            DayRecordIdToOpen = null;
        }
    }
}
