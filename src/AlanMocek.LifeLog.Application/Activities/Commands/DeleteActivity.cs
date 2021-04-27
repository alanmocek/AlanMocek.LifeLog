using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.Commands
{
    public record DeleteActivity : ILifeLogCommand
    {
        public Guid Id { get; init; }


        public DeleteActivity(Guid id)
        {
            Id = id;
        }
    }
}
