using ShoppingListMobileApp1;
using Microsoft.Maui.Controls;
using System;
using ShoppingListMobileApp1.Services;
using EntityLayer.DTOs;

namespace ShoppingListMobileApp1;

public partial class RegisterPageView : ContentPage
{
    private readonly LoginService _loginService = new LoginService();
    public RegisterPageView()
    {
        InitializeComponent();
    }
    private async void SignUpBtn_Clicked(object sender, EventArgs e)
    {
        //    var user = new RegisterDTO 
        //    { 
        //    string UserName = Username.Text;
        //    string password = Password.Text;
        //    string name = Name.Text;
        //    string surname = Surname.Text;
        //    string email = Email.Text;
        //    DateTime birthDate = birthDatePicker.Date;
        //    DateTime registerDate = DateTime.Now;
        //    var phoneNumber = PhoneNumber.Text;
        //    };

        //bool isRegistered = await _loginService.RegisterUser(user);

        //    if (isRegistered)
        //    {
        //        // Kayıt başarılı
        //    }
        //    else
        //    {
        //        // Kayıt başarısız
        //    }

        Navigation.PushAsync(new MainPage());
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        //if (sender == maleRadioButton && e.Value)
        //{
        //    var user = new RegisterDTO
        //    {
        //    string UserName = Username.Text;
        //    string password = Password.Text;
        //    string name = Name.Text;
        //    string surname = Surname.Text;
        //    string email = Email.Text;
        //    DateTime birthDate = birthDatePicker.Date;
        //    DateTime registerDate = DateTime.Now;
        //    var phoneNumber = PhoneNumber.Text;
        //    };
        //}
        //else if (sender == femaleRadioButton && e.Value)
        //{
   
        //    bool gender = false;
        //    string userName = Username.Text;
        //    string password = Password.Text;
        //    string name = Name.Text;
        //    string surname = Surname.Text;
        //    string email = Email.Text;
        //    DateTime birthDate = birthDatePicker.Date;
        //    DateTime registerDate = DateTime.Now;
        //    var phoneNumber = PhoneNumber.Text;
        //}

    }
}
