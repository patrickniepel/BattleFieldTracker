using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <param name="execute">Action, die beim Ausführen des Commands ausgeführt wird.</param>
        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        ///     Erzeugt ein Command.
        /// </summary>
        /// <param name="execute">Action, die beim Ausführen des Commands ausgeführt wird.</param>
        /// <param name="canExecute">Predicate, dass prüft, ob das Command ausgeführt werden kann.</param>
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

        /// <summary>
        ///     Informiert über Änderungen, die eine erneute Überprüfung, ob das Kommando ausgeführt werden kann, nötig machen.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
