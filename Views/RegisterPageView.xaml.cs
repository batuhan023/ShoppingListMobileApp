using ShoppingListMobileApp1;
using Microsoft.Maui.Controls;
using System;

namespace ShoppingListMobileApp1;

public partial class RegisterPageView : ContentPage
{
    public RegisterPageView()
    {
        InitializeComponent();
    }
    private void SignUpBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }


}
