using System;
using System.Windows.Input;

namespace MVVM_Base
{
    public class RelayCommand : ICommand
    {
        private Action<object> executeHandler;
        private Predicate<object> canExecuteHandler;
        private event EventHandler CanExecuteChangedinternal;

        public RelayCommand(Action<object> execute) : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Execute kann nicht null sein!");
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException("CanExecute kannnicht null sein");
            }
            executeHandler = execute;
            canExecuteHandler = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChanged += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChanged -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteHandler == null)
            {
                return true;
            }
            return canExecuteHandler != null && canExecuteHandler(parameter);
        }

        public void Execute(object parameter)
        {
            executeHandler(parameter);
        }

        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedinternal;

            if(handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void Destroy()
        {
            this.canExecuteHandler = _ => false;
            this.executeHandler = _ => { return; };
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}
