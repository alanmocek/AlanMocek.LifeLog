using AlanMocek.LifeLog.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Core.Activities.Services
{
    public class ActivitiesCreator
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly ActivitiesFactory _activitiesFactory;


        public ActivitiesCreator(
            IActivitiesRepository activitiesRepository,
            ActivitiesFactory activitiesFactory)
        {
            _activitiesRepository = activitiesRepository;
            _activitiesFactory = activitiesFactory;
        }


        public async Task<Activity> CreateAsync(Guid id, string name, string type)
        {
            var isActivityWithNameExisting = await _activitiesRepository.GetIsActivityWithNameExistingAsync(name);

            if(isActivityWithNameExisting == true)
            {
                throw new CoreException("Activity with this name is already created.");
            }

            var activity = _activitiesFactory.FactorActivityByType(id, name, type);

            return activity;
        }
    }
}
