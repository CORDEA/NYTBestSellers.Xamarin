using Android.Content;

namespace NYTBestSellers.Android
{
    public class MainNavigator : IMainNavigator
    {
        private Context _context;

        public MainNavigator(Context context)
        {
            _context = context;
        }

        public void NavigateToDetail(int position)
        {
            _context.StartActivity(DetailActivity.CreateIntent(_context, position));
        }
    }
}