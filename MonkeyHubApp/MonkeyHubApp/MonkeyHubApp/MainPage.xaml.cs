using MonkeyHubApp.Services;
using MonkeyHubApp.ViewModels;
using Xamarin.Forms;

namespace MonkeyHubApp
{
    public partial class MainPage
    {
        readonly MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            var monkeyHubApiService = DependencyService.Get<IMonkeyHubApiService>();
            _viewModel = new MainViewModel(monkeyHubApiService);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if(_viewModel != null)
                await _viewModel.LoadAsync();
        }
    }
}
