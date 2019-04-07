using Android.OS;
using Android.Support.V7.App;
using Unity;

namespace NYTBestSellers.Android
{
    public class UnityActivity<T> : AppCompatActivity where T : IViewModel
    {
        protected T ViewModel { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ViewModel = App.Current.Container.Resolve<T>();
        }
    }
}