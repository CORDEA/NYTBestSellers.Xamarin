using Unity;

namespace NYTBestSellers
{
    public class App
    {
        public static App Current { get; private set; }

        public IUnityContainer Container { get; }

        public static void Initialize()
        {
            Current = new App();
        }

        private App()
        {
            Container = new UnityContainer();
        }
    }
}