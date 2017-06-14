using System;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Xamarin.Forms;

namespace easyMedicine
{


    public class App : Application
    {
        public Bootstrapper BootStrapper;

        public App()
        {
            //GmsDirection.Init ("AIzaSyAzlgYgYEQFVR-j2t6auJuXUoF3Y6s1Efk");
            Styles.LoadStyles();
            this.BootStrapper = new Bootstrapper(this);


            //System.AppDomain.UnhandledException+=
        }

        protected override void OnStart()
        {
            MobileCenter.Start("ios=f4b28f29-a8b8-4197-870e-35aec416753a;",
                   typeof(Analytics), typeof(Crashes));
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

