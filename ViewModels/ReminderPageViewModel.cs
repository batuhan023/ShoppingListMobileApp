
using System;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;




namespace ShoppingListMobileApp1.ViewModels;

public class ReminderPageViewModel : INotifyPropertyChanged
{
    private DateTime _selectedDate = DateTime.Now;
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            if (_selectedDate != value)
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
    }

    private TimeSpan _selectedTime = DateTime.Now.TimeOfDay;
    public TimeSpan SelectedTime
    {
        get => _selectedTime;
        set
        {
            if (_selectedTime != value)
            {
                _selectedTime = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime MinimumDate { get; } = DateTime.Now.Date;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void SaveReminder()
    {
        DateTime reminderrDateTime = SelectedDate.Date + SelectedTime;
        DateTime reminderDateTime = SelectedDate.Date + SelectedTime;

       

        // Android için hatırlatıcı ayarlama
        /*if (Device.RuntimePlatform == Device.Android)
        {
            var title = "Reminder Title";
            var message = "Reminder Message";
            var notifyTime = reminderDateTime;

            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async () =>
            {
                var request = new Xamarin.Essentials.NotificationRequest
                {
                    Title = title,
                    Description = message,
                    NotifyTime = notifyTime
                };
                await Xamarin.Essentials.Notifications.ScheduleNotificationAsync(request);
            });
        }*/
    }
}
