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
        Task<bool> GetIsActivityWithNameExistingAsync(string name);
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<Activity> GetByIdAsync(Guid id);
    }
}
