using System;
using System.Diagnostics;
using easyMedicine.iOS;
using easyMedicine.Pages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(eMNavigationPage), typeof(NavigationPageRenderer))]
namespace easyMedicine.iOS
{
    public class NavigationPageRenderer : NavigationRenderer
    {
        public NavigationPageRenderer() : base()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Console.WriteLine("Debug NavigationPageRenderer");
            // remove lower border and shadow of the navigation bar
            NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIImage();
            try
            {
                OverrideUserInterfaceStyle = UIUserInterfaceStyle.Light;
            }
            catch (Exception e1)
            {
                Console.WriteLine("The device doesn't support OverrideUserInterfaceStyle");
            }


        }
    }
}

