using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using easyMedicine;
using easyMedicine.Services;
using easyMedicine.Droid.Data;

namespace easymedicine.Droid
{

    [Activity(Label = "easyMedicine.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);


            //Bootstrapper.Instance.Start();
            //boot.RegisterPlatformService<ISQLite>(new IOSSQLite());
            var app = new App();
            RegisterComponents(app.BootStrapper);
            LoadApplication(new App());
        }

        private void RegisterComponents(Bootstrapper boot)
        {
            boot.RegisterPlatformService<ISQLite>(new AndroidSQLite());
            /*boot.RegisterPlatformService<ILocalizeService> (new IosLocalizeService ());
            boot.RegisterPlatformService<ISocketIOService> (new IOSSocketIOService ());*/
            boot.Start();
        }
    }

    //[Activity(Label = "easymedicine.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    //{
    //    protected override void OnCreate(Bundle bundle)
    //    {
    //        TabLayoutResource = Resource.Layout.Tabbar;
    //        ToolbarResource = Resource.Layout.Toolbar;

    //        base.OnCreate(bundle);

    //        global::Xamarin.Forms.Forms.Init(this, bundle);

    //        LoadApplication(new App());
    //    }

    //    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    //    {
    //        base.OnActivityResult(requestCode, resultCode, data);
    //    }
    //}
}
