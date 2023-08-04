
using ShoppingListMobileApp1.Models;
using System.Collections.ObjectModel;

namespace ShoppingListMobileApp1;

public partial class TechnologyPage : ContentPage
{
    public ObservableCollection<Products> Prodcuts { get; set; }
    public TechnologyPage()
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
                   new Products { Name = "Apple", Description = "Watsch Series 8", Price = "300$", Image = "watch.jpeg" },
                   new Products { Name = "Monster", Description = "Abra A5", Price = "999$", Image = "laptop.jpeg" },
                   new Products { Name = "Apple", Description = "Airpods", Price = "250$", Image = "airpods.jpeg" },
               };
    }

    private void Button_Clicked_Phone(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PhonePage());
    }
}