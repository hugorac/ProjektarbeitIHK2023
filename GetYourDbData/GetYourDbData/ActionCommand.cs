using System;
using System.Windows.Input;

namespace GetYourDbData
{
    public class ActionCommand : ICommand
    {
        // Die ActionCommand-Klasse 
 
        public ActionCommand(Action<SqlViewModel> execute, Func<SqlViewModel, bool> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged;
        public void RaiseExecuteChanged() {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
        Action<SqlViewModel> _execute;
        Func<SqlViewModel ,bool> _canExecute;
        public bool CanExecute(object? parameter) {
            var model = parameter as SqlViewModel;
            if (model == null) return false;
            return _canExecute(model);
        }

        public void Execute(object? parameter) {
            var model = parameter as SqlViewModel;
            if (model == null) return;
            _execute(model);
        }
    }
}
