using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Infrastructure.Types
{
    public interface IQueryHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
    {
        Task<TQueryResult> HandleAndGetResultAsync(TQuery query);
    }
}
