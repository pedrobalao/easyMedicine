using System;
using easyMedicine;
using easyMedicine.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Linq;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace easyMedicine.iOS
{


	public class CustomTabbedPageRenderer : TabbedRenderer
	{
		public CustomTabbedPageRenderer()
		{
			//TabBar.TintColor = UIColor.White;
			//TabBar.BackgroundColor = UIColor.White;
			//TabBar.BarTintColor = ExtensionMethods.ToUIColor("0078D7");
			//TabBar.SelectedImageTintColor = UIColor.White;

			//	TabBar.colo = UIColor.Green;
			//TabBar.Subviews[0].RemoveFromSuperview();
			//TabBar.backgroundColor = [UIColor darkGrayColor]; // this will be your background
		}

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

		}
	}


}


