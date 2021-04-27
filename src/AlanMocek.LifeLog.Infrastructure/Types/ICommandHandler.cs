using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Infrastructure.Types
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
