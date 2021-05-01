﻿using AlanMocek.LifeLog.Application.DayRecords.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.DayRecords.Queries
{
    public record GetDayRecordCardsByYearAndMonth : ILifeLogQuery<IEnumerable<DayRecordCardViewModel>>
    {
        public int Year { get; init; }
        public int Month { get; init; }


        public GetDayRecordCardsByYearAndMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }
    }
}
