using EntityLayer.Concrete;
using EntityLayer.DTOs;
using ShoppingListMobileApp1.Services;
using System.Diagnostics.Metrics;

namespace ShoppingListMobileApp1;

public partial class EditAddressPage : ContentPage
{
    private readonly AddressService _addressService = new AddressService();
    private readonly MainPage _mainPage = new MainPage();
    private User LoggedInUser;
    private GetAddressDTO newAddress;

    public EditAddressPage(GetAddressDTO address)
    {
        InitializeComponent();
        LoggedInUser = _mainPage.getUser();

        BindingContext = new EditAddressViewModel(address);
        newAddress = address;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        updateAddress(newAddress);
    }

    public async Task<GetAddressDTO> updateAddress(GetAddressDTO address)
    {
        GetAddressDTO updateAddress = await _addressService.UpdateAddress(address);
        (BindingContext as EditAddressViewModel).EditedAddress = updateAddress;
        return updateAddress;
    }
}