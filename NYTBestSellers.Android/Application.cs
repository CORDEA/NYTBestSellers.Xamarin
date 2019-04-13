using System;
using Android.App;
using Android.Runtime;

namespace NYTBestSellers.Android
{
    [Application]
    public class Application : global::Android.App.Application
    {
        public Application(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            App.Initialize(new MainNavigator(this));
        }
    }
}