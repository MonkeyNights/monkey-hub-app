using MonkeyHubApp.ViewModels;

namespace MonkeyHubApp
{
    public partial class CategoriaPage
    {
        private CategoriaViewModel ViewModel => BindingContext as CategoriaViewModel;

        public CategoriaPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
                await ViewModel.LoadAsync();
        }
    }
}
