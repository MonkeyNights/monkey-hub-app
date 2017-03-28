using MonkeyHubApp.Models;
using MonkeyHubApp.ViewModels;

namespace MonkeyHubApp
{
    public partial class ContentWebPage
    {
        public ContentWebPage(Content content)
        {
            InitializeComponent();
            BindingContext = new ContentWebViewModel(content);
        }
    }
}
