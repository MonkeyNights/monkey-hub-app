using MonkeyHubApp.ViewModels;

namespace MonkeyHubApp
{
    public partial class MainPage
    {
        readonly MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
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
