using System;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class DoseResultCell : ViewCell
    {
        Label DescriptionLabel, ExtraInfoLabel, ValueLabel, UnitLabel;

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(VariableCell), String.Empty);


        public static readonly BindableProperty ExtraInfoProperty =
            BindableProperty.Create("ExtraInfo", typeof(string), typeof(VariableCell), String.Empty);

        public static readonly BindableProperty UnitProperty =
            BindableProperty.Create("Unit", typeof(string), typeof(VariableCell), String.Empty);

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create("ValueLabel", typeof(string), typeof(VariableCell), String.Empty);


        public string ExtraInfo
        {
            get { return (string)GetValue(ExtraInfoProperty); }
            set { SetValue(ExtraInfoProperty, value); }
        }


        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                DescriptionLabel.Text = Description;
                UnitLabel.Text = Unit;
                ValueLabel.Text = Value;
            }
            ExtraInfoLabel.Text = ExtraInfo;
        }


        public DoseResultCell()
        {
            var infoLayout = new StackLayout() { };

            DescriptionLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
            };

            ExtraInfoLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle]
            };

            infoLayout.Children.Add(DescriptionLabel);
            infoLayout.Children.Add(ExtraInfoLabel);

            ValueLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincTitleStyle],
                HorizontalTextAlignment = TextAlignment.End,
            };

            UnitLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincTitleStyle],
                HorizontalTextAlignment = TextAlignment.Start
            };

            Grid grid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5),
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
                }
            };


            grid.Children.Add(infoLayout, 0, 0);
            grid.Children.Add(ValueLabel, 1, 0);
            grid.Children.Add(UnitLabel, 2, 0);

            View = grid;
        }
    }
}

