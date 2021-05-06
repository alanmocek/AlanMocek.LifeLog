using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.Activities.Services
{
    public interface IActivitiesRepository
    {
        void Add(Activity activity);
        void Remove(Activity activity);
        Task<bool> GetIsActivityWithNameExistingAsync(string name);
        Task<Activity> GetByIdAsync(Guid id);
        Task<IEnumerable<Activity>> BrowseAsync(BrowseQuery query);
    }


    public record BrowseQuery
    {
        public BrowseQuery()
        {

        }
    }

}
