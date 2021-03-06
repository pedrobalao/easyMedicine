﻿using System;

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
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using easymedicine.Droid.Services;

namespace easymedicine.Droid
{

    [Activity(Label = "easymedicine.Droid", Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity//global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Window.SetSoftInputMode(Android.Views.SoftInput.AdjustResize);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);


            AppCenter.Start(Secrets.AndroidAppCenterAppID, typeof(Analytics), typeof(Crashes), typeof(Push));

            var app = new App();
            RegisterComponents(app.BootStrapper);
            LoadApplication(app);
        }

        private void RegisterComponents(Bootstrapper boot)
        {
            boot.RegisterPlatformService<ISQLite>(new AndroidSQLite());
            boot.RegisterPlatformService<IFirebaseAuth>(new AndroidFirebaseAuth());
            /*boot.RegisterPlatformService<ILocalizeService> (new IosLocalizeService ());
            boot.RegisterPlatformService<ISocketIOService> (new IOSSocketIOService ());*/
            boot.Start();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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
