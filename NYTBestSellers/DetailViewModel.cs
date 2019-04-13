using System.Reactive.Linq;
using Reactive.Bindings;
using Unity;

namespace NYTBestSellers
{
    public class DetailViewModel : IViewModel
    {
        [Dependency] internal ListsRepository Repository { get; set; }

        public ReadOnlyReactiveProperty<ListResponse> Item { get; private set; }

        public readonly ReactiveCommand<int> OnAttach = new ReactiveCommand<int>();

        [InjectionMethod]
        internal void Initialize()
        {
            Item = OnAttach
                .Select(position => Repository.Find(position))
                .ToReadOnlyReactiveProperty(mode: ReactivePropertyMode.DistinctUntilChanged);
        }
    }
}