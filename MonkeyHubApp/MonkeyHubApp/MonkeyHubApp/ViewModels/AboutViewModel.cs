using Version.Plugin;

namespace MonkeyHubApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string Versao => CrossVersion.Current.Version;
    }
}
