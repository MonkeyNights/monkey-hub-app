using MonkeyHubApp.Models;

namespace MonkeyHubApp.ViewModels
{
    public class ContentWebViewModel : BaseViewModel
    {
        public Content ContentWeb { get; }

        public ContentWebViewModel(Content content)
        {
            ContentWeb = content;
        }
    }
}
