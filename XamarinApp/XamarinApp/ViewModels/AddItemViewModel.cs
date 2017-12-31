using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp.ViewModels
{
    class AddItemViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Command SaveCommand { get; set; }

        public AddItemViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
            SaveCommand = new Command(async () => await ExecuteSaveCommandAsync());
        }

        public async Task ExecuteSaveCommandAsync()
        {         
            await DataStore.AddItemAsync(Item);
        }
    }
}
