using System.Reactive.Threading.Tasks;
using Reactive.Bindings;
using Unity;

namespace NYTBestSellers
{
    public class MainViewModel : IViewModel
    {
        [Dependency] internal BestSellerRepository Repository { get; set; }

        public ReadOnlyReactiveProperty<ListNamesResponse> Items { get; private set; }

        [InjectionMethod]
        internal void Initialize()
        {
            Items = Repository.GetListNames()
                .ToObservable()
                .ToReadOnlyReactiveProperty(mode: ReactivePropertyMode.DistinctUntilChanged);
        }
    }
}