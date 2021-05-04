﻿using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.ViewModels
{
    public class DayRecordForDayRecordPanel : ViewModel
    {
        public Guid DayRecordId { get; private set; }
        public DateTime DayRecordDate { get; private set; }


        public DayRecordForDayRecordPanel(Guid dayRecordId, DateTime dayRecordDate)
        {
            DayRecordId = dayRecordId;
            DayRecordDate = dayRecordDate;
        }
    }
}