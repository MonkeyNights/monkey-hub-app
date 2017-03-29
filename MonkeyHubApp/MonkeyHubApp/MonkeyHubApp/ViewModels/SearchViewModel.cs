using System.Collections.ObjectModel;
using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly IMonkeyHubApiService _monkeyHubApiService;
        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                SetProperty(ref _searchTerm, value);
                SearchCommand.ChangeCanExecute();
            }
        }

        public Command SearchCommand { get; }

        public ObservableCollection<Content> SearchResults { get; }

        public Command<Content> ShowContentCommand { get; }

        public SearchViewModel(IMonkeyHubApiService monkeyHubApiService)
        {
            _monkeyHubApiService = monkeyHubApiService;

            SearchResults = new ObservableCollection<Content>();
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
            ShowContentCommand = new Command<Content>(ExecuteShowContentCommand);
        }

        private async void ExecuteShowContentCommand(Content content)
        {
            await PushAsync<ContentWebViewModel>(content);
        }

        private bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }

        private async void ExecuteSearchCommand()
        {
            var searchResults = await _monkeyHubApiService.GetContentsByFilterAsync(SearchTerm);

            SearchResults.Clear();
            if (searchResults != null)
            {
                foreach (var searchResult in searchResults)
                {
                    SearchResults.Add(searchResult);
                }
            }
        }
    }
}
