using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingListMobileApp1.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Property değişikliğini izleyen metot
        protected void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(backingField, value))
                return;

            backingField = value;
            OnPropertyChanged(propertyName);
        }

        // Property değiştiğinde tetiklenen metot
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
