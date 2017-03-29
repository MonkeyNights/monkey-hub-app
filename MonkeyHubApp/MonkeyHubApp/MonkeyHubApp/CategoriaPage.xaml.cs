using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using MonkeyHubApp.ViewModels;
using Xamarin.Forms;

namespace MonkeyHubApp
{
    public partial class CategoriaPage
    {
        private readonly CategoriaViewModel _viewModel;

        public CategoriaPage(Tag tag)
        {
            InitializeComponent();
            var monkeyHubApiService = DependencyService.Get<IMonkeyHubApiService>();
            _viewModel = new CategoriaViewModel(monkeyHubApiService, tag);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel != null)
                await _viewModel.LoadAsync();
        }
    }
}
