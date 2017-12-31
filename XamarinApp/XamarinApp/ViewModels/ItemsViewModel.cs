using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinApp.Views;

namespace XamarinApp
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

         

            //MessagingCenter.Subscribe<EditItemPage, Item>(this, "UpdateItem", async (obj, item) =>
            //{
            //    await DataStore.UpdateItemAsync(item);
            //});

            //MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "DeleteItem", async (obj, item) =>
            //{
            //    Items.Remove(item);
            //    await DataStore.DeleteItemAsync(item.Id);
            //});
        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;


            Items.Clear();
            var items = await DataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Items.Add(item);
            }

            IsBusy = false;
     

        }
    }
}
