using AlanMocek.LifeLog.Application.Activities.DTOs;
using AlanMocek.LifeLog.Infrastructure.Types;
using System.Collections.Generic;

namespace AlanMocek.LifeLog.Application.Activities.Queries
{
    public record BrowseActivitiesForDayRecordPanel : ILifeLogQuery<IEnumerable<ActivityForDayRecordPanel>>
    {

    }
}
