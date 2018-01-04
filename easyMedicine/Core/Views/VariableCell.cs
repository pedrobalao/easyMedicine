using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class VariableCell : ViewCell
    {
        Label DescriptionLabel, UnitLabel;
        Entry ValueInput;

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(VariableCell), String.Empty);

        public static readonly BindableProperty UnitProperty =
            BindableProperty.Create("Unit", typeof(string), typeof(VariableCell), String.Empty);

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create("Value", typeof(decimal), typeof(VariableCell), default(decimal), BindingMode.TwoWay);


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

        public decimal Value
        {
            get { return (decimal)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                DescriptionLabel.Text = Description;
                UnitLabel.Text = Unit;
                ValueInput.Text = Value.ToString();
            }
        }


        public VariableCell()
        {
            DescriptionLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
            };

            UnitLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
            };

            ValueInput = new Entry()
            {
                Keyboard = Keyboard.Numeric
            };
            ValueInput.PropertyChanged += EntryPropertyChanged;

            var layout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(5),
            };

            layout.Children.Add(DescriptionLabel);
            layout.Children.Add(ValueInput);
            layout.Children.Add(UnitLabel);

            View = layout;
        }

        private void EntryPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Entry.TextProperty.PropertyName)
            {
                var entry = (Entry)sender;
                if (string.IsNullOrEmpty(entry.Text))
                {
                    Value = 0;
                }
                decimal val = 0;
                decimal.TryParse(entry.Text, out val);
                Value = val;
            }
        }
    }
}
