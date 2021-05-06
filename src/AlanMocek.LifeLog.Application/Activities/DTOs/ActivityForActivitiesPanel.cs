using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Application.Activities.DTOs
{
    public abstract record ActivityForActivitiesPanel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public bool HasValue { get; init; }
        public string Type { get; init; }


        internal ActivityForActivitiesPanel(Guid id, string name, string type, bool hasValue)
        {
            Id = id;
            Name = name;
            Type = type;
            HasValue = hasValue;
        }
    }

    public record TimeActivityForActivitiesPanel : ActivityForActivitiesPanel
    {
        public TimeActivityForActivitiesPanel(Guid id, string name, string type, bool hasValue) 
            : base(id, name, type, hasValue)
        {

        }
    }

    public record QuantityActivityForActivitiesPanel : ActivityForActivitiesPanel
    {
        public QuantityActivityForActivitiesPanel(Guid id, string name, string type, bool hasValue) 
            : base(id, name, type, hasValue)
        {

        }
    }

    public record OccurrenceActivityForActivitiesPanel : ActivityForActivitiesPanel
    {
        public OccurrenceActivityForActivitiesPanel(Guid id, string name, string type, bool hasValue) 
            : base(id, name, type, hasValue)
        {

        }
    }

    public record ClockActivityForActivitiesPanel : ActivityForActivitiesPanel
    {
        public ClockActivityForActivitiesPanel(Guid id, string name, string type, bool hasValue) : base(id, name, type, hasValue)
        {

        }
    }
}
