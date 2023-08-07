using System.Collections.ObjectModel;
using Microsoft.Maui.Handlers;
using ShoppingListMobileApp1.Models;
using ShoppingListMobileApp1.ViewModels;



namespace ShoppingListMobileApp1;

public partial class ItemPageView : ContentPage
{
    public ObservableCollection<FairyTale> FairyTales { get; set; }
    public ObservableCollection<FairyTale> FairyTales2 { get; set; }
    private readonly NotificationsViewModel viewModel;
    private NotificationsViewModel notificationsViewModel;
    public ItemPageView()
    {
        InitializeComponent();
        ModifySearchBar();
        InitializeTales();
        BindingContext = this;

        // NotificationCountLabel için güncel bildirim sayısını ata
        viewModel = new NotificationsViewModel();
        NotificationCountLabel.Text = viewModel.NewCountNotification;
        notificationsViewModel = new NotificationsViewModel();
        BindingContext = notificationsViewModel;

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
        FairyTales2 = new ObservableCollection<FairyTale>
               {
                   new FairyTale { Name = "Snow White", ReadTime = new TimeSpan(0, 25, 0),  Image = "snow.jpg" },
                   new FairyTale { Name = "Rapunzel", ReadTime = new TimeSpan(0, 20, 0),  Image = "rapunzel.jpg" },
                   new FairyTale { Name = "Little Red Riding Hood", ReadTime = new TimeSpan(0, 15, 0),  Image = "hood.jpg" },
                   new FairyTale { Name = "Beauty and the Beast", ReadTime = new TimeSpan(0, 35, 0),  Image = "beauty.jpg" },
                   new FairyTale { Name = "Cinderella", ReadTime = new TimeSpan(0, 30, 0),  Image = "cinderella.jpg" }
               };
    }

    private void ModifySearchBar()
    {
        SearchBarHandler.Mapper.AppendToMapping("CustomSearchIconColor", (handler, view) =>
        {

#if ANDROID

            var context = handler.PlatformView.Context;
            var searchIconId = context.Resources.GetIdentifier("search_mag_icon", "id", context.PackageName);
            if (searchIconId != 0)
            {
                var searchIcon = handler.PlatformView.FindViewById<Android.Widget.ImageView>(searchIconId);
                searchIcon.SetColorFilter(Android.Graphics.Color.Rgb(172, 157, 185), Android.Graphics.PorterDuff.Mode.SrcIn);
            }
#endif
        });
    }

    private void OnButtonClick(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }

    private void NotificationCountLabel_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NotificationsPageView());
    }
}
