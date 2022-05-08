using System;
using System.Windows.Input;
using RestaurantManager.Extensions;

namespace RestaurantManager.Utility
{

    public class SingleClickCommand<T> : SingleClickCommand
    {

        public SingleClickCommand(Action<T> command) 
            : base(o => command.Invoke((T)o), o => o.IsValidParameter<T>())
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
        }

        public SingleClickCommand(Action<T> command, Func<T, bool> canExecute) 
            : base(o =>command.Invoke((T)o), o => o.IsValidParameter<T>() && canExecute((T)o))
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }
    }

    public class SingleClickCommand : ICommand
    {
        private static DateTime? _lastClick;

        private readonly Action<object> _command;
        private readonly Func<object, bool> _canExecute;
        public SingleClickCommand(Action<object> command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

        public SingleClickCommand(Action command) : this(o => command.Invoke())
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
        }

        public SingleClickCommand(Action<object> command, Func<object, bool> canExecute) : this(command)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public SingleClickCommand(Action command, Func<bool> canExecute) : this(o => command.Invoke(), o => canExecute.Invoke())
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                ExecuteInternal(parameter);
            }
        }

        protected void ExecuteInternal(object parameter)
        {
            var canExecute = _lastClick == null || (DateTime.Now - _lastClick.Value).TotalSeconds > 3;
            if (canExecute)
            {
                _lastClick = DateTime.Now;
                _command.Invoke(parameter);
            }
        }

        public static void ResetLastClick()
        {
            _lastClick = DateTime.MinValue;
        }
    }
}