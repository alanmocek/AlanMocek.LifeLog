using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.Activities
{
    public abstract class Activity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public bool HasValue { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime UpdatedAtUtc { get; private set; }


        internal Activity(Guid id, string name, string type, bool hasValue)
        {
            Id = id;
            Name = name;
            Type = type;
            HasValue = hasValue;
            var utcNow = DateTime.UtcNow;
            CreatedAtUtc = utcNow;
            UpdatedAtUtc = utcNow;
        }


        internal void SetNewName(string newName)
        {
            Name = newName;
            UpdatedAtUtc = DateTime.UtcNow;
        }
    }
}
