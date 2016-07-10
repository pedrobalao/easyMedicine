using System;
using easyMedicine.Pages;
using Xamarin.Forms;

namespace easyMedicine
{
	public class SubCategoryExplorePage : ContentPageBase
	{
		private SubCategoryExplorePageModel Model
		{
			get
			{
				return (SubCategoryExplorePageModel)base._model;
			}
		}


		public SubCategoryExplorePage(SubCategoryExplorePageModel model) : base (model)
		{
			this.BindingContext = Model;
			this.SetBinding(TitleProperty, SubCategoryExplorePageModel.ClinicalCategoryDescriptionPropertyName);

			var layout = new StackLayout()
			{

			};

			var cell = new DataTemplate(typeof(TextCell));
			cell.SetBinding(TextCell.TextProperty, "Description");

			var list = new ListView()
			{
				BindingContext = Model,
				ItemTemplate = cell

			};
			list.SetBinding(ListView.ItemsSourceProperty, SubCategoryExplorePageModel.SubClinicalCategoriesPropertyName);
			list.SetBinding(ListView.SelectedItemProperty, SubCategoryExplorePageModel.SelectedSubClinicalCategoryPropertyName, BindingMode.TwoWay);

			list.ItemTapped += OnItemTapped;


			layout.Children.Add(list);
			Content = layout;
		}


		private void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item != null && this.Model.SubCategorySelectedCommand != null && this.Model.SubCategorySelectedCommand.CanExecute(e))
			{
				Model.SubCategorySelectedCommand.Execute(e.Item);
			}
		}
	}
}

