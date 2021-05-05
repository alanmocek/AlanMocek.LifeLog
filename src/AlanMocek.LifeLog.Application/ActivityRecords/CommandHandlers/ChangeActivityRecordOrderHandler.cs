using AlanMocek.LifeLog.Application.ActivityRecords.Commands;
using AlanMocek.LifeLog.Core.ActivityRecords;
using AlanMocek.LifeLog.Core.ActivityRecords.Services;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.CommandHandlers
{
    public class ChangeActivityRecordOrderHandler : ICommandHandler<ChangeActivityRecordOrder>
    {
        private readonly ActivityRecordOrderChanger _activityRecordOrderChanger;
        private readonly LifeLogContext _lifeLogContext;


        public ChangeActivityRecordOrderHandler(
            ActivityRecordOrderChanger activityRecordOrderChanger,
            LifeLogContext lifeLogContext)
        {
            _activityRecordOrderChanger = activityRecordOrderChanger ?? throw new ArgumentNullException(nameof(activityRecordOrderChanger));
            _lifeLogContext = lifeLogContext ?? throw new ArgumentNullException(nameof(lifeLogContext));
        }


        public async Task HandleAsync(ChangeActivityRecordOrder command)
        {
            var newActivityRecordOrder = new ActivityRecordOrder(command.NewOrder);
            
            await _activityRecordOrderChanger.ChangeOrder(command.Id, newActivityRecordOrder);

            await _lifeLogContext.SaveChangesAsync();
        }
    }
}
