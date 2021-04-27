using AlanMocek.LifeLog.Application.Activities.ViewModels;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.Queries
{
    public record GetActivityById : IQuery<ActivityViewModel>
    {
        public Guid Id { get; init; }


        public GetActivityById(Guid id)
        {
            Id = id;
        }
    }
}
