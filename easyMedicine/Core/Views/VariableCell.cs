using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class VariableCell : ViewCell
    {
        Label DescriptionLabel, UnitLabel;
        Entry ValueInput;
        Picker ValuePicker;

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(VariableCell), String.Empty);

        public static readonly BindableProperty UnitProperty =
            BindableProperty.Create("Unit", typeof(string), typeof(VariableCell), String.Empty);

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create("Value", typeof(decimal?), typeof(VariableCell), null, BindingMode.TwoWay);

        public static readonly BindableProperty InputChangedCommandProperty =
            BindableProperty.Create("InputChangedCommand", typeof(ICommand), typeof(VariableCell), default(ICommand), BindingMode.TwoWay);

        public static readonly BindableProperty ValuesProperty =
            BindableProperty.Create("Values", typeof(List<string>), typeof(VariableCell), default(List<string>));

        public static readonly BindableProperty HasFixedValuesProperty =
            BindableProperty.Create("HasFixedValues", typeof(bool), typeof(VariableCell), default(bool));

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create("Type", typeof(string), typeof(VariableCell), string.Empty);

        public static readonly BindableProperty ValueStrProperty =
            BindableProperty.Create("ValueStr", typeof(string), typeof(VariableCell), string.Empty, BindingMode.TwoWay);




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

        public decimal? Value
        {
            get { return (decimal?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public string ValueStr
        {
            get { return (string)GetValue(ValueStrProperty); }
            set { SetValue(ValueStrProperty, value); }
        }

        public List<string> Values
        {
            get { return (List<string>)GetValue(ValuesProperty); }
            set { SetValue(ValuesProperty, value); }
        }

        public bool HasFixedValues
        {
            get { return (bool)GetValue(HasFixedValuesProperty); }
            set { SetValue(HasFixedValuesProperty, value); }
        }

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
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
                UnitLabel.Text = Unit == "NA" ? String.Empty : Unit;


                if (HasFixedValues)
                {
                    ValueInput.IsVisible = false;
                    ValuePicker.IsVisible = true;
                    if (Values != null && ValuePicker.ItemsSource == null)
                    {
                        ValuePicker.ItemsSource = Values;
                        ValuePicker.SelectedIndex = 0;
                    }

                }
                else
                {
                    ValueInput.IsVisible = true;
                    ValuePicker.IsVisible = false;
                    ValueInput.Text = Value.ToString();
                }
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
                    new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Auto) },
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
                Style = (Style)Application.Current.Resources[Styles.Style_VariablesEntryStyle],
            };
            ValueInput.PropertyChanged += EntryPropertyChanged;
            grid.Children.Add(ValueInput, 1, 0);

            ValuePicker = new Picker()
            {
                //BackgroundColor = Color.FromHex("0078D7"),
                TextColor = Styles.BLUE_COLOR

            };

            ValuePicker.PropertyChanged += PickerPropertyChanged;
            grid.Children.Add(ValuePicker, 1, 0);

            UnitLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,

            };

            grid.Children.Add(UnitLabel, 2, 0);

            View = grid;
        }

        private void PickerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Picker.SelectedItemProperty.PropertyName)
            {
                var picker = (Picker)sender;
                ValueStr = (string)picker.SelectedItem;

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

        private void EntryPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Entry.TextProperty.PropertyName)
            {
                var entry = (Entry)sender;
                if (string.IsNullOrEmpty(entry.Text))
                {
                    Value = null;
                }
                else
                {
                    decimal val = 0;
                    CultureInfo cult;
                    if (entry.Text.Contains("."))
                    {
                        cult = new CultureInfo("en-US");
                    }
                    else
                    {
                        cult = new CultureInfo("pt-PT");
                    }

                    //var valText = entry.Text.Replace(',', '.');
                    var valid = decimal.TryParse(entry.Text, NumberStyles.Number, cult.NumberFormat, out val);
                    Value = val;

                    if (valid && !entry.Text.EndsWith(cult.NumberFormat.NumberDecimalSeparator, StringComparison.CurrentCulture))
                    {
                        entry.Text = Value.Value.ToString(cult.NumberFormat);
                    }
                }


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
