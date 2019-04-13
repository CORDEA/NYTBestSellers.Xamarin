using Unity;
using Unity.Lifetime;

namespace NYTBestSellers
{
    public class App
    {
        public static App Current { get; private set; }

        public IUnityContainer Container { get; }

        public static void Initialize(IMainNavigator navigator)
        {
            Current = new App(navigator);
        }

        private App(IMainNavigator navigator)
        {
            Container = new UnityContainer();

            Container.RegisterType<NytClient>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ListNamesRemoteDataSource>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ListNamesLocalDataSource>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ListNamesRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ListsRemoteDataSource>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ListsLocalDataSource>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ListsRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterInstance(navigator);
        }
    }
}