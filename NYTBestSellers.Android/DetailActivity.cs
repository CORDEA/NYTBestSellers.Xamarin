using System;
using System.Linq;
using System.Reactive.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Reactive.Bindings.Extensions;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace NYTBestSellers.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class DetailActivity : UnityActivity<DetailViewModel>
    {
        private const string PositionKey = "position";

        public static Intent CreateIntent(Context context, int position)
        {
            var intent = new Intent(context, typeof(DetailActivity));
            intent.PutExtra(PositionKey, position);
            return intent;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var position = Intent.GetIntExtra(PositionKey, 0);

            var description = FindViewById<TextView>(Resource.Id.description);
            var author = FindViewById<TextView>(Resource.Id.author);
            var publisher = FindViewById<TextView>(Resource.Id.publisher);
            ViewModel.Item
                .Select(item => item.BookDetail.First())
                .ObserveOnUIDispatcher()
                .Subscribe(item =>
                {
                    toolbar.Title = item.Title;
                    description.Text = item.Description;
                    author.Text = item.Author;
                    publisher.Text = item.Publisher;
                });

            ViewModel.OnAttach.Execute(position);
        }
    }
}