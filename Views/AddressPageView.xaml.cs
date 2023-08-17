using Newtonsoft.Json;
using ShoppingListMobileApp1.Services;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using ShoppingListMobileApp1.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace ShoppingListMobileApp1;

public partial class AddressPageView : ContentPage
{
    private readonly AddressService _addressService = new AddressService();
    private readonly MainPage _mainPage = new MainPage();
    private User LoggedInUser;

    public GetAddressDTO selectedAddress;

    private AddressViewModel _viewModel;

    public AddressPageView()
    {
        InitializeComponent();
        LoggedInUser = _mainPage.getUser();
        GetAddressById(LoggedInUser.Id);

        //_viewModel = new AddressViewModel();
        //BindingContext = _viewModel;
        //LoadAddresses();
    }

    //private async void LoadAddresses()
    //{
    //    List<GetAddressDTO> addresses = await _addressService.GetAddress(LoggedInUser.Id);
    //    _viewModel.Addresses = addresses;
    //}

    public async Task<List<GetAddressDTO>> GetAddressById(int Id)
    {
        List<GetAddressDTO> addresses = await _addressService.GetAddress(Id);
        ((AddressViewModel)BindingContext).Addresses = addresses;
        GetAddresses.ItemsSource = addresses;
        return addresses;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // id ve userid alınacak
        //int id = 0;
        User user = LoggedInUser;
        int userId = LoggedInUser.Id;
        string addressName = AddressName.Text;
        string countryName = Country.Text;
        string cityName = City.Text;
        string townName = Town.Text;
        string districtName = District.Text;
        int postCode = int.Parse(PostCode.Text);
        string addressText = AddressText.Text;

        if (!string.IsNullOrEmpty(addressName) && !string.IsNullOrEmpty(countryName) &&
            !string.IsNullOrEmpty(cityName) && !string.IsNullOrEmpty(townName) &&
            !string.IsNullOrEmpty(districtName) && !string.IsNullOrEmpty(addressText))
        {
            var userAddress = await _addressService.Address(user, userId, addressName, countryName, cityName, townName,
                districtName, postCode, addressText);

            Preferences.Set("Id", userAddress.Id);
            Preferences.Set("UserId", userAddress.UserId);
            string userJson = JsonConvert.SerializeObject(userAddress.User);
            Preferences.Set("User", userJson);
            Preferences.Set("AddressName", userAddress.AddressName);
            Preferences.Set("Country", userAddress.CountryName);
            Preferences.Set("City", userAddress.CityName);
            Preferences.Set("Town", userAddress.TownName);
            Preferences.Set("District", userAddress.DistrictName);
            Preferences.Set("PostCode", userAddress.PostCode);
            Preferences.Set("AddressText", userAddress.AddressText);
            //Preferences.Set("Orders", (userAddress.Orders).ToString());

            ((AddressViewModel)BindingContext).Addresses.Add(userAddress);
            GetAddresses.ItemsSource = ((AddressViewModel)BindingContext).Addresses;

            await GetAddressById(LoggedInUser.Id);

            await Navigation.PopAsync();
        }
        else
            await DisplayAlert("Warning", "Please fill in the blanks", "Ok");
    }

    private void GetAddresses_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        selectedAddress = e.SelectedItem as GetAddressDTO;

        // Seçilen adresin detaylarını göstermek için ilgili bölümü görünür hale getirin
        //IsVisibleAddressSelected.IsVisible = true;

        // Seçilen adresin detaylarını göstermek için binding context'i güncelleyin
        (BindingContext as AddressViewModel).SelectedAddress = selectedAddress;

        //GetAddresses.SelectedItem = null;
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (selectedAddress != null)
        {
            int selectedIndex = GetAddresses.ItemsSource.Cast<GetAddressDTO>().ToList().IndexOf(selectedAddress);
            // selectedIndex değeri, seçilen öğenin indexini temsil eder
            // selectedIndex'i istediğiniz gibi kullanabilirsiniz

            // Seçilen adresin detaylarını göstermek için binding context'i güncelleyin
            //(BindingContext as AddressViewModel).SelectedAddress = selectedAddress;

            // Seçili adresi null kontrolü yaparak silme işlemini gerçekleştirelim
            if (selectedIndex >= 0 && selectedIndex < ((AddressViewModel)BindingContext).Addresses.Count)
            {
                ((AddressViewModel)BindingContext).Addresses.RemoveAt(selectedIndex);
                GetAddresses.ItemsSource = ((AddressViewModel)BindingContext).Addresses;
            }

            await DeleteAddress(selectedAddress.Id);

            await GetAddressById(LoggedInUser.Id);
        }

        // Seçimi sıfırlamak isterseniz:
        GetAddresses.SelectedItem = null;
    }

    public async Task DeleteAddress(int AdressId)
    {
        await _addressService.DeleteAddress(AdressId);
        //((AddressViewModel)BindingContext).SelectedAddress = deleteAddress;
        //return deleteAddress;
    }
}
