using Android.App;
using Android.Content;
using Android.OS;

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
        }
    }
}