namespace MonkeyHubApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new MonkeyHubApp.App());
        }
    }
}
