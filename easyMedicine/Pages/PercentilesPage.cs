using System;
using System.Diagnostics;
using easyMedicine.Core.Converters;
using easyMedicine.Core.Views;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class PercentilesPage : ContentPageBase
    {
        private PercentilesPageModel Model
        {
            get
            {
                return (PercentilesPageModel)base._model;
            }
        }

        public PercentilesPage(PercentilesPageModel model) : base(model)
        {
            Title = "Percentis";

            this.BindingContext = model;
            //this.SetBinding(Page.TitleProperty, "Percentis");

            Icon = "baseline_supervised_user_circle_black_24pt.png";

            var scroll = new ScrollView();

            var layout = new StackLayout()
            {
                Padding = new Thickness(5),
            };

            var variableView = GetVariableView();
            layout.Children.Add(variableView);


            layout.Children.Add(GetErrorView());
            layout.Children.Add(GetHeightResultView());

            layout.Children.Add(GetWeightResultView());
            layout.Children.Add(GetBMIResultView());
            layout.Children.Add(GetBMIPercentileResultView());


            var lbFooter = new Label()
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,

            };
            lbFooter.SetBinding(Label.TextProperty, PercentilesPageModel.FooterInfoPropertyName);
            layout.Children.Add(lbFooter);

            scroll.Content = layout;

            Content = scroll;
        }

        private View GetErrorView()
        {
            var lbError = new Label()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumNegativeStyle]
            };
            lbError.SetBinding(Label.TextProperty, PercentilesPageModel.ErrorMessagePropertyName);
            lbError.SetBinding(Label.IsVisibleProperty, PercentilesPageModel.ErrorMessagePropertyName, BindingMode.Default, new StringToBoolConverter());
            return lbError;
        }

        private View GetVariableView()
        {
            Grid grid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5),
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Auto) },
                }
            };


            var genderLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Sexo"
            };

            grid.Children.Add(genderLabel, 0, 0);

            var genderPicker = new Picker()
            {
                //BackgroundColor = Color.FromHex("0078D7"),
                TextColor = Styles.BLUE_COLOR

            };
            genderPicker.SetBinding(Picker.ItemsSourceProperty, PercentilesPageModel.GendersPropertyName);
            genderPicker.SetBinding(Picker.SelectedItemProperty, PercentilesPageModel.SelectedGenderPropertyName);
            genderPicker.SelectedIndexChanged += async (object sender, EventArgs e) =>
            {
                await Model.Calculate();
            };

            grid.Children.Add(genderPicker, 1, 0);
            Grid.SetColumnSpan(genderPicker, 2);


            var birthdateLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Data de Nascimento"
            };

            grid.Children.Add(birthdateLabel, 0, 1);

            var birthdatePicker = new DatePicker()
            {
                //BackgroundColor = Color.FromHex("0078D7"),

                TextColor = Styles.BLUE_COLOR

            };
            birthdatePicker.SetBinding(DatePicker.DateProperty, PercentilesPageModel.BirthdatePropertyName);
            birthdatePicker.SetBinding(DatePicker.MinimumDateProperty, PercentilesPageModel.MinDatePropertyName);
            birthdatePicker.SetBinding(DatePicker.MaximumDateProperty, PercentilesPageModel.MaxDatePropertyName);

            birthdatePicker.DateSelected += async (object sender, DateChangedEventArgs e) =>
            {
                if (e.NewDate != e.OldDate)
                    await Model.Calculate();
            };
            grid.Children.Add(birthdatePicker, 1, 1);
            Grid.SetColumnSpan(birthdatePicker, 2);

            var heigthLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Altura"
            };

            grid.Children.Add(heigthLabel, 0, 2);

            var heightInput = new InputDelayChange()
            {
                Keyboard = Keyboard.Numeric,
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_VariablesEntryStyle],
            };
            heightInput.SetBinding(Entry.TextProperty, PercentilesPageModel.HeightPropertyName);
            grid.Children.Add(heightInput, 1, 2);
            heightInput.DelayedTextChanged += async (object sender, TextChangedEventArgs e) =>
            {
                Debug.WriteLine("Height Search: " + e.NewTextValue);
                await Model.Calculate();
            };

            var heightUnitLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,

            };
            heightUnitLabel.SetBinding(Label.TextProperty, PercentilesPageModel.HeightUnitPropertyName);
            grid.Children.Add(heightUnitLabel, 2, 2);



            var weightLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Text = "Peso"
            };

            grid.Children.Add(weightLabel, 0, 3);

            var weightInput = new InputDelayChange()
            {
                Keyboard = Keyboard.Numeric,
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_VariablesEntryStyle],
            };
            weightInput.SetBinding(Entry.TextProperty, PercentilesPageModel.WeightPropertyName);
            grid.Children.Add(weightInput, 1, 3);
            weightInput.DelayedTextChanged += async (object sender, TextChangedEventArgs e) =>
            {
                Debug.WriteLine("Weight Search: " + e.NewTextValue);
                await Model.Calculate();
            };

            var weightUnitLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,

            };
            weightUnitLabel.SetBinding(Label.TextProperty, PercentilesPageModel.WeightUnitPropertyName);
            grid.Children.Add(weightUnitLabel, 2, 3);

            return grid;
        }

        public View GetWeightResultView()
        {
            var stackCalculation = new StackLayout() { };
            stackCalculation.SetBinding(StackLayout.IsVisibleProperty, PercentilesPageModel.HasWeightPercentilePropertyName);

            var lbtRes = new Label()
            {
                Text = "Percentil Peso",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            stackCalculation.Children.Add(lbtRes);

            var resStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var resultLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelResultValueStyle],
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            resultLabel.BindingContext = Model;
            resultLabel.SetBinding(Label.TextProperty, PercentilesPageModel.WeightPercentilePropertyName);

            resStack.Children.Add(resultLabel);

            stackCalculation.Children.Add(resStack);

            return stackCalculation;
        }

        public View GetBMIResultView()
        {
            var stackCalculation = new StackLayout() { };
            stackCalculation.SetBinding(StackLayout.IsVisibleProperty, PercentilesPageModel.HasBMIPropertyName);

            var lbtRes = new Label()
            {
                Text = "IMC",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            stackCalculation.Children.Add(lbtRes);

            var resStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var resultLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelResultValueStyle],
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            resultLabel.BindingContext = Model;
            resultLabel.SetBinding(Label.TextProperty, PercentilesPageModel.BMIPropertyName);

            resStack.Children.Add(resultLabel);

            stackCalculation.Children.Add(resStack);

            return stackCalculation;
        }

        public View GetBMIPercentileResultView()
        {
            var stackCalculation = new StackLayout() { };
            stackCalculation.SetBinding(StackLayout.IsVisibleProperty, PercentilesPageModel.HasBMIPercentilePropertyName);

            var lbtRes = new Label()
            {
                Text = "Percentil IMC",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            stackCalculation.Children.Add(lbtRes);

            var resStack = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var resultLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelResultValueStyle],
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            resultLabel.BindingContext = Model;
            resultLabel.SetBinding(Label.TextProperty, PercentilesPageModel.BMIPercentilePropertyName);
            resultLabel.SetBinding(Label.TextColorProperty, PercentilesPageModel.BMIPercentilColorPropertyName);


            resStack.Children.Add(resultLabel);


            var conclusionLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelResultValueStyle],
                VerticalOptions = LayoutOptions.EndAndExpand,
            };
            conclusionLabel.BindingContext = Model;
            conclusionLabel.SetBinding(Label.TextProperty, PercentilesPageModel.BMIConclusionPropertyName);
            conclusionLabel.SetBinding(Label.TextColorProperty, PercentilesPageModel.BMIPercentilColorPropertyName);

            resStack.Children.Add(conclusionLabel);
            stackCalculation.Children.Add(resStack);

            return stackCalculation;
        }

        public View GetHeightResultView()
        {
            var stackCalculation = new StackLayout() { };
            stackCalculation.SetBinding(StackLayout.IsVisibleProperty, PercentilesPageModel.HasHeightPercentilePropertyName);

            var lbtRes = new Label()
            {
                Text = "Percentil Altura",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            stackCalculation.Children.Add(lbtRes);

            var resStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var resultLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelResultValueStyle],
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            resultLabel.BindingContext = Model;
            resultLabel.SetBinding(Label.TextProperty, PercentilesPageModel.HeightPercentilePropertyName);

            resStack.Children.Add(resultLabel);

            stackCalculation.Children.Add(resStack);

            return stackCalculation;
        }
    }
}
