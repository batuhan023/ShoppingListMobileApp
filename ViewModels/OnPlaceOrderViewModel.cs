using Microsoft.Maui.Controls;
using ShoppingListMobileApp1.ViewModels;
using System.Windows.Input;

namespace ShoppingListMobileApp1;

public class OnPlaceOrderViewModel : BaseViewModel
{
    public string OrderSummary { get; private set; }

    public ICommand PlaceOrderCommand { get; }

    public OnPlaceOrderViewModel()
    {
        PlaceOrderCommand = new Command(PlaceOrder);
    }

    public void SetOrderSummary(string orderSummary)
    {
        OrderSummary = orderSummary;
        OnPropertyChanged(nameof(OrderSummary));
    }

    private void PlaceOrder()
    {
        // Siparişi işleme alın ve kullanıcıya onay mesajı gösterin.
        // Daha fazla işlem yapmak için gerçek bir sipariş işlemi yapılabilir.
        // Örneğin, sipariş veritabanına kaydedilebilir veya ödeme işlemi gerçekleştirilebilir.
        // Burada örnek bir onay mesajı kullanıyoruz:
        Application.Current.MainPage.DisplayAlert("Success", "Order placed successfully!", "OK");
    }
}
