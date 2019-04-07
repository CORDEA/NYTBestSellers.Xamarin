using Unity;

namespace NYTBestSellers
{
    public class MainViewModel
    {
        [Dependency] internal NytClient Client { get; set; }

        public MainViewModel()
        {
        }
    }
}