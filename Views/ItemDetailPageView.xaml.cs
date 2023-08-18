using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.Maui.Controls;
using ShoppingListMobileApp1.Services;
using ShoppingListMobileApp1.ViewModels;

namespace ShoppingListMobileApp1
{
    public partial class ItemDetailPageView : ContentPage
    {
        private readonly ItemService itemservice = new ItemService();

        public ItemDetailPageView(int ıtemId)
        {
            InitializeComponent();
            BindingContext = new ItemDetailPageViewModel();
            GetItemDetail(ıtemId);
        }

        private async void GetItemDetail(int ıtemId)
        {
            var viewModel = BindingContext as ItemDetailPageViewModel;
            if (viewModel != null)
            {
                await viewModel.LoadItemDetail(ıtemId);
            }

        }
    }
}
