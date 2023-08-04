using Microsoft.Maui.Controls;

namespace MyApp
{
    public class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            var nameLabel = new Label
            {
                Text = "Name:"
            };

            var nameEntry = new Entry();

            var emailLabel = new Label
            {
                Text = "Email:"
            };

            var emailEntry = new Entry();

            var passwordLabel = new Label
            {
                Text = "Password:"
            };

            var passwordEntry = new Entry
            {
                IsPassword = true
            };

            var registerButton = new Button
            {
                Text = "Register"
            };
            registerButton.Clicked += OnRegisterButtonClicked;

            Content = new StackLayout
            {
                Children =
                {
                    nameLabel,
                    nameEntry,
                    emailLabel,
                    emailEntry,
                    passwordLabel,
                    passwordEntry,
                    registerButton
                }
            };
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            // Perform registration logic here
        }
    }
}
