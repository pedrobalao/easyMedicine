using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
	public class FavouritesPage : ContentPageBase
	{
		private FavouritesPageModel Model {
			get {
				return (FavouritesPageModel)base._model;
			}
		}


		public FavouritesPage (FavouritesPageModel model) : base (model)
		{
			Title = "Favoritos";
			Icon = "ic_favorite_36pt.png";

			var layout = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			var label = new Label () {
				Text = "Favourites",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand,

			};
			layout.Children.Add (label);
			this.Content = layout;
		}
	}
}

