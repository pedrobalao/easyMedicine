using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Foundation;
using UIKit;
using easyMedicine.iOS.Data;
using easyMedicine.Services;
using System.IO;

namespace easyMedicine.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //MobileCenter.Start("f4b28f29-a8b8-4197-870e-35aec416753a",
            //typeof(Analytics), typeof(Crashes));

            /*
			var appdir = NSBundle.MainBundle.ResourcePath;
			var seedFile = Path.Combine (appdir, "data.sqlite");
			if (!File.Exists (Database.DatabaseFilePath))
				File.Copy (seedFile, Database.DatabaseFilePath);
*/
            global::Xamarin.Forms.Forms.Init();

            var app1 = new App();

            RegisterComponents(app1.BootStrapper);


            LoadApplication(app1);

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = UIFont.FromName("Avenir-Book", 20),
            });



            UITabBarItem.Appearance.SetTitleTextAttributes(
                new UITextAttributes()
                {
                    Font = UIFont.FromName("Avenir-Book", 10),
                }, UIControlState.Normal);
            //UISearchBar.Appearance. = UIColor.Red;

            return base.FinishedLaunching(app, options);
        }

        private void RegisterComponents(Bootstrapper boot)
        {
            boot.RegisterPlatformService<ISQLite>(new IOSSQLite());
            /*boot.RegisterPlatformService<ILocalizeService> (new IosLocalizeService ());
			boot.RegisterPlatformService<ISocketIOService> (new IOSSocketIOService ());*/
            boot.Start();
        }
    }


}

