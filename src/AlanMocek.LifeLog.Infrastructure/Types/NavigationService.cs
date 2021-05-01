using AlanMocek.LifeLog.Infrastructure.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AlanMocek.LifeLog.Infrastructure.Types
{
    public class NavigationService
    {
        private readonly IServiceProvider _serviceProvider;


        public event Func<Task> CurrentPanelChanged;


        public PanelViewModel CurrentPanel { get; private set; }


        public NavigationService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }


        public async Task ChangePanelAsync(Type panelType)
        {
            if(panelType.IsSubclassOf(typeof(PanelViewModel)) == false)
            {
                throw new ArgumentException($"This panel type '{panelType.Name}' is not supported.");
            }

            var panel = _serviceProvider.GetRequiredService(panelType) as PanelViewModel;
            
            if(panel.IsInitialized == false)
            {
                await panel.InitializeAsync();
            }
            
            CurrentPanel = panel;
            await CurrentPanelChanged?.Invoke();
        }
    }
}
