using System;
using easyMedicine.Pages;
using Xamarin.Forms;

namespace easyMedicine
{
	public class DrugPage  : ContentPageBase
	{
		private DrugPageModel Model
		{
			get
			{
				return (DrugPageModel)base._model;
			}
		}
	
		public DrugPage(DrugPageModel model) : base (model)
		{
			this.BindingContext = Model;
			this.SetBinding(Page.TitleProperty, DrugPageModel.DrugPropertyName);
			this.Padding = new Thickness(5);

			var grid = new Grid();

			grid.ColumnDefinitions.Add(new ColumnDefinition()
			{
				Width = new GridLength(1, GridUnitType.Auto)
			});

			grid.RowDefinitions.Add(new RowDefinition()
			{
				Height = new GridLength(1, GridUnitType.Auto)
			});


			var labelName = new Label()
			{
				Text = "Nome",
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};

			var labelDrugName = new Label() 
			{
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};
			labelDrugName.SetBinding(Label.TextProperty, "Drug.Name");

			grid.Children.Add(labelName, 0, 0);
			grid.Children.Add(labelDrugName, 0, 1);

			Content = grid;

		}
	}
}

