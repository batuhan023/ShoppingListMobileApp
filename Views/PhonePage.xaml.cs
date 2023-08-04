using ShoppingListMobileApp1.Models;
using System.Collections.ObjectModel;

namespace ShoppingListMobileApp1;

public partial class PhonePage : ContentPage
{
    public ObservableCollection<Products> Prodcuts { get; set; }
    public PhonePage()
    {
        InitializeComponent();
        InitializeProducts();
        BindingContext = this;

    }

    private void InitializeProducts()
    {
        Prodcuts = new ObservableCollection<Products>
               {
                   new Products { Name = "Apple", Description = "Iphone 14 Pro Max", Price = "1199$", Image = "telefon.jpg" },

               };
    }
}