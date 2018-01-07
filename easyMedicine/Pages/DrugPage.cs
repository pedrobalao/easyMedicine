using System;
using easyMedicine.Core.Views;
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





            var layoutHeader = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5),
            };

            var lbtname = new LabelValue("Nome", "Drug.Name");
            layoutHeader.Children.Add(lbtname);


            var labelDoseCalc = new Label()
            {
                Text = "Cálculo de Doses",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            layoutHeader.Children.Add(labelDoseCalc);


            var calculationView = GetCalculationView();
            layoutHeader.Children.Add(calculationView);


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

            var lstView = new UnselectListView()
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




            //var calculationView = GetCalculationView();

            //var footerLayout = new StackLayout
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.Start,
            //};

            //footerLayout.Children.Add(calculationView);


            var btnReportProblem = new Button()
            {
                BindingContext = Model,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Reportar Erro",
                Style = (Style)Application.Current.Resources[Styles.Style_ButtonMediumNegStyle],
            };

            btnReportProblem.SetBinding(Button.CommandProperty, DrugPageModel.ReportErrorCommandPropertyName);

            //footerLayout.Children.Add(btnReportProblem);

            lstView.Footer = btnReportProblem; //footerLayout;

            Content = lstView;

        }


        private View GetCalculationView()
        {
            var stackCalculation = new StackLayout()
            {
                BindingContext = Model,
                BackgroundColor = Styles.BLUE_COLOR
            };
            stackCalculation.SetBinding(StackLayout.IsVisibleProperty, DrugPageModel.CanCalculateDosePropertyName);

            var lstView = new Repeater()
            {
            };
            lstView.SetBinding(Repeater.ItemsSourceProperty, DrugPageModel.VariablesPropertyName);
            //lstView.SeparatorVisibility = SeparatorVisibility.None;
            lstView.ItemTemplate = new DataTemplate(typeof(VariableCell));
            lstView.ItemTemplate.SetBinding(VariableCell.DescriptionProperty, "Description");
            lstView.ItemTemplate.SetBinding(VariableCell.UnitProperty, "IdUnit");
            lstView.ItemTemplate.SetBinding(VariableCell.ValueProperty, "Value");
            lstView.ItemTemplate.SetBinding(VariableCell.InputChangedCommandProperty, "ValueChangedCommand");
            //lstView.SetBinding(ListView.IsVisibleProperty, DrugPageModel.CanCalculateDosePropertyName);

            //var resultStack = new StackLayout
            //{
            //    Orientation = StackOrientation.Horizontal,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    VerticalOptions = LayoutOptions.Start,
            //};
            stackCalculation.Children.Add(lstView);

            var lstResults = new Repeater()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            lstResults.SetBinding(Repeater.ItemsSourceProperty, DrugPageModel.CalculationsPropertyName);

            lstResults.ItemTemplate = new DataTemplate(typeof(DoseResultCell));
            lstResults.ItemTemplate.SetBinding(DoseResultCell.DescriptionProperty, "Description");
            lstResults.ItemTemplate.SetBinding(DoseResultCell.UnitProperty, "ResultIdUnit");
            lstResults.ItemTemplate.SetBinding(DoseResultCell.ValueProperty, "Result");


            stackCalculation.Children.Add(lstResults);


            //lstView.Footer = lstResults;

            return stackCalculation;
        }
    }
}

