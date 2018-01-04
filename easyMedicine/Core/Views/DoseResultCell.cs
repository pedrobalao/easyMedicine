using System;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class DoseResultCell : ViewCell
    {
        Label DescriptionLabel, ValueLabel, UnitLabel;

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(VariableCell), String.Empty);

        public static readonly BindableProperty UnitProperty =
            BindableProperty.Create("Unit", typeof(string), typeof(VariableCell), String.Empty);

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create("ValueLabel", typeof(string), typeof(VariableCell), String.Empty);


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
        }


        public DoseResultCell()
        {
            DescriptionLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
            };

            ValueLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
            };

            UnitLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
            };

            var layout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(5),
            };

            layout.Children.Add(DescriptionLabel);
            layout.Children.Add(ValueLabel);
            layout.Children.Add(UnitLabel);

            View = layout;
        }
    }
}

