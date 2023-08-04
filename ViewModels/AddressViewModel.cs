using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShoppingListMobileApp1
{
    public class AddressViewModel : BindableObject
    {
        public AddressViewModel()
        {
            // Örnek hayali adresler oluştur
            Addresses = new ObservableCollection<Address>
            {
                new Address {Name = "Ev", Country = "Country A", City = "City A", Neighborhood = "Neighborhood A", PostalCode = "12345", AddressText = "123 Main St" },
                new Address {Name = "İş", Country = "Country B", City = "City B", Neighborhood = "Neighborhood B", PostalCode = "67890", AddressText = "456 Elm St" },
                new Address {Name = "Okul", Country = "Country C", City = "City C", Neighborhood = "Neighborhood C", PostalCode = "54321", AddressText = "789 Oak St" }
            };

            // Komutlar oluştur
            EditCommand = new Command(OnEdit);
            DeleteCommand = new Command(OnDelete);
            AddAddressCommand = new Command(OnAddAddress);
            SaveAddressCommand = new Command(OnSaveAddress);
            CancelAddAddressCommand = new Command(OnCancelAddAddress);

            // Yeni adres eklemeyi gizle
            IsAddingAddress = false;
            IsAddressSelected = false;
            AddAddressButton = true;
        }

        // Adresler koleksiyonu
        public ObservableCollection<Address> Addresses { get; set; }

        // Seçili adres
        private Address selectedAddress;
        public Address SelectedAddress
        {
            get { return selectedAddress; }
            set
            {
                selectedAddress = value;
                OnPropertyChanged();
                IsAddressSelected = selectedAddress != null;
            }
        }

        // Seçili adres var mı?
        private bool isAddressSelected;
        public bool IsAddressSelected
        {
            get { return isAddressSelected; }
            set
            {
                isAddressSelected = value;
                OnPropertyChanged();
            }
        }

        // Yeni adres ekleniyor mu?
        private bool isAddingAddress;
        public bool IsAddingAddress
        {
            get { return isAddingAddress; }
            set
            {
                isAddingAddress = value;
                OnPropertyChanged();
            }
        }

        private bool addAddressButton;
        public bool AddAddressButton
        {
            get { return addAddressButton; }
            set
            {
                addAddressButton = value;
                OnPropertyChanged();
            }
        }

        // Yeni eklenen adres
        private string newName;
        public string NewName
        {
            get { return newName; }
            set
            {
                newName = value;
                OnPropertyChanged();
            }
        }
        private string newCountry;
        public string NewCountry
        {
            get { return newCountry; }
            set
            {
                newCountry = value;
                OnPropertyChanged();
            }
        }

        private string newCity;
        public string NewCity
        {
            get { return newCity; }
            set
            {
                newCity = value;
                OnPropertyChanged();
            }
        }

        private string newNeighborhood;
        public string NewNeighborhood
        {
            get { return newNeighborhood; }
            set
            {
                newNeighborhood = value;
                OnPropertyChanged();
            }
        }

        private string newPostalCode;
        public string NewPostalCode
        {
            get { return newPostalCode; }
            set
            {
                newPostalCode = value;
                OnPropertyChanged();
            }
        }

        private string newAddressText;
        public string NewAddressText
        {
            get { return newAddressText; }
            set
            {
                newAddressText = value;
                OnPropertyChanged();
            }
        }

        // Komutlar
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddAddressCommand { get; }
        public ICommand SaveAddressCommand { get; }
        public ICommand CancelAddAddressCommand { get; }

        // Düzenleme komutu işlemi
        private void OnEdit()
        {
            if (SelectedAddress != null)
            {
                Application.Current.MainPage.Navigation.PushAsync(new EditAddressPage(selectedAddress));
            }
        }

        // Silme komutu işlemi
        private void OnDelete()
        {
            // Seçili adresi silmek için gerekli işlemleri yapalım

            // Seçili adresi null kontrolü yaparak silme işlemini gerçekleştirelim
            if (SelectedAddress != null)
            {
                Addresses.Remove(SelectedAddress);
                SelectedAddress = null; // Seçili adresi sıfırlayalım
            }
        }

        // Adres ekleme komutu işlemi
        private void OnAddAddress()
        {
            // Yeni adres eklemeyi göster
            IsAddingAddress = true;
            IsAddressSelected = false;
            AddAddressButton = false;
        }

        // Yeni adresi kaydetme komutu işlemi
        private void OnSaveAddress()
        {
            // Yeni adresi koleksiyona ekleyelim
            Addresses.Add(new Address
            {
                Name = NewName,
                Country = NewCountry,
                City = NewCity,
                Neighborhood = NewNeighborhood,
                PostalCode = NewPostalCode,
                AddressText = NewAddressText
            });

            // Yeni adres eklemeyi gizle ve formu sıfırla
            IsAddingAddress = false;
            AddAddressButton = true;
            NewName = string.Empty;
            NewCountry = string.Empty;
            NewCity = string.Empty;
            NewNeighborhood = string.Empty;
            NewPostalCode = string.Empty;
            NewAddressText = string.Empty;
        }

        // Yeni adres eklemeyi iptal etme komutu işlemi
        private void OnCancelAddAddress()
        {
            // Yeni adres eklemeyi gizle ve formu sıfırla
            IsAddingAddress = false;
            AddAddressButton = true;
            NewName = string.Empty;
            NewCountry = string.Empty;
            NewCity = string.Empty;
            NewNeighborhood = string.Empty;
            NewPostalCode = string.Empty;
            NewAddressText = string.Empty;
        }
    }

    public class Address : BindableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }

        private string neighborhood;
        public string Neighborhood
        {
            get { return neighborhood; }
            set
            {
                neighborhood = value;
                OnPropertyChanged();
            }
        }

        private string postalCode;
        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                OnPropertyChanged();
            }
        }

        private string addressText;
        public string AddressText
        {
            get { return addressText; }
            set
            {
                addressText = value;
                OnPropertyChanged();
            }
        }
    }
}
