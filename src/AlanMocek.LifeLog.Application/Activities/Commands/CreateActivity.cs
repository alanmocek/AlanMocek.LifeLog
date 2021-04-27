using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.Commands
{
    public record CreateActivity : ICommand
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }


        public CreateActivity(Guid id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
