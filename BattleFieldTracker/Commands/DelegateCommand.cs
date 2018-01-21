using System;
using System.Windows.Input;

namespace BattleFieldTracker.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        /// <summary>
        ///     Erzeugt ein Command.
        /// </summary>
        /// <param name="execute">Action that gets executed</param>
        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        ///     Erzeugt ein Command.
        /// </summary>
        /// <param name="execute">Action that gets executed</param>
        /// <param name="canExecute">Predicate that checks if command can be executed.</param>
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <inheritdoc cref="ICommand.CanExecute" />
        /// />
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute(parameter);
        }

        /// <inheritdoc cref="ICommand.CanExecuteChanged" />
        /// />
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc cref="ICommand.Execute" />
        /// />
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
