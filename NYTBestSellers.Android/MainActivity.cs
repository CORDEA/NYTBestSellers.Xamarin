using System;
using System.Linq;
using System.Reactive.Linq;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace NYTBestSellers.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : UnityActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var spinner = FindViewById<Spinner>(Resource.Id.spinner);
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            var adapter = new MainAdapter(this);
            recyclerView.SetAdapter(adapter);

            ViewModel.ListNameItems
                .Select(response => response.Results.Select(result => result.EncodedName))
                .ObserveOnUIDispatcher()
                .Select(names =>
                    new ArrayAdapter<string>(
                        this,
                        global::Android.Resource.Layout.SimpleSpinnerDropDownItem,
                        names.ToList()
                    )
                )
                .Subscribe(arrAdapter => { spinner.Adapter = arrAdapter; });

            ViewModel.ListItems
                .Select(response =>
                    response.Results.Select(result =>
                        new MainListItemModel(result.DisplayName, result.BookDetail.First().Title)
                    ).ToList()
                )
                .ObserveOnUIDispatcher()
                .Subscribe(items => { adapter.Update(items); });

            Observable.FromEventPattern<AdapterView.ItemSelectedEventArgs>(spinner, nameof(spinner.ItemSelected))
                .Select(v => v.EventArgs.Parent.SelectedItem.ToString())
                .SetCommand(ViewModel.OnItemSelected);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener) null).Show();
        }
    }
}