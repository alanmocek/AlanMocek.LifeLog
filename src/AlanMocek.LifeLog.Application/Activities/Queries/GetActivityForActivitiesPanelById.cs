using AlanMocek.LifeLog.Application.Activities.DTOs;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;

namespace AlanMocek.LifeLog.Application.Activities.Queries
{
    public record GetActivityForActivitiesPanelById : ILifeLogQuery<ActivityForActivitiesPanel>
    {
        public Guid Id { get; init; }


        public GetActivityForActivitiesPanelById(Guid id)
        {
            Id = id;
        }
    }
}
