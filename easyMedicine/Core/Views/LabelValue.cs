using System;
using Xamarin.Forms;

namespace easyMedicine
{
	public class LabelValue : ContentView
	{

		public Label Title
		{
			get;
			set;
		}
		public Label Description
		{
			get;
			set;
		}
		public LabelValue(string label, string valueBinding)
		{
			var grid = new Grid()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			grid.ColumnDefinitions.Add(new ColumnDefinition()
			{
				Width = new GridLength(1, GridUnitType.Star)
			});

			var titleRowDefinition = new RowDefinition() { Height = new GridLength(10, GridUnitType.Absolute) };
			var descriptionRowDefinition = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };


			grid.RowDefinitions.Add(titleRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);

			var lbtName = new Label()
			{
				Text = label,
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};

			var lbdDrugName = new Label()
			{
				Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
			};
			lbdDrugName.SetBinding(Label.TextProperty, valueBinding);

			grid.Children.Add(lbtName, 0, 0);
			grid.Children.Add(lbdDrugName, 0, 1);

			Content = grid;
		}
	}
}

