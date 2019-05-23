using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using easyMedicine.iOS.Data;
using easyMedicine.Services;
using System.IO;
using UserNotifications;
using Firebase.CloudMessaging;
using System;
using System.Globalization;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;

namespace easyMedicine.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUNUserNotificationCenterDelegate
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

            AppCenter.Start("f4b28f29-a8b8-4197-870e-35aec416753a", typeof(Analytics), typeof(Crashes), typeof(Push));
            global::Xamarin.Forms.Forms.Init();

            //UserDialogs.Init(() => (Activity)Forms.Context);

            Firebase.Core.App.Configure();
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

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            // Register your app for remote notifications.
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // iOS 10 or later
                var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
                UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
                {
                    System.Console.WriteLine(granted);
                });

                // For iOS 10 display notification (sent via APNS)
                UNUserNotificationCenter.Current.Delegate = this;

                // For iOS 10 data message (sent via FCM)
                //Messaging.SharedInstance.RemoteMessageDelegate = this;
            }
            else
            {
                // iOS 9 or before
                var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }

            UIApplication.SharedApplication.RegisterForRemoteNotifications();

        }

        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, System.Action<UIBackgroundFetchResult> completionHandler)
        {

            // If you are receiving a notification message while your app is in the background,
            // this callback will not be fired 'till the user taps on the notification launching the application.

            // Do your magic to handle the notification data
            System.Console.WriteLine(userInfo);

            base.DidReceiveRemoteNotification(application, userInfo, completionHandler);

        }


        // To receive notifications in foreground on iOS 10 devices.
        [Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
        public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // Do your magic to handle the notification data
            System.Console.WriteLine(notification.Request.Content.UserInfo);
            UIAlertView avAlert = new UIAlertView(notification.Request.Content.Title, notification.Request.Content.Body, null, "OK", null);
            avAlert.Show();
        }

        // Receive data message on iOS 10 devices.
        public void ApplicationReceivedRemoteMessage(RemoteMessage remoteMessage)
        {
            Console.WriteLine(remoteMessage.AppData);
        }
    }


}

