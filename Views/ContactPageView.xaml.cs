using Microsoft.Maui.Controls;

namespace ShoppingListMobileApp1
{
    public partial class ContactPageView : ContentPage
    {
        public ContactPageView()
        {
            InitializeComponent();
        }

        private void OnGonderClicked(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string email = txtEmail.Text;
            string mesaj = txtMesaj.Text;

            // Burada gönderme işlemini yapabilirsiniz, örneğin bir e-posta gönderme servisine gönderebilirsiniz.

            // Örnek olarak, girdi verilerini birleştirip konsola yazdıralım.
            Console.WriteLine($"Ad: {ad}\nSoyad: {soyad}\nE-posta: {email}\nMesaj: {mesaj}");
        }
    }
}
