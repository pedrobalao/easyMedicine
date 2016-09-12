using System;
using easyMedicine.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListView), typeof(CustomListViewRenderer))]
namespace easyMedicine.iOS
{
	public class CustomListViewRenderer : ListViewRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.TableFooterView = new UIKit.UIView();
			}
			
		}

	}
}

