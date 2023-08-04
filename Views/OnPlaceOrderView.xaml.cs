using Microsoft.Maui.Controls;

namespace ShoppingListMobileApp1
{
    public partial class OnPlaceOrderView : ContentPage
    {
        public OnPlaceOrderView(string orderSummary)
        {
            InitializeComponent();
            var viewModel = new OnPlaceOrderViewModel();
            viewModel.SetOrderSummary(orderSummary);
            BindingContext = viewModel;
        }
    }
}
