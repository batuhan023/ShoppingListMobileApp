using ShoppingListMobileApp1;
using Microsoft.Maui.Controls;
using System;
using ShoppingListMobileApp1.Services;
using ShoppingListMobileApp1.Views;

namespace ShoppingListMobileApp1;

public partial class MainPage : ContentPage
{

    private readonly LoginService _loginService = new LoginService();
    public MainPage()
	{
		InitializeComponent();
	}

	private void OnButtonClick(object sender, EventArgs e)
	{
        Navigation.PushAsync(new RegisterPageView());
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        string userName = EnterUserName.Text;
        string userPassword = EnterPassword.Text;

        if (userName != null && userPassword != null)
        {
            var users = await _loginService.Login(userName, userPassword);
            if (users != null)
            {

                //Bilgiler preferencese kaydedilir 
                Preferences.Set("UserId", users.Id);
                Preferences.Set("UserName", users.UserName);
                Preferences.Set("UserEmail", users.Email);
                Preferences.Set("UserPassword", users.Password);

                //Application.Current.MainPage = new CustomTabbedPage(); // TaCustom tabbar ile alakalı

                await Navigation.PushAsync(new HomePage());

            }
            else
            {
                await DisplayAlert("Warning", "Please Enter Correct Username And Password", "Ok");
            }

        }
        else
        {
            await DisplayAlert("Warning", "Please Input Username and password", "Ok");
        }



    }


    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }
}


