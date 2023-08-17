
using EntityLayer.DTOs;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShoppingListMobileApp1
{
    public class AddressViewModel : BindableObject
    {
        //public List<GetAddressDTO> _returnedValue;
        //public List<GetAddressDTO> ReturnedValue
        //{
        //    get { return _returnedValue; }
        //    set
        //    {
        //        _returnedValue = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private void AnotherMethod()
        //{
        //    string selectedAddress = ReturnedValue; // Bu, AdressPage.xaml.cs içinde seçilen adresi içerecek
        //                                              // Seçilen adresle ilgili işlemleri burada yapabilirsiniz
        //}

        public AddressViewModel()
        {
            // Komutlar oluştur
            EditCommand = new Command(OnEdit);
            DeleteCommand = new Command(OnDelete);
            AddAddressCommand = new Command(OnAddAddress);
            SaveAddressCommand = new Command(OnSaveAddress);
            CancelAddAddressCommand = new Command(OnCancelAddAddress);
            HideAddAddressCommand = new Command(OnHideAddAddress);

            // Yeni adres eklemeyi gizle
            OnHideAddAddress();
        }

        // Adresler koleksiyonu
        public List<GetAddressDTO> _addresses;
        public List<GetAddressDTO> Addresses
        {
            get { return _addresses; }
            set
            {
                _addresses = value;
                OnPropertyChanged(nameof(Addresses));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public List<GetAddressDTO> Addresses { get; set; }

        //public List<GetAddressDTO> Addresses = _addressPageView.getAddressById(LoggedInUser.Id);

        // Seçili adres
        private GetAddressDTO selectedAddress;
        public GetAddressDTO SelectedAddress
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
        private int newUserId;
        public int NewUserId
        {
            get { return newUserId; }
            set
            {
                newUserId = value;
                OnPropertyChanged();
            }
        }

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

        private string newTown;
        public string NewTown
        {
            get { return newTown; }
            set
            {
                newTown = value;
                OnPropertyChanged();
            }
        }

        private string newDistrictName;
        public string NewDistrictName
        {
            get { return newDistrictName; }
            set
            {
                newDistrictName = value;
                OnPropertyChanged();
            }
        }

        //private string newNeighborhood;
        //public string NewNeighborhood
        //{
        //    get { return newNeighborhood; }
        //    set
        //    {
        //        newNeighborhood = value;
        //        OnPropertyChanged();
        //    }
        //}

        private int newPostalCode;
        public int NewPostalCode
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
        public ICommand HideAddAddressCommand { get; }

        // Düzenleme komutu işlemi
        private void OnEdit()
        {
            if (SelectedAddress != null)
            {
                Application.Current.MainPage.Navigation.PushAsync(new EditAddressPage(selectedAddress));
            }
            OnHideAddAddress();
        }

        // Silme komutu işlemi
        private void OnDelete()
        {
            // Seçili adresi silmek için gerekli işlemleri yapalım

            // Seçili adresi null kontrolü yaparak silme işlemini gerçekleştirelim
            if (SelectedAddress != null)
            {
                //Addresses.Remove(SelectedAddress);
                SelectedAddress = null; // Seçili adresi sıfırlayalım

                OnPropertyChanged(nameof(Addresses));
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
            Addresses.Add(new GetAddressDTO
            {
                UserID = NewUserId,
                AddressName = NewName,
                CountryName = NewCountry,
                CityName = NewCity,
                TownName = NewTown,
                DistrictName = NewDistrictName,
                PostCode = NewPostalCode,
                AddressText = NewAddressText
            });

            // Yeni adres eklemeyi gizle ve formu sıfırla
            IsAddingAddress = false;
            AddAddressButton = true;

            OnPropertyChanged(nameof(Addresses));

            //NewUserId = 0;
            //NewName = string.Empty;
            //NewCountry = string.Empty;
            //NewCity = string.Empty;
            //NewTown = string.Empty;
            //NewDistrictName = string.Empty;
            //NewPostalCode = 0;
            //NewAddressText = string.Empty;
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
            NewPostalCode = 0;
            NewAddressText = string.Empty;
        }

        private void OnHideAddAddress()
        {
            IsAddingAddress = false;
            IsAddressSelected = false;
            AddAddressButton = true;
        }
    }

    //public class Address : BindableObject
    //{
    //    private int userId;
    //    public int UserId
    //    {
    //        get { return userId; }
    //        set
    //        {
    //            userId = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string name;
    //    public string Name
    //    {
    //        get { return name; }
    //        set
    //        {
    //            name = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string country;
    //    public string Country
    //    {
    //        get { return country; }
    //        set
    //        {
    //            country = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string city;
    //    public string City
    //    {
    //        get { return city; }
    //        set
    //        {
    //            city = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string town;
    //    public string Town
    //    {
    //        get { return town; }
    //        set
    //        {
    //            town = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string districtName;
    //    public string DistrictName
    //    {
    //        get { return districtName; }
    //        set
    //        {
    //            districtName = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    //private string neighborhood;
    //    //public string Neighborhood
    //    //{
    //    //    get { return neighborhood; }
    //    //    set
    //    //    {
    //    //        neighborhood = value;
    //    //        OnPropertyChanged();
    //    //    }
    //    //}

    //    private int postalCode;
    //    public int PostalCode
    //    {
    //        get { return postalCode; }
    //        set
    //        {
    //            postalCode = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    private string addressText;
    //    public string AddressText
    //    {
    //        get { return addressText; }
    //        set
    //        {
    //            addressText = value;
    //            OnPropertyChanged();
    //        }
    //    }
    //}

}
