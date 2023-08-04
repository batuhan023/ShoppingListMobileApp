using Microsoft.Maui.Controls;

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShoppingListMobileApp1;

public class CheckoutPageViewModel : BindableObject
{
    public CheckoutPageViewModel()
    {
        // Sample data for order items (replace with your actual order items data)
        OrderItems = new ObservableCollection<OrderItem>
        {
            new OrderItem { ProductName = "Product 1", Quantity = 2 },
            new OrderItem { ProductName = "Product 2", Quantity = 1 },
            // Add more order items here...
        };
        AvailableAddresses = new ObservableCollection<string>
        {
            "Address 1",
            "Address 2",
            "Address 3",
            // Add more addresses here...
        };
        // Payment options
        IsBankaKarti = true; // Default payment option
        SelectedDeliveryAddress = AvailableAddresses[0];
        // Commands
        PlaceOrderCommand = new Command(OnPlaceOrder);
    }

    public ObservableCollection<string> AvailableAddresses { get; set; }

    // Order Items collection
    public ObservableCollection<OrderItem> OrderItems { get; set; }

    // Delivery Address properties (add more properties as needed)
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }

    // Payment Information properties (add more properties as needed)
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }

    // Place Order Command
    public ICommand PlaceOrderCommand { get; }

    // Place Order Command handler
    private async void OnPlaceOrder()
    {
        // Create the order summary using the selected address and payment method
        string orderSummary = CreateOrderSummary();

        // Show the OnPlaceOrderView with the order summary
        await Application.Current.MainPage.Navigation.PushAsync(new OnPlaceOrderView(orderSummary));
    }

    private string CreateOrderSummary()
    {
        // Create the order summary based on the selected items and other information
        // You can customize the format of the order summary as per your requirements
        string summary = "Order Summary:\n";
        foreach (var orderItem in OrderItems)
        {
            summary += $"{orderItem.ProductName} x{orderItem.Quantity}\n";
        }
        summary += $"Delivery Address: {SelectedDeliveryAddress}\n";
        // Add more order details as needed...

        return summary;
    }

    // Selected delivery address
    private string selectedDeliveryAddress;
    public string SelectedDeliveryAddress
    {
        get { return selectedDeliveryAddress; }
        set
        {
            selectedDeliveryAddress = value;
            OnPropertyChanged();
        }
    }

    private bool isBankaKarti;
    public bool IsBankaKarti
    {
        get { return isBankaKarti; }
        set
        {
            isBankaKarti = value;
            OnPropertyChanged();
        }
    }

    private bool isKrediKarti;
    public bool IsKrediKarti
    {
        get { return isKrediKarti; }
        set
        {
            isKrediKarti = value;
            OnPropertyChanged();
        }
    }

    private bool isHavale;
    public bool IsHavale
    {
        get { return isHavale; }
        set
        {
            isHavale = value;
            OnPropertyChanged();
        }
    }
}

public class OrderItem
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}
