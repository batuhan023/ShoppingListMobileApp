using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ShoppingListMobileApp1.ViewModels
{
    public class NotificationsViewModel : BindableObject
    {
        private ObservableCollection<Notification> notifications;


        public NotificationsViewModel()
        {
            // Örnek hayali bildirimler oluştur
            Notifications = new ObservableCollection<Notification>
            {
                new Notification { Title = "Bildirim 1", Message = "Bu bir bildirim mesajıdır.", Date = DateTime.Now },
                new Notification { Title = "Bildirim 2", Message = "Bu da başka bir bildirim mesajıdır.", Date = DateTime.Now.AddDays(-1) },
                new Notification { Title = "Bildirim 3", Message = "Bu da bir diğer bildirim mesajıdır.", Date = DateTime.Now.AddDays(-2) },
            };

            // Komutlar oluştur
            DeleteNotificationCommand = new Command<Notification>(OnDeleteNotification);
            AddNotificationCommand = new Command(OnAddNotification);
            SaveNotificationCommand = new Command(OnSaveNotification);
            CancelAddNotificationCommand = new Command(OnCancelAddNotification);

            // Yeni bildirim eklemeyi gizle
            IsAddingNotification = false;
            IsNotificationSelected = false;
            AddNotificationButton = true;
        }

        // Bildirimler koleksiyonu
        public ObservableCollection<Notification> Notifications
        {
            get => notifications;
            set
            {
                notifications = value;
                OnPropertyChanged();
            }
        }


        private int notificationCount;
        public int NotificationCount
        {
            get => notificationCount;
            set
            {
                notificationCount = value;
                OnPropertyChanged();
            }
        }

        // Seçili bildirim var mı?
        private bool isNotificationSelected;
        public bool IsNotificationSelected
        {
            get { return isNotificationSelected; }
            set
            {
                isNotificationSelected = value;
                OnPropertyChanged();
            }
        }

        // Yeni bildirim ekleniyor mu?
        private bool isAddingNotification;
        public bool IsAddingNotification
        {
            get { return isAddingNotification; }
            set
            {
                isAddingNotification = value;
                OnPropertyChanged();
            }
        }

        private bool addNotificationButton;
        public bool AddNotificationButton
        {
            get { return addNotificationButton; }
            set
            {
                addNotificationButton = value;
                OnPropertyChanged();
            }
        }

        // Yeni eklenen bildirim
        private string newTitle;
        public string NewTitle
        {
            get { return newTitle; }
            set
            {
                newTitle = value;
                OnPropertyChanged();
            }
        }

        private string newMessage;
        public string NewMessage
        {
            get { return newMessage; }
            set
            {
                newMessage = value;
                OnPropertyChanged();
            }
        }

        private string newCountNotification;
        public string NewCountNotification
        {
            get
            {
                newCountNotification = (notifications.Count).ToString();
                return newCountNotification;
            }
            set
            {
                newCountNotification = value;
                OnPropertyChanged();
            }
        }

        // Komutlar
        public ICommand DeleteNotificationCommand { get; }
        public ICommand AddNotificationCommand { get; }
        public ICommand SaveNotificationCommand { get; }
        public ICommand CancelAddNotificationCommand { get; }

        // Bildirim silme komutu işlemi
        private void OnDeleteNotification(Notification notification)
        {
            // Seçili bildirimi silmek için gerekli işlemleri yapalım
            if (notification != null)
            {
                Notifications.Remove(notification);
                IsNotificationSelected = false; // Seçili bildirimi sıfırlayalım
            }
        }

        // Bildirim ekleme komutu işlemi
        private void OnAddNotification()
        {
            // Yeni bildirim eklemeyi göster
            IsAddingNotification = true;
            IsNotificationSelected = false;
            AddNotificationButton = false;
        }

        // Yeni bildirimi kaydetme komutu işlemi
        private void OnSaveNotification()
        {
            // Yeni bildirimi koleksiyona ekleyelim
            Notifications.Add(new Notification
            {
                Title = NewTitle,
                Message = NewMessage,
                Date = DateTime.Now
            });

            // Yeni bildirim eklemeyi gizle ve formu sıfırla
            IsAddingNotification = false;
            AddNotificationButton = true;
            NewTitle = string.Empty;
            NewMessage = string.Empty;
        }

        // Yeni bildirimi iptal etme komutu işlemi
        private void OnCancelAddNotification()
        {
            // Yeni bildirim eklemeyi gizle ve formu sıfırla
            IsAddingNotification = false;
            AddNotificationButton = true;
            NewTitle = string.Empty;
            NewMessage = string.Empty;
        }
    }

    public class Notification : BindableObject
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }
    }
}
