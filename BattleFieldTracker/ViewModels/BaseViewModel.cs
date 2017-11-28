using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleFieldTracker.Annotations;


namespace BattleFieldTracker.ViewModels
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if ((object) field == (object) value)
                return;

            field = value;
            OnPropertyChanged(propertyName);
        }
    }
}
