using MonkeyHubApp.Models;
using MonkeyHubApp.ViewModels;

namespace MonkeyHubApp
{
    public partial class CategoriaPage
    {
        private readonly CategoriaViewModel _viewModel;

        public CategoriaPage(Tag tag)
        {
            InitializeComponent();
            _viewModel = new CategoriaViewModel(tag);
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
