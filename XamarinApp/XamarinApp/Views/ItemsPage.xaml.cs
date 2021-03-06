﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinApp
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(item.Id));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
                    
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}