using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMonkeyHubApiService _monkeyHubApiService;
        public ObservableCollection<Tag> Tags { get; }

        public Command AboutCommand { get; }

        public Command<Tag> ShowCategoriaCommand { get; }

        public MainViewModel(IMonkeyHubApiService monkeyHubApiService)
        {
            _monkeyHubApiService = monkeyHubApiService;
            Tags = new ObservableCollection<Tag>();
            AboutCommand = new Command(ExecuteAboutCommand);
            ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);
        }

        private async void ExecuteShowCategoriaCommand(Tag tag)
        {
            await PushAsync<CategoriaPage>(tag);
        }

        private async void ExecuteAboutCommand()
        {
            await PushAsync<AboutPage>();
        }

        public async Task LoadAsync()
        {
            var tags = await _monkeyHubApiService.GetTagsAsync();

            Tags.Clear();
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}
