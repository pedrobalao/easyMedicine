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

			//this.Padding = new Thickness(5);


			var layout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			var layoutHeader = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(5),
			};

			var lbtname = new LabelValue("Nome", "Drug.Name");
			layoutHeader.Children.Add(lbtname);
			var lbtbrand = new LabelValue("Marca Comercial", "Drug.CommercialBrand");
			layoutHeader.Children.Add(lbtbrand);
			var lbtConterIndications = new LabelValue("Contra-Indicações", "Drug.ConterIndications");
			layoutHeader.Children.Add(lbtConterIndications);
			var lbtSecEffects = new LabelValue("Efeitos Secundários", "Drug.SecondaryEffects");
			layoutHeader.Children.Add(lbtSecEffects);

			layout.Children.Add(layoutHeader);

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
				var ghlayout = new StackLayout()
				{
					Padding = new Thickness(5),
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Styles.BLUE_COLOR,
				};
				var hdrLayout = new Label()
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					LineBreakMode = LineBreakMode.WordWrap,
					Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumBackgroundStyle],
					                           
				};
				hdrLayout.SetBinding(Label.TextProperty, "Description");

				ghlayout.Children.Add(hdrLayout);
				return new ViewCell() { View = ghlayout, };
			});

			layout.Children.Add(lstView);


			Content = layout;

		}
	}
}

