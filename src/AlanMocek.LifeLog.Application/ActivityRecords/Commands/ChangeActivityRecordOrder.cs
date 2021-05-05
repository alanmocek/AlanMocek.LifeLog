using AlanMocek.LifeLog.Infrastructure.Types;
using System;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Commands
{
    public record ChangeActivityRecordOrder : ILifeLogCommand
    {
        public Guid Id { get; init; }
        public int NewOrder { get; init; }


        public ChangeActivityRecordOrder(Guid id, int newOrder)
        {
            Id = id;
            NewOrder = newOrder;
        }
    }
}
