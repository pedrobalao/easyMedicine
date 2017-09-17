using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;

namespace easymedicine.Droid
{

    [Activity(Theme = "@style/MyTheme.Splash", //Indicates the theme to use for this activity
             MainLauncher = true, //Set it as boot activity
             NoHistory = true)] //Doesn't place it in back stack
    public class SplashActivity : Activity
    {
        //    protected override void OnCreate(Bundle bundle)
        //    {
        //        base.OnCreate(bundle);
        //        System.Threading.Thread.Sleep(3000); //Let's wait awhile...
        //        this.StartActivity(typeof(MainActivity));
        //    }


        System.Timers.Timer timer = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Console.Write("OnCreate");
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashLayout);

            timer = new System.Timers.Timer();
            timer.Interval = 1500;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            timer.Start();
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            StartActivity(typeof(MainActivity));
            Finish();
        }

        protected override void OnResume()
        {
            Console.Write("Resume");
            base.OnResume();
        }
    }

}