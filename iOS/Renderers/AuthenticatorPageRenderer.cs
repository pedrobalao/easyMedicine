using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SafariServices;
using UIKit;
using Xamarin.Auth;
using easyMedicine.iOS.Renderers;
using easyMedicine.Pages;
using Xamarin.Auth.XamarinForms;

[assembly:
    ExportRenderer
        (
            typeof(easyMedicine.Pages.AuthenticatorPage),
            typeof(easyMedicine.iOS.Renderers.AuthenticatorPageRenderer)
        )
]
namespace easyMedicine.iOS.Renderers
{
    [Preserve(AllMembers = true)]

    public class AuthenticatorPageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer

    {
        bool renderer_was_shown;
        bool oauth_was_shown;

        UIKit.UIViewController uiviewcontorller;

        public override void ViewDidAppear(bool animated)
        {
            if (oauth_was_shown)
            {
                // close Xamarin.Auth.XamarinForms.AuthenticatorPage
                this.DismissViewController
                        (
                            true,
                            async delegate
                            {
                                return;
                            }
                       );
            }

            if (!renderer_was_shown)
            {
                renderer_was_shown = true;

                base.ViewDidAppear(animated);

                authenticator_page = (easyMedicine.Pages.AuthenticatorPage)base.Element;

                Authenticator = authenticator_page.Authenticator;
                Authenticator.Completed += Authentication_Completed;
                Authenticator.Error += Authentication_Error;

                uiviewcontorller = Authenticator.GetUI();
                PresentViewController
                    (
                        uiviewcontorller,
                        true,
                        () =>
                        {
                            oauth_was_shown = true;
                        }
                    );
            }

            return;
        }

        /*
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            authenticator_page = (AuthenticatorPage)base.Element;
            Authenticator = authenticator_page.Authenticator;
            Authenticator.Completed += Authentication_Completed;
            Authenticator.Error += Authentication_Error;
            // create a new window instance based on the screen size
            window = new UIKit.UIWindow(UIKit.UIScreen.MainScreen.Bounds);
            var ui = Authenticator.GetUI();
            // If you have defined a view, add it here:
            // window.RootViewController  = navigationController;
            window.RootViewController = ui;
            // make the window visible
            window.MakeKeyAndVisible();
            return;
        }

        UIKit.UIWindow window;
        */

        public static Authenticator Authenticator = null;
        public easyMedicine.Pages.AuthenticatorPage authenticator_page = null;

        protected void Authentication_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            authenticator_page.Authentication_Completed(sender, e);

            this.DismissViewController
                    (
                        true,
                        async delegate
                        {
                            return;
                        }
                   );

            return;
        }

        protected void Authentication_Error(object sender, AuthenticatorErrorEventArgs e)
        {

            authenticator_page.Authentication_Error(sender, e);

            return;
        }

        protected void Authentication_BrowsingCompleted(object sender, EventArgs e)
        {
            authenticator_page.Authentication_BrowsingCompleted(sender, e);

            return;
        }
    }
}