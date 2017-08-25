using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using easyMedicine.Droid.Data;
using easyMedicine.Services;

namespace easyMedicine.Droid
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
}

