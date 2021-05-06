using AlanMocek.LifeLog.Infrastructure.Types;
using System;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Commands
{
    public record DeleteActivityRecord : ILifeLogCommand
    {
        public Guid Id { get; init; }


        public DeleteActivityRecord(Guid id)
        {
            Id = id;
        }
    }
}
