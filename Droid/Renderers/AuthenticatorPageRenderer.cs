using System;
using easymedicine.Droid.Renderers;
using easyMedicine.Pages;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:
    ExportRenderer
        (
            typeof(AuthenticatorPage),
            typeof(AuthenticatorPageRenderer)
        )
]

namespace easymedicine.Droid.Renderers
{
    [global::Android.Runtime.Preserve(AllMembers = true)]
    public class AuthenticatorPageRenderer : Xamarin.Forms.Platform.Android.PageRenderer
    {
        protected Xamarin.Auth.Authenticator Authenticator;
        protected AuthenticatorPage authenticator_page;

        public AuthenticatorPageRenderer(Android.Content.Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            global::Android.App.Activity activity = this.Context as global::Android.App.Activity;


            authenticator_page = (AuthenticatorPage)base.Element;

            Authenticator = authenticator_page.Authenticator;
            Authenticator.Completed += Authentication_Completed;
            Authenticator.Error += Authentication_Error;

            global::Android.Content.Intent ui_object = Authenticator.GetUI(activity);

            activity.StartActivity(ui_object);

            return;
        }


        protected void Authentication_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            authenticator_page.Authentication_Completed(sender, e);

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



