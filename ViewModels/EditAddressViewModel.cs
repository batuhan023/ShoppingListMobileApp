using EntityLayer.DTOs;
using System;
using System.Windows.Input;

namespace ShoppingListMobileApp1
{
    public class EditAddressViewModel : BindableObject
    {
        public EditAddressViewModel(GetAddressDTO address)
        {
            // Düzenlenen adresi ayarla
            EditedAddress = address;

            // Komutları oluştur
            SaveChangesCommand = new Command(OnSaveChanges);
            CancelCommand = new Command(OnCancel);
        }

        // Düzenlenen adres
        public GetAddressDTO EditedAddress { get; set; }

        // Komutlar
        public ICommand SaveChangesCommand { get; }
        public ICommand CancelCommand { get; }

        // Değişiklikleri kaydetme komutu işlemi
        private void OnSaveChanges()
        {
            // Düzenlenen adresi koleksiyona geri ekleyebilir veya veritabanına kaydedebilirsiniz
            // Örneğin, ana koleksiyondaki ilgili adresi güncelleyebilirsiniz

            // Örnek: App.AddressViewModel.Addresses.Remove(EditedAddress);
            // Örnek: App.AddressViewModel.Addresses.Add(EditedAddress);

            // Düzenleme sayfasını kapat
            Application.Current.MainPage.Navigation.PopAsync();
        }

        // İptal etme komutu işlemi
        private void OnCancel()
        {
            // Düzenleme işlemini iptal et ve sayfayı kapat
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
