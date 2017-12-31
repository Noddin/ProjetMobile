using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp.ViewModels
{ 
    public class EditItemViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Command UpdateCommand { get; set; }

        public EditItemViewModel(Item item)
        {
            Item = new Item
            {
                Id = item.Id,
                Text = item.Text,
                Description = item.Description,
            };

            Title = Item?.Text;

            UpdateCommand = new Command(async () => await ExecuteUpdateCommandAsync());
        }

        public async Task ExecuteUpdateCommandAsync()
        {
            await DataStore.UpdateItemAsync(Item);
        }
    }
}
