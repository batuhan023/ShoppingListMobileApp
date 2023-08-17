
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using ShoppingListMobileApp1.Services;

namespace ShoppingListMobileApp1.Views;

public partial class CategoryPage1 : ContentPage
{
    private readonly CategoriesService _categroiesService = new CategoriesService();
    private readonly ItemService _ýtemService = new ItemService();
    public CategoryPage1(int categoryId, string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		GetItemsById(categoryId);
	}

    private async void GetItemsById(int categoryId)
    {
        List<Item> ýtems = await _ýtemService.GetItemsByCategory(categoryId);
        categoryDetail.ItemsSource = ýtems;
        
    }

    void categoryDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentselection = e.CurrentSelection.FirstOrDefault() as Item;
        if (currentselection == null) return;
        Navigation.PushModalAsync(new ItemDetailPageView(currentselection.Id));
        ((CollectionView)sender).SelectedItem = null;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var currentselection = button?.CommandParameter as Item;
        if (currentselection == null) return;
        Navigation.PushAsync(new ItemDetailPageView(currentselection.Id));
        //button.CommandParameter = null;
    }
}