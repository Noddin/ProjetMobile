using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    public partial class EditItemPage : ContentPage
    {
        EditItemViewModel viewModel;

        public EditItemPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            BindingContext = viewModel = new EditItemViewModel(item);
        }

        public EditItemPage(EditItemViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Update_Clicked(object sender, EventArgs e)
        {
            await viewModel.ExecuteUpdateCommandAsync();
            await Navigation.PopAsync();
        }
    }
}