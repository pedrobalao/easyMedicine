using System;
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
			// remove lower border and shadow of the navigation bar
			NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			NavigationBar.ShadowImage = new UIImage();
		}
	}
}

