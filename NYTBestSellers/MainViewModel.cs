using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Reactive.Bindings;
using Unity;

namespace NYTBestSellers
{
    public class MainViewModel : IViewModel
    {
        [Dependency] internal ListNamesRepository ListNamesRepository { get; set; }
        [Dependency] internal ListsRepository ListsRepository { get; set; }
        [Dependency] internal IMainNavigator Navigator { get; set; }

        public ReadOnlyReactiveProperty<ListNamesResponse> ListNameItems { get; private set; }

        public ReadOnlyReactiveProperty<ListsResponse> ListItems { get; private set; }

        public readonly ReactiveCommand<string> OnSpinnerItemSelected = new ReactiveCommand<string>();

        public readonly ReactiveCommand<int> OnItemSelected = new ReactiveCommand<int>();

        [InjectionMethod]
        internal void Initialize()
        {
            ListNameItems = ListNamesRepository.Get()
                .ToObservable()
                .ToReadOnlyReactiveProperty(mode: ReactivePropertyMode.DistinctUntilChanged);

            ListItems = OnSpinnerItemSelected
                .SelectMany(list => ListsRepository.Get(list).ToObservable())
                .ToReadOnlyReactiveProperty(mode: ReactivePropertyMode.DistinctUntilChanged);

            OnItemSelected
                .Subscribe(position => Navigator.NavigateToDetail(position));
        }
    }
}