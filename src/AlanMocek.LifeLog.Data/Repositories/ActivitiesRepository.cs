using AlanMocek.LifeLog.Core.Activities;
using AlanMocek.LifeLog.Core.Activities.Services;
using AlanMocek.LifeLog.Data.Contexts;
using AlanMocek.LifeLog.Infrastructure.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Data.Repositories
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly LifeLogContext _lifeLogContext;


        public ActivitiesRepository(
            LifeLogContext lifeLogContext)
        {
            _lifeLogContext = lifeLogContext;
        }


        public void Add(Activity activity)
        {
            _lifeLogContext.Activities.Add(activity);
        }

        public void Remove(Activity activity)
        {
            _lifeLogContext.Activities.Remove(activity);
        }

        public async Task<Activity> GetByIdAsync(Guid id)
        {
            var activity = await _lifeLogContext.Activities.FirstOrDefaultAsync(activity => activity.Id == id);
            
            if(activity is null)
            {
                throw new CoreException("activity_not_found");
            }

            return activity;
        }

        public async Task<bool> GetIsActivityWithNameExistingAsync(string name)
        {
            return await _lifeLogContext.Activities.AnyAsync(activity => activity.Name == name);
        }

        public async Task<IEnumerable<Activity>> BrowseAsync(BrowseQuery query)
        {
            IQueryable<Activity> contextQuery = _lifeLogContext.Activities;

            return await contextQuery.ToListAsync();
        }
    }
}
