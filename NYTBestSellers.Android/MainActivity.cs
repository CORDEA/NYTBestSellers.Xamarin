using System;
using System.Linq;
using System.Reactive.Linq;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
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

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            var spinner = FindViewById<Spinner>(Resource.Id.spinner);

            ViewModel.Items
                .Select(response => response.Results.Select(result => result.EncodedName))
                .ObserveOnUIDispatcher()
                .Select(names =>
                    new ArrayAdapter<string>(
                        this,
                        global::Android.Resource.Layout.SimpleSpinnerDropDownItem,
                        names.ToList()
                    )
                )
                .Subscribe(adapter => { spinner.Adapter = adapter; });
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