using System;
using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace mikoba.Droid
{
    #if DEBUG
        [Application(Debuggable = true)]
    #else
        [Application(Debuggable = false)]
    #endif
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
            : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Shiny.AndroidShinyHost.Init(
                this,
                new ShinyStartupXamarin()
            );
            CrossCurrentActivity.Current.Init(this);
        }
    }
}