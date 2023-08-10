namespace ShoppingListMobileApp1.Views;

public partial class ProfilePage1 : ContentPage
{
    public ProfilePage1()
    {
        InitializeComponent();



    }

    void EditBtn1_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new EditPageView());

    }

    private void SignoutBtn1_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}