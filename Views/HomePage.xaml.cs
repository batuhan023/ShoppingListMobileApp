using ShoppingListMobileApp1.Models;
using System.Collections.ObjectModel;

namespace ShoppingListMobileApp1;

public partial class HomePage : ContentPage
{
    public ObservableCollection<FairyTale> FairyTales { get; set; }
    public ObservableCollection<Products> product { get; set; }
    public ObservableCollection<Products> product2 { get; set; }
    public HomePage()
    {
        InitializeComponent();
        LblUserName.Text = "Hi " + Preferences.Get("UserName", string.Empty);
        InitializeTales();
        BindingContext = this;
    }
    private void InitializeTales()
    {
        FairyTales = new ObservableCollection<FairyTale>
               {
                   new FairyTale { Name = "Cinderella", ReadTime = new TimeSpan(0, 30, 0), Image = "cinderella.jpg" },
                   new FairyTale { Name = "Snow White", ReadTime = new TimeSpan(0, 25, 0),  Image = "snow.jpg" },
                   new FairyTale { Name = "Rapunzel", ReadTime = new TimeSpan(0, 20, 0),  Image = "rapunzel.jpg" },
                   new FairyTale { Name = "Little Red Riding Hood", ReadTime = new TimeSpan(0, 15, 0),  Image = "hood.jpg" },
                   new FairyTale { Name = "Beauty and the Beast", ReadTime = new TimeSpan(0, 35, 0),  Image = "beauty.jpg" }
               };
        product = new ObservableCollection<Products>
               {
                   new Products { Name = "Mosnter", Description="Abra A5", Price="999$", Image = "laptop.jpeg" },
                   new Products { Name = "Apple", Description="Iphone 14 Pro Max", Price="1199$", Image = "telefon.jpg" },
                   new Products { Name = "Apple", Description = "Watch Series 8", Price = "319$", Image = "watch.jpeg" },
               };

        product2 = new ObservableCollection<Products>
               {
                   new Products { Name = "Apple", Description = "Watch Series 8", Price = "319$", Image = "watch.jpeg" },
                   new Products { Name = "Sony", Description="Headphones", Price="999$", Image = "headphones.png" },
                   new Products { Name = "DG", Description="T-shirt", Price="1199$", Image = "clothes2.png" },
                   new Products { Name = "Apple", Description = "Watch Series 8", Price = "319$", Image = "watch.jpeg" },
                   new Products { Name = "Mosnter", Description="Abra A5", Price="999$", Image = "laptop.jpeg" },
                   new Products { Name = "Apple", Description="Iphone 14 Pro Max", Price="1199$", Image = "telefon.jpg" },
                   new Products { Name = "Apple", Description = "Watch Series 8", Price = "319$", Image = "watch.jpeg" },
                   new Products { Name = "Mosnter", Description = "Abra A5", Price = "999$", Image = "laptop.jpeg" },
               };
    }

    private void Button_Clicked_Profile(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }
    private void Button_Clicked_Search(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new HomePage());
    }
    private void Button_Clicked_Cart(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CartPageView());
    }

    private void Button_Clicked_Technology(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TechnologyPage());
    }
}