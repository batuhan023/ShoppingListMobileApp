
using EntityLayer.DTOs;
using ShoppingListMobileApp1.Services;

namespace ShoppingListMobileApp1.Views;

public partial class CategoryPage1 : ContentPage
{
    private readonly CategoriesService _categroiesService = new CategoriesService();
    public CategoryPage1(int categoryId, string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		GetCategoriesById(categoryId);
	}

    private async Task<List<GetCategoryDTO>> GetCategoriesById(int categoryId)
    {
        List<GetCategoryDTO> categories = await _categroiesService.GetCategoriesById(categoryId);
        categoryDetail.ItemsSource = categories;
        return categories;
    }
}