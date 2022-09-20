using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace RestaurantManager.Model
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public ModelBase()
        {
            //TODO: remove when implementing Firebase
            Id = new Random().Next();
        }

        protected string Serialize<T>(T model)
        {
            return JsonSerializer.Serialize(model);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T bakingField, T newValue, Action onChangedHandler = null,
            [CallerMemberName] string propertyName = null)
        {
            if (bakingField == null && newValue == null) return false;
            if (bakingField?.Equals(newValue) ?? false) return false;
            bakingField = newValue;
            OnPropertyChanged(propertyName);
            onChangedHandler?.Invoke();
            return true;
        }

        public void NotifyPropertyChanged(string propertyName = "")
        {
            OnPropertyChanged(propertyName);
        }
    
    }
}