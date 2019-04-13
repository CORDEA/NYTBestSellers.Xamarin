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

            Container.RegisterInstance(typeof(NytClient));
            Container.RegisterInstance(typeof(ListNamesRemoteDataSource));
            Container.RegisterInstance(typeof(ListNamesLocalDataSource));
            Container.RegisterInstance(typeof(ListNamesRepository));
            Container.RegisterInstance(typeof(ListsRemoteDataSource));
            Container.RegisterInstance(typeof(ListsLocalDataSource));
            Container.RegisterInstance(typeof(ListsRepository));
        }
    }
}