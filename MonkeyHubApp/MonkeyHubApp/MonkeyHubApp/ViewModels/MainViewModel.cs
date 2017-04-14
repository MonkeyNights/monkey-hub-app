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

        public Command SearchCommand { get; }

        public Command<Tag> ShowCategoriaCommand { get; }

        public MainViewModel(IMonkeyHubApiService monkeyHubApiService)
        {
            _monkeyHubApiService = monkeyHubApiService;
            Tags = new ObservableCollection<Tag>();
            AboutCommand = new Command(ExecuteAboutCommand);
            SearchCommand = new Command(ExecuteSearchCommand);
            ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);

            Title = "Monkey Hub";
        }

        private async void ExecuteSearchCommand()
        {
            await PushAsync<SearchViewModel>();
        }

        private async void ExecuteShowCategoriaCommand(Tag tag)
        {
            await PushAsync<CategoriaViewModel>(tag);
        }

        private async void ExecuteAboutCommand()
        {
            await PushAsync<AboutViewModel>();
        }

        public override async Task LoadAsync()
        {
            var tags = await _monkeyHubApiService.GetTagsAsync();

            System.Diagnostics.Debug.WriteLine("FOUND {0} TAGS", tags.Count); 
            Tags.Clear();
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }

            OnPropertyChanged(nameof(Tags));
        }
    }
}
