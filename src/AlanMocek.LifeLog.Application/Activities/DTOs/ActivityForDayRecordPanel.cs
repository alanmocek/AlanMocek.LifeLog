using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.DTOs
{
    public record ActivityForDayRecordPanel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public bool HasValue { get; init; }


        public ActivityForDayRecordPanel(Guid id, string name, string type, bool hasValue)
        {
            Id = id;
            Name = name;
            Type = type;
            HasValue = hasValue;
        }
    }
}
