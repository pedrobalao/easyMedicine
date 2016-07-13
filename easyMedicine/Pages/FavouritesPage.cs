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

			var cell = new DataTemplate(typeof(TextCell));
			cell.SetBinding(TextCell.TextProperty, "Name");

			var list = new ListView()
			{
				BindingContext = Model,
				ItemTemplate = cell

			};
			list.SetBinding(ListView.ItemsSourceProperty, FavouritesPageModel.DrugsPropertyName);

			list.ItemTapped += OnItemTapped;

			this.Content = list;
		}

		private void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item != null && this.Model.DrugSelectedCommand != null && this.Model.DrugSelectedCommand.CanExecute(e))
			{
				Model.DrugSelectedCommand.Execute(e.Item);
			}
		}
	}
}

