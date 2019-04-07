using System;
using Android.App;
using Android.Runtime;

namespace NYTBestSellers.Android
{
    [Application]
    public class App : Application
    {
        public App()
        {
        }

        public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }
    }
}
