using Microsoft.Maui.Controls;
using ShoppingListMobileApp1.ViewModels;
using System.Windows.Input;

namespace ShoppingListMobileApp1
{
    public class ForgotPasswordPageViewModel : BaseViewModel
    {
        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public ICommand ResetPasswordCommand { get; }

        public ForgotPasswordPageViewModel()
        {
            ResetPasswordCommand = new Command(ResetPassword);
        }

        private void ResetPassword()
        {
            Application.Current.MainPage.Navigation.PushAsync(new VerificationPageView());
            // Burada e-posta adresini kullanarak şifre sıfırlama işlemlerini gerçekleştirin.
            // Örneğin, kullanıcının e-posta adresine bir sıfırlama bağlantısı göndermek gibi.
            // Bu işlemleri gerçek projeye uygun şekilde doldurun.
        }
    }
}
