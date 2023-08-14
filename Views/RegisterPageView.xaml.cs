using ShoppingListMobileApp1;
using Microsoft.Maui.Controls;
using System;
using ShoppingListMobileApp1.Services;
using EntityLayer.DTOs;

namespace ShoppingListMobileApp1
{
    public partial class RegisterPageView : ContentPage
    {
        private readonly RegisterService _registerService = new RegisterService();

        public RegisterPageView()
        {
            InitializeComponent();
        }

        private async void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            string password = Password.Text;
            string name = Name.Text;
            string surName = SurName.Text;
            string email = Email.Text;
            bool gender = true;

            if (maleRadioButton.IsChecked == true)
            {
                gender = true;
            }
            else if (femaleRadioButton.IsChecked == true)
            {
                gender = false;
            }

            DateTime birthDate = BirthDate.Date;
            DateTime registerDate = DateTime.Now;
            int phoneNumber = int.Parse(PhoneNumber.Text);

            if (userName != null && password != null && name != null && surName != null && email != null)
            {
                var registerUser = await _registerService.Register(userName, password, name, surName, email, gender, birthDate, registerDate, phoneNumber);

                Preferences.Set("UserId", registerUser.Id);
                Preferences.Set("UserName", registerUser.UserName);
                Preferences.Set("Password", registerUser.Password);
                Preferences.Set("Name", registerUser.Name);
                Preferences.Set("SurName", registerUser.Surname);
                Preferences.Set("Email", registerUser.Email);
                Preferences.Set("Gender", registerUser.Gender);
                Preferences.Set("BirthDate", registerUser.BirthDate);
                Preferences.Set("RegisterDate", registerUser.RegisterDate);
                Preferences.Set("PhoneNumber", registerUser.PhoneNumber);

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Warning", "Please fill in the blanks", "Ok");
            }
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender == maleRadioButton && e.Value)
            {
                // Erkek seçildiğinde yapılacak işlemler.
            }
            else if (sender == femaleRadioButton && e.Value)
            {
                // Kadın seçildiğinde yapılacak işlemler.
            }
        }
    }
}
