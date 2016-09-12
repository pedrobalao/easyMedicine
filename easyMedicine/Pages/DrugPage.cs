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


			var layout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};


			var lbtname = new LabelValue("Nome", "Drug.Name");
			layout.Children.Add(lbtname);
			var lbtbrand = new LabelValue("Marca Comercial", "Drug.CommercialBrand");
			layout.Children.Add(lbtbrand);
			var lbtConterIndications = new LabelValue("Contra-Indicações", "Drug.ConterIndications");
			layout.Children.Add(lbtConterIndications);
			var lbtSecEffects = new LabelValue("Efeitos Secundários", "Drug.SecondaryEffects");
			layout.Children.Add(lbtSecEffects);


			var lstView = new ListView()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			lstView.HasUnevenRows = true;
			lstView.IsGroupingEnabled = true;
			//lstView.GroupDisplayBinding = new Binding("Description");
			//lstView.GroupShortNameBinding = new Binding("ShortName");
			lstView.SetBinding(ListView.ItemsSourceProperty, DrugPageModel.IndicationsPropertyName);
			lstView.SeparatorColor = Styles.BLUE_COLOR;
			lstView.ItemTemplate = new DataTemplate(typeof(DoseCell));
			lstView.ItemTemplate.SetBinding(DoseCell.ViaProperty, "IdVia");
			lstView.ItemTemplate.SetBinding(DoseCell.PedDoseProperty, "PediatricDose");
			lstView.ItemTemplate.SetBinding(DoseCell.PedDoseUnityProperty, "IdUnityPediatricDose");
			lstView.ItemTemplate.SetBinding(DoseCell.AdultDoseProperty, "AdultDose");
			lstView.ItemTemplate.SetBinding(DoseCell.AdultDoseUnityProperty, "IdUnityAdultDose");

			lstView.ItemTemplate.SetBinding(DoseCell.TakesPerDayProperty, "TakesPerDay");
			lstView.ItemTemplate.SetBinding(DoseCell.MaxDosePerDayProperty, "MaxDosePerDay");
			lstView.ItemTemplate.SetBinding(DoseCell.MaxDosePerDayUnityProperty, "IdUnityMaxDosePerDay");
			lstView.ItemTemplate.SetBinding(DoseCell.ObsProperty, "Obs");

			lstView.GroupHeaderTemplate = new DataTemplate(() =>
			{
				var hdrLayout = new Label()
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					LineBreakMode = LineBreakMode.WordWrap,
					Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumBackgroundStyle],
					                           
				};
				hdrLayout.SetBinding(Label.TextProperty, "Description");

				return new ViewCell() { View = hdrLayout };
			});

			layout.Children.Add(lstView);

			/*
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

			*/

			/*/
			var carousel = new CarouselView()
			{
				BackgroundColor = Color.Aqua,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate(() => {
					var gridtemp = new Grid() { 
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand,
					};
					gridtemp.ColumnDefinitions.Add(new ColumnDefinition()
					{
						Width = new GridLength(1, GridUnitType.Auto)
					});

					gridtemp.RowDefinitions.Add(titleRowDefinition);
					gridtemp.RowDefinitions.Add(descriptionRowDefinition);
					gridtemp.RowDefinitions.Add(descriptionRowDefinition);

					var lbtInd = new Label()
					{
						Text = "Indicação",
						Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
					};

					var lbdInd = new Label()
					{
						Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
					};
					lbdInd.SetBinding(Label.TextProperty, "Indication.IndicationText");

					gridtemp.Children.Add(lbtInd, 0, 0);
					gridtemp.Children.Add(lbdInd, 0, 1);

					var doses = new ListView { 
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand,
						ItemTemplate = new DataTemplate(() =>{
							var lay = new StackLayout()
							{
								HorizontalOptions = LayoutOptions.FillAndExpand,
								VerticalOptions = LayoutOptions.FillAndExpand,
							};

							var lbtpedDose = new LabelValue("Dose Pediátrica", "PediatricDose");

						
							lay.Children.Add(lbtpedDose);

							return new ViewCell { View = lay };
						})
					};
					doses.SetBinding(ListView.ItemsSourceProperty, "Doses");

					gridtemp.Children.Add(doses, 0, 2);

					return gridtemp; //new ViewCell { View = gridtemp };
				})
			};
			carousel.SetBinding(CarouselView.ItemsSourceProperty, "Drug.Indications"); 
			grid.Children.Add(carousel, 0, 11);

			*/


			Content = layout;

		}
	}
}

