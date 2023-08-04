using ShoppingListMobileApp1;

namespace ShoppingListMobileApp1;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
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