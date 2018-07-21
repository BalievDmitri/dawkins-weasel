using System;
using System.Windows.Input;

namespace DawkinsWeasel
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Action _action1;

        public DelegateCommand(Action action)
        {
            _action1 = action;
        }

        public DelegateCommand(Action<object> action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            if (_action != null) _action(parameter);
            if (_action1 != null) _action1();
        }

        public bool CanExecute(object parameter)
        {
            if (_action != null || _action1 != null)
                return true;
            else return false;
        }

        //#pragma warning disable 67
        public event EventHandler CanExecuteChanged { add { } remove { } }
        //#pragma warning restore 67
    }
}
