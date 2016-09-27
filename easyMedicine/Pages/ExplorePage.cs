using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
	public class ExplorePage : ContentPageBase
	{
		private ExplorePageModel Model {
			get {
				return (ExplorePageModel)base._model;
			}
		}


		public ExplorePage (ExplorePageModel model) : base (model)
		{
			Title = "Explorar";
			Icon = "ic_explore_white_48px.png";
			var layout = new StackLayout () {
				
			};


			var cell = new DataTemplate(typeof(CustomCell));
			cell.SetBinding(CustomCell.NameProperty, "Description");


			var list = new ListView()
			{
				BindingContext = Model,
				ItemTemplate = cell,
				HasUnevenRows = true,
				SeparatorColor = Styles.BLUE_COLOR,
			};
			list.SetBinding(ListView.ItemsSourceProperty, ExplorePageModel.ClinicalCategoriesPropertyName);
			list.SetBinding(ListView.SelectedItemProperty, ExplorePageModel.SelectedClinicalCategoryPropertyName, BindingMode.TwoWay);
			list.ItemTapped += OnItemTapped;

			layout.Children.Add (list);
			Content = layout;
		}

		private void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item != null && this.Model.CategorySelectedCommand != null && this.Model.CategorySelectedCommand.CanExecute(e))
			{
				Model.CategorySelectedCommand.Execute(e.Item);
			}
		}
	}
}

