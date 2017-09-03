using System;
using easyMedicine.Pages;
using Xamarin.Forms;

namespace easyMedicine
{
    public class DrugPage : ContentPageBase
    {
        private DrugPageModel Model
        {
            get
            {
                return (DrugPageModel)base._model;
            }
        }

        //public DrugPage(DrugPageModel model) : base(model)
        //{
        //    this.BindingContext = Model;
        //    this.SetBinding(Page.TitleProperty, "Drug.Name");


        //    var favButton = new ToolbarItem
        //    {
        //        BindingContext = Model,
        //    };
        //    favButton.SetBinding(ToolbarItem.IconProperty, DrugPageModel.FavouriteIconPropertyName);
        //    favButton.SetBinding(ToolbarItem.CommandProperty, DrugPageModel.ChangeFavouriteStatusPropertyName);

        //    this.ToolbarItems.Add(favButton);

        //    //this.Padding = new Thickness(5);


        //    var layout = new StackLayout()
        //    {
        //        HorizontalOptions = LayoutOptions.FillAndExpand,
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //    };

        //    var layoutHeader = new StackLayout()
        //    {
        //        HorizontalOptions = LayoutOptions.FillAndExpand,
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //        Padding = new Thickness(5),
        //    };

        //    var lbtname = new LabelValue("Nome", "Drug.Name");
        //    layoutHeader.Children.Add(lbtname);
        //    //var lbtbrand = new LabelValue("Marca Comercial", "Drug.CommercialBrand");
        //    //layoutHeader.Children.Add(lbtbrand);
        //    var lbtConterIndications = new LabelValue("Contra-Indicações", "Drug.ConterIndications");
        //    layoutHeader.Children.Add(lbtConterIndications);
        //    var lbtSecEffects = new LabelValue("Efeitos Secundários", "Drug.SecondaryEfects");
        //    layoutHeader.Children.Add(lbtSecEffects);
        //    var lbtPresentation = new LabelValue("Apresentação", "Drug.Presentation");
        //    layoutHeader.Children.Add(lbtPresentation);
        //    var lbtCommercialBrands = new LabelValue("Marcas Comerciais", "Drug.ComercialBrands");
        //    layoutHeader.Children.Add(lbtCommercialBrands);
        //    var lbtObs = new LabelValue("Outros Dados", "Drug.Obs");
        //    layoutHeader.Children.Add(lbtObs);


        //    layout.Children.Add(layoutHeader);

        //    var lstView = new ListView()
        //    {
        //        HorizontalOptions = LayoutOptions.FillAndExpand,
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //    };
        //    lstView.HasUnevenRows = true;
        //    lstView.IsGroupingEnabled = true;
        //    //lstView.GroupDisplayBinding = new Binding("Description");
        //    //lstView.GroupShortNameBinding = new Binding("ShortName");
        //    lstView.SetBinding(ListView.ItemsSourceProperty, DrugPageModel.IndicationsPropertyName);
        //    lstView.SeparatorColor = Styles.BLUE_COLOR;
        //    lstView.ItemTemplate = new DataTemplate(typeof(DoseCell));
        //    lstView.ItemTemplate.SetBinding(DoseCell.ViaProperty, "IdVia");
        //    lstView.ItemTemplate.SetBinding(DoseCell.PedDoseProperty, "PediatricDose");
        //    lstView.ItemTemplate.SetBinding(DoseCell.PedDoseUnityProperty, "IdUnityPediatricDose");
        //    lstView.ItemTemplate.SetBinding(DoseCell.AdultDoseProperty, "AdultDose");
        //    lstView.ItemTemplate.SetBinding(DoseCell.AdultDoseUnityProperty, "IdUnityAdultDose");

        //    lstView.ItemTemplate.SetBinding(DoseCell.TakesPerDayProperty, "TakesPerDay");
        //    lstView.ItemTemplate.SetBinding(DoseCell.MaxDosePerDayProperty, "MaxDosePerDay");
        //    lstView.ItemTemplate.SetBinding(DoseCell.MaxDosePerDayUnityProperty, "IdUnityMaxDosePerDay");
        //    lstView.ItemTemplate.SetBinding(DoseCell.ObsProperty, "Obs");
        //    lstView.ItemTemplate.SetBinding(DoseCell.DescriptionProperty, "Description");

        //    lstView.GroupHeaderTemplate = new DataTemplate(() =>
        //    {
        //        var ghlayout = new StackLayout()
        //        {
        //            Padding = new Thickness(5),
        //            HorizontalOptions = LayoutOptions.FillAndExpand,
        //            VerticalOptions = LayoutOptions.Fill,
        //            BackgroundColor = Styles.BLUE_COLOR,
        //            Orientation = StackOrientation.Horizontal

        //        };

        //        var hdrLayout = new Label()
        //        {
        //            LineBreakMode = LineBreakMode.TailTruncation,
        //            Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumBackgroundStyle],
        //        };
        //        hdrLayout.SetBinding(Label.TextProperty, "Description");

        //        ghlayout.Children.Add(hdrLayout);

        //        var img = new Image()
        //        {
        //            HorizontalOptions = LayoutOptions.EndAndExpand,
        //            Source = "ic_info_outline_white_48pt.png"
        //        };

        //        var tapImage = new TapGestureRecognizer();
        //        //Binding events  
        //        tapImage.Tapped += tapImage_Tapped;
        //        //Associating tap events to the image buttons  
        //        img.GestureRecognizers.Add(tapImage);
        //        void tapImage_Tapped(object sender, EventArgs e)
        //        {
        //            // handle the tap 

        //            DisplayAlert("Indicação", hdrLayout.Text, "OK");
        //        }

        //        ghlayout.Children.Add(img);


        //        return new ViewCell() { View = ghlayout, };
        //    });

        //    layout.Children.Add(lstView);

        //    var scroll = new ScrollView()
        //    {
        //    };
        //    scroll.Content = layout;

        //    Content = scroll;

        //}

        public DrugPage(DrugPageModel model) : base(model)
        {
            this.BindingContext = Model;
            this.SetBinding(Page.TitleProperty, "Drug.Name");


            var favButton = new ToolbarItem
            {
                BindingContext = Model,
            };
            favButton.SetBinding(ToolbarItem.IconProperty, DrugPageModel.FavouriteIconPropertyName);
            favButton.SetBinding(ToolbarItem.CommandProperty, DrugPageModel.ChangeFavouriteStatusPropertyName);

            this.ToolbarItems.Add(favButton);

            //this.Padding = new Thickness(5);


            //var layout = new StackLayout()
            //{
            //	HorizontalOptions = LayoutOptions.FillAndExpand,
            //	VerticalOptions = LayoutOptions.FillAndExpand,
            //};

            var layoutHeader = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5),
            };

            var lbtname = new LabelValue("Nome", "Drug.Name");
            layoutHeader.Children.Add(lbtname);
            //var lbtbrand = new LabelValue("Marca Comercial", "Drug.CommercialBrand");
            //layoutHeader.Children.Add(lbtbrand);
            var lbtConterIndications = new LabelValue("Contra-Indicações", "Drug.ConterIndications");
            layoutHeader.Children.Add(lbtConterIndications);
            var lbtSecEffects = new LabelValue("Efeitos Secundários", "Drug.SecondaryEfects");
            layoutHeader.Children.Add(lbtSecEffects);
            var lbtPresentation = new LabelValue("Apresentação", "Drug.Presentation");
            layoutHeader.Children.Add(lbtPresentation);
            var lbtCommercialBrands = new LabelValue("Marcas Comerciais", "Drug.ComercialBrands");
            layoutHeader.Children.Add(lbtCommercialBrands);
            var lbtObs = new LabelValue("Outros Dados", "Drug.Obs");
            layoutHeader.Children.Add(lbtObs);


            //layout.Children.Add(layoutHeader);

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
            lstView.ItemTemplate.SetBinding(DoseCell.DescriptionProperty, "Description");

            lstView.GroupHeaderTemplate = new DataTemplate(() =>
            {
                var ghlayout = new StackLayout()
                {
                    Padding = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Fill,
                    BackgroundColor = Styles.BLUE_COLOR,
                    Orientation = StackOrientation.Horizontal

                };

                var hdrLayout = new Label()
                {
                    LineBreakMode = LineBreakMode.TailTruncation,
                    Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumBackgroundStyle],
                };
                hdrLayout.SetBinding(Label.TextProperty, "Description");

                ghlayout.Children.Add(hdrLayout);

                var img = new Image()
                {
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    Source = "ic_info_outline_white_48pt.png"
                };

                var tapImage = new TapGestureRecognizer();
                //Binding events  
                tapImage.Tapped += tapImage_Tapped;
                //Associating tap events to the image buttons  
                img.GestureRecognizers.Add(tapImage);
                void tapImage_Tapped(object sender, EventArgs e)
                {
                    // handle the tap 

                    DisplayAlert("Indicação", hdrLayout.Text, "OK");
                }

                ghlayout.Children.Add(img);


                return new ViewCell() { View = ghlayout, };
            });

            lstView.Header = layoutHeader;

            //layout.Children.Add(lstView);

            Content = lstView;

        }
    }
}

