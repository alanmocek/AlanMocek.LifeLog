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


        public Activity(Guid id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }


        internal void SetNewName(string newName)
        {
            Name = newName;
        }
    }
}
