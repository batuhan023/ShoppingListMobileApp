using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace ShoppingListMobileApp1.ViewModels
{
    public class CartViewModel : BindableObject
    {
        private ObservableCollection<CartItem> _cartItems;
        public ObservableCollection<CartItem> CartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                OnPropertyChanged();
            }
        }

        public CartViewModel()
        {
            // Örnek ürünleri ekleyelim.
            CartItems = new ObservableCollection<CartItem>
            {
                new CartItem { ProductName = "Ürün 1", Quantity = 2, ProductImage = "product1.png" },
                new CartItem { ProductName = "Ürün 2", Quantity = 1, ProductImage = "product2.png" },
                new CartItem { ProductName = "Ürün 3", Quantity = 3 , ProductImage = "product3.png"}
            };
        }
    }

    public class CartItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string ProductImage { get; set; }
    }
}
