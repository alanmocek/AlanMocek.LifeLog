using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Infrastructure.Dispatchers
{
    public interface IDispatcher
    {
        Task<CommandResult> DispatchCommandAndGetResultAsync<TCommand>(TCommand command)
            where TCommand : ICommand;
        Task<QueryResult<TQueryResult>> DispatchQueryAndGetResultAsync<TQueryResult, TQuery>(TQuery query)
            where TQuery : IQuery<TQueryResult>;
    }
}
