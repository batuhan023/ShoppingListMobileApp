
using EntityLayer.Concrete;
using ShoppingListMobileApp1.Services;

namespace ShoppingListMobileApp1;

public partial class RegisterPageView : ContentPage
{
    private readonly RegisterService _registerService = new RegisterService();

    private readonly RegisterPageViewModel _viewModel = new RegisterPageViewModel();

    public RegisterPageView()
    {
        InitializeComponent();
        BindingContext = _viewModel;

    }

    private async void SignUpBtn_Clicked(object sender, EventArgs e)
    {
        string userName = _viewModel.NewName;
        string password = _viewModel.NewPassword;
        string name = _viewModel.NewName;
        string surName = _viewModel.NewSurname;
        string email = _viewModel.NewEmail;
        bool gender = _viewModel.IsGenderMale;
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
            var registerUser = await _registerService.Register(userName, password, name, surName, email, gender,
                birthDate, registerDate, phoneNumber);

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

            _viewModel.clearInput();

            //await Navigation.PopAsync();
            await Navigation.PushAsync(new MainPage());
        }
        else
            await DisplayAlert("Warning", "Please fill in the blanks", "Ok");


        //var user = new RegisterDTO
        //{
        //    string UserName = Username.Text;
        //    string password = Password.Text;
        //    string name = Name.Text;
        //    string surname = Surname.Text;
        //    string email = Email.Text;
        //    DateTime birthDate = birthDatePicker.Date;
        //    DateTime registerDate = DateTime.Now;
        //    var phoneNumber = PhoneNumber.Text;
        //};

        //bool isRegistered = await _loginService.RegisterUser(user);

        //    if (isRegistered)
        //    {
        //        // Kayıt başarılı
        //    }
        //    else
        //    {
        //        // Kayıt başarısız
        //    }

        //await Navigation.PushAsync(new MainPage());
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