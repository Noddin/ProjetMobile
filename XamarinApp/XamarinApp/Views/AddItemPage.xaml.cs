using System;

using Xamarin.Forms;
using XamarinApp.ViewModels;

namespace XamarinApp
{
    public partial class AddItemPage : ContentPage
    {
        AddItemViewModel viewModel;

        public AddItemPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Enter an Item Name",
                Description = "Enter an Item description."
            };

            viewModel = new AddItemViewModel(item);
            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
        //  MessagingCenter.Send(this, "AddItem", viewModel.Item);
        //  viewModel.SaveCommand.Execute(null);
            await viewModel.ExecuteSaveCommandAsync();
            await Navigation.PopToRootAsync();
        }
    }
}
