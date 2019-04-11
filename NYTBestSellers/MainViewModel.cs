using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Reactive.Bindings;
using Unity;

namespace NYTBestSellers
{
    public class MainViewModel : IViewModel
    {
        [Dependency] internal BestSellerRepository Repository { get; set; }

        public ReadOnlyReactiveProperty<ListNamesResponse> ListNameItems { get; private set; }

        public ReadOnlyReactiveProperty<ListsResponse> ListItems { get; private set; }

        public readonly ReactiveCommand<string> OnItemSelected = new ReactiveCommand<string>();

        [InjectionMethod]
        internal void Initialize()
        {
            ListNameItems = Repository.GetListNames()
                .ToObservable()
                .ToReadOnlyReactiveProperty(mode: ReactivePropertyMode.DistinctUntilChanged);

            ListItems = OnItemSelected
                .SelectMany(list => Repository.GetLists(list).ToObservable())
                .ToReadOnlyReactiveProperty(mode: ReactivePropertyMode.DistinctUntilChanged);
        }
    }
}