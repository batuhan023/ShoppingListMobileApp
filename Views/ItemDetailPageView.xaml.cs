using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

using ShoppingListMobileApp1.ViewModels;

namespace ShoppingListMobileApp1
{
    public partial class ItemDetailPageView : ContentPage
    {
        public ItemDetailPageView()
        {
            InitializeComponent();
            BindingContext = new ItemDetailPageViewModel();
        }
    }
}
