using MonkeyHubApp.Models;

namespace MonkeyHubApp.ViewModels
{
    public class ContentWebViewModel : BaseViewModel
    {
        private readonly Content _content;

        public ContentWebViewModel(Content content)
        {
            _content = content;
        }
    }
}
