using System;
using easyMedicine.Pages;
using Xamarin.Forms;

namespace easyMedicine
{
	public class DrugExplorePage : ContentPageBase
	{

		private DrugExplorePageModel Model
		{
			get
			{
				return (DrugExplorePageModel)base._model;
			}
		}


		public DrugExplorePage(DrugExplorePageModel model) : base (model)
		{
			this.BindingContext = Model;
			this.SetBinding(TitleProperty, DrugExplorePageModel.SubCategoryDescriptionPropertyName);


			var cell = new DataTemplate(typeof(CustomCell));
			cell.SetBinding(CustomCell.NameProperty, "Name");
			cell.SetBinding(CustomCell.DetailProperty, "Name");


			var list = new ListView()
			{
				BindingContext = Model,
				ItemTemplate = cell,
					HasUnevenRows = true,
				SeparatorColor = Styles.BLUE_COLOR,
			};
			list.SetBinding(ListView.ItemsSourceProperty, DrugExplorePageModel.DrugsPropertyName);

			list.ItemTapped += OnItemTapped;

			Content = list;
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

