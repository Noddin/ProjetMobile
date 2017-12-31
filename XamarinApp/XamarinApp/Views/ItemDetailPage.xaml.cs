using System;

using Xamarin.Forms;
using XamarinApp.ViewModels;
using XamarinApp.Views;

namespace XamarinApp
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent(); 

        }

        public ItemDetailPage(string itemId)
        {
            InitializeComponent();

            BindingContext = this.viewModel = new ItemDetailViewModel(itemId);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await this.viewModel.OnAppear();
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            await viewModel.ExecuteDeleteCommandAsync();
            await Navigation.PopToRootAsync();
        }

        async void EditItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditItemPage(new EditItemViewModel (viewModel.Item)));
        }

    }
}
