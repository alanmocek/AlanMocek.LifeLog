using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using AlanMocek.LifeLog.Infrastructure.Types;

namespace AlanMocek.LifeLog.Infrastructure.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;


        public Dispatcher(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }


        public async Task<CommandResult> DispatchCommandAndGetResultAsync<TCommand>(TCommand command) where TCommand : ILifeLogCommand
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var commandType = typeof(TCommand);
                    if (commandType.IsAbstract == true)
                    {
                        var trueCommandType = command.GetType();
                        dynamic trueCommandHandler = scope.ServiceProvider.GetRequiredService(typeof(ICommandHandler<>).MakeGenericType(trueCommandType));
                        dynamic trueCommand = Convert.ChangeType(command, trueCommandType);
                        await trueCommandHandler.HandleAsync(trueCommand);
                    }

                    if (commandType.IsAbstract == false)
                    {
                        var commandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
                        await commandHandler.HandleAsync(command);
                    }

                    var result = CommandResult.Succes();
                    return result;
                }
                catch (CoreException coreException)
                {
                    var result = CommandResult.Failure(coreException.Message);
                    return result;
                }
            }
        }

        public async Task<QueryResult<TQueryResult>> DispatchQueryAndGetResultAsync<TQueryResult, TQuery>(TQuery query) where TQuery : ILifeLogQuery<TQueryResult>
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var queryHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
                    var queryResult = await queryHandler.HandleAndGetResultAsync(query);

                    var result = QueryResult<TQueryResult>.Succes(queryResult);
                    return result;
                }
                catch(CoreException coreException)
                {
                    var result = QueryResult<TQueryResult>.Failure(coreException.Message);
                    return result;
                }
            }
        }
    }
}
