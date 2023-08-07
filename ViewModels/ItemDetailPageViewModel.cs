using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ShoppingListMobileApp1
{
    public class ItemDetailPageViewModel : INotifyPropertyChanged
    {
        private string _productName;
        private string _brand;
        private string _price;
        private string _productImage;

        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }

        public string Brand
        {
            get => _brand;
            set => SetProperty(ref _brand, value);
        }

        public string Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public string ProductImage
        {
            get => _productImage;
            set => SetProperty(ref _productImage, value);
        }

        public ICommand AddToCartCommand { get; }

        public ItemDetailPageViewModel()
        {
            // Initialize properties with sample data
            ProductName = "Sample Product";
            Brand = "Sample Brand";
            Price = "$50";
            ProductImage = "sample_product_image.jpg";

            // Command to handle adding to cart
            AddToCartCommand = new Command(AddToCart);
        }

        private void AddToCart()
        {
            // Add your logic here to handle adding to cart
            // For example, you can use a service or repository to manage the cart items
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
