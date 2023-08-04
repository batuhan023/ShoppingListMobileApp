namespace ShoppingListMobileApp1;

public partial class EditPageView : ContentPage
{
	public EditPageView()
	{
		InitializeComponent();
	}

   
    void BackBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }

    void SaveBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new ItemPageView());
    }
}
