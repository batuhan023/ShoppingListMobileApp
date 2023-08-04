using Microsoft.Maui.Controls;
using ShoppingListMobileApp1.ViewModels;
using System.Windows.Input;

namespace ShoppingListMobileApp1
{
    public class VerificationPageViewModel : BaseViewModel
    {
        private string verificationCode;
        public string VerificationCode
        {
            get => verificationCode;
            set => SetProperty(ref verificationCode, value);
        }

        public ICommand VerifyCommand { get; }

        public VerificationPageViewModel()
        {
            VerifyCommand = new Command(Verify);
        }

        private void Verify()
        {
            // Burada kullanıcının girdiği verificationCode'u doğrulama işlemlerini gerçekleştirin.
            // Örneğin, e-posta veya SMS ile gönderilen kodu kaydedin ve girdi ile karşılaştırın.
            // Doğrulama işlemlerini gerçek projeye uygun şekilde doldurun.
        }
    }
}
