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
			this.SetBinding(Page.TitleProperty, "Drug.Name");


			var favButton = new ToolbarItem
			{
				BindingContext =Model,
			};
			favButton.SetBinding(ToolbarItem.IconProperty, DrugPageModel.FavouriteIconPropertyName);
			favButton.SetBinding(ToolbarItem.CommandProperty, DrugPageModel.ChangeFavouriteStatusPropertyName);

			this.ToolbarItems.Add(favButton);

			this.Padding = new Thickness(5);

			var grid = new Grid();

			grid.ColumnDefinitions.Add(new ColumnDefinition(){
				Width = new GridLength(1, GridUnitType.Auto)
			});

			var titleRowDefinition = new RowDefinition() { Height = new GridLength(10, GridUnitType.Absolute) };
			var descriptionRowDefinition = new RowDefinition() { Height = new GridLength(30, GridUnitType.Absolute) };


			grid.RowDefinitions.Add(titleRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);

			grid.RowDefinitions.Add(titleRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);

			grid.RowDefinitions.Add(titleRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);

			grid.RowDefinitions.Add(titleRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);

			grid.RowDefinitions.Add(titleRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);

			grid.RowDefinitions.Add(titleRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);

			grid.RowDefinitions.Add(titleRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);

			//nome
			var lbtName = new Label()
			{
				Text = "Nome",
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};

			var lbdDrugName = new Label() 
			{
				Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
			};
			lbdDrugName.SetBinding(Label.TextProperty, "Drug.Name");

			grid.Children.Add(lbtName, 0, 0);
			grid.Children.Add(lbdDrugName, 0, 1);

			//marca comercial
			var lbtCommercialBrand = new Label()
			{
				Text = "Marca Comercial",
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};

			var lbdCommercialBrand = new Label()
			{
				Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
			};
			lbdCommercialBrand.SetBinding(Label.TextProperty, "Drug.CommercialBrand");

			grid.Children.Add(lbtCommercialBrand, 0, 2);
			grid.Children.Add(lbdCommercialBrand, 0, 3);

			//indicação
			var lbtIndication = new Label()
			{
				Text = "Indicação",
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};

			var lbdIndication = new Label()
			{
				Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
			};
			lbdIndication.SetBinding(Label.TextProperty, "Drug.Indication");

			grid.Children.Add(lbtIndication, 0, 4);
			grid.Children.Add(lbdIndication, 0, 5);

			//indicação
			var lbtConterIndication = new Label()
			{
				Text = "Contra-Indicações",
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};

			var lbdConterIndication = new Label()
			{
				Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
			};
			lbdConterIndication.SetBinding(Label.TextProperty, "Drug.ConterIndications");

			grid.Children.Add(lbtConterIndication, 0, 6);
			grid.Children.Add(lbdConterIndication, 0, 7);

			//Efeitos Secundários
			var lbtSecondaryEffects = new Label()
			{
				Text = "Efeitos Secundários",
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};

			var lbdSecondaryEffects = new Label()
			{
				Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
			};
			lbdSecondaryEffects.SetBinding(Label.TextProperty, "Drug.SecondaryEffects");

			grid.Children.Add(lbtSecondaryEffects, 0, 8);
			grid.Children.Add(lbdSecondaryEffects, 0, 9);

			//Via
			var lbtVia = new Label()
			{
				Text = "Via",
				Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
			};

			var lbdVia = new Label()
			{
				Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
			};
			lbdVia.SetBinding(Label.TextProperty, "Drug.Via");

			grid.Children.Add(lbtVia, 0, 10);
			grid.Children.Add(lbdVia, 0, 11);




			Content = grid;

		}
	}
}

