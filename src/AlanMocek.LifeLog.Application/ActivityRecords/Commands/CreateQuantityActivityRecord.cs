using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.ActivityRecords.Commands
{
    public record CreateQuantityActivityRecord : CreateActivityRecord
    {
        public int Quantity { get; init; }


        public CreateQuantityActivityRecord(Guid id, Guid activityId, Guid dayReportId, int quantity) : base(id, activityId, dayReportId)
        {
            Quantity = quantity;
        }
    }
}
