
using Microsoft.Maui.Controls;
using ShoppingListMobileApp1.Models;
using ShoppingListMobileApp1.ViewModels;
using System;



namespace ShoppingListMobileApp1
{
    public partial class NotificationsPageView : ContentPage
    {
        private readonly NotificationsViewModel viewModel;
        public NotificationsPageView()
        {
            InitializeComponent();
            viewModel = new NotificationsViewModel();
            BindingContext = viewModel;
        }
        private void ShowButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is ViewModels.Notification notification)
            {
                DisplayAlert(notification.Title, notification.Message, "OK");
            }
        }

    }
}
