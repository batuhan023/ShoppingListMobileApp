using System;
namespace ShoppingListMobileApp1.DataSources
{
    public class CartItem
    {
        public CartItem(string productName, double price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

}

