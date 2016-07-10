using System;
using Xamarin.Forms;
using easyMedicine.Core.Models;

namespace easyMedicine.Pages
{
	public class ContentPageBase : ContentPage
	{
		public bool CancelsTouchesInView = true;

		protected PageModelBase _model;

		View l = new StackLayout ();

		public ContentPageBase (PageModelBase model)
		{
			_model = model;
			BindingContext = model;
			if (model.IsShareActive) {

				ToolbarItems.Add (new ToolbarItem ("Share", "share.png", () => {
					model.Share ();
				}));
			}


			/*StackLayout layout = new StackLayout ();


			base.Content = layout;*/
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();
			await _model.LoadAsync ();

		}

		protected async override void OnDisappearing ()
		{
			base.OnDisappearing ();
			await _model.UnloadAsync ();
		}

		/*
		public new View Content {
			get {
				return l;
			}
			set {
				((StackLayout)l).Children.Add (value);
			}
		}
		*/

	}
}

