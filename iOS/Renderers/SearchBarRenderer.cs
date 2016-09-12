using System;
using easyMedicine.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace easyMedicine.iOS
{
	public class CustomSearchBarRenderer : SearchBarRenderer
	{
		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			Control.SearchBarStyle= UIKit.UISearchBarStyle.Minimal;
		}
	}
}

