using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanMocek.LifeLog.Infrastructure.WPF
{
    public class AsyncCommand : System.Windows.Input.ICommand
    {
        private Action<Exception> _onException;
        private Func<object, Task> _toExcute;

        public event EventHandler CanExecuteChanged;

        public AsyncCommand(Func<object, Task> toExcute, Action<Exception> onException)
        {
            _toExcute = toExcute;
            _onException = onException;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _toExcute?.Invoke(parameter);
            }
            catch (Exception exception)
            {
                _onException?.Invoke(exception);
            }
        }
    }
}
