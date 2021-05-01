using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Infrastructure.WPF
{
    public abstract class PanelViewModel : ViewModel
    {
        public abstract Task InitializeAsync();
        public bool IsInitialized { get; protected set; }


        public PanelViewModel()
        {
            IsInitialized = false;
        }
    }
}
