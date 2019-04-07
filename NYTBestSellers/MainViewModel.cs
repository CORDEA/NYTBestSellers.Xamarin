using Unity;

namespace NYTBestSellers
{
    public class MainViewModel : IViewModel
    {
        [Dependency] internal NytClient Client { get; set; }

        public MainViewModel()
        {
        }
    }
}