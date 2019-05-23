using System;
using System.Globalization;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;

namespace easyMedicine
{


    public class App : Application
    {
        public Bootstrapper BootStrapper;

        public App()
        {
            //GmsDirection.Init ("AIzaSyAzlgYgYEQFVR-j2t6auJuXUoF3Y6s1Efk");
            Styles.LoadStyles();
            SetCultureToUSEnglish();
            this.BootStrapper = new Bootstrapper(this);


            //System.AppDomain.UnhandledException+=
        }


        private void SetCultureToUSEnglish()
        {
            CultureInfo englishUSCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = englishUSCulture;
        }

        protected override void OnStart()
        {
            //MobileCenter.Start("ios=f4b28f29-a8b8-4197-870e-35aec416753a;",
            //typeof(Analytics), typeof(Crashes));

            AppCenter.Start("android=f883dc1d-c988-4a56-b2b8-1c4552c60c30;" +
                   "uwp={Your UWP App secret here};" +
                   "ios=f4b28f29-a8b8-4197-870e-35aec416753a;",
                   typeof(Analytics), typeof(Crashes), typeof(Push));


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

