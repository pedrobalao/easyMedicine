using System;
using System.ComponentModel;
using System.Windows.Input;
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

        public static readonly BindableProperty InputChangedCommandProperty =
            BindableProperty.Create("InputChangedCommand", typeof(ICommand), typeof(VariableCell), default(ICommand), BindingMode.TwoWay);



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

        public ICommand InputChangedCommand
        {
            get
            {
                return (ICommand)GetValue(InputChangedCommandProperty);
            }
            set
            {
                SetValue(InputChangedCommandProperty, value);
            }
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
            DescriptionLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            grid.Children.Add(DescriptionLabel, 0, 0);

            ValueInput = new Entry()
            {
                Keyboard = Keyboard.Numeric,
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.WhiteSmoke

            };
            ValueInput.PropertyChanged += EntryPropertyChanged;

            grid.Children.Add(ValueInput, 1, 0);

            UnitLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,

            };

            grid.Children.Add(UnitLabel, 2, 0);

            View = grid;
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

                if (InputChangedCommand == null)
                {
                    return;
                }
                if (InputChangedCommand.CanExecute(this))
                {
                    InputChangedCommand.Execute(this);
                }
            }
        }


    }
}
