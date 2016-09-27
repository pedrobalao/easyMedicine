﻿using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
	public class SearchPage : ContentPageBase
	{
		private SearchPageModel Model {
			get {
				return (SearchPageModel)base._model;
			}
		}

		public SearchPage (SearchPageModel model) : base (model)
		{
			Title = "Pesquisa";
			Icon = "ic_search_white_48px.png";
			var layout = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			SearchBar sbar = new SearchBar () {
				BindingContext = Model,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Pesquisa",
			};
			sbar.SetBinding (SearchBar.TextProperty, SearchPageModel.SearchStringPropertyName, BindingMode.TwoWay);

			//sbar.SetBinding(SearchBar.SearchCommandProperty, SearchPageModel.SearchStringPropertyName, BindingMode.TwoWay);

			sbar.TextChanged += async (sender, e) => await Model.FilterDrugs();
			sbar.SearchButtonPressed += async (sender, e) =>
			{
				await Model.FilterDrugs();
			};

			var cell = new DataTemplate(typeof(CustomCell));
			cell.SetBinding(CustomCell.NameProperty, "Name");
			cell.SetBinding(CustomCell.DetailProperty, "Detail");

			var list = new ListView()
			{
				BindingContext = Model,
				ItemTemplate = cell,
				HasUnevenRows = true,
				SeparatorColor = Styles.BLUE_COLOR,
			};
			list.SetBinding(ListView.ItemsSourceProperty, SearchPageModel.SearchResultPropertyName);

			list.ItemTapped += (object sender, ItemTappedEventArgs e) => 
			{
				if (e.Item != null && this.Model.DrugSelectedCommand != null && this.Model.DrugSelectedCommand.CanExecute(e))
				{
					Model.DrugSelectedCommand.Execute(e.Item);
				}
			};

			layout.Children.Add (sbar);
			layout.Children.Add(list);
			Content = layout;
		}


}
}

