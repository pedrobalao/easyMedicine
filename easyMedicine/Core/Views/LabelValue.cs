using System;
using easyMedicine.Core.Converters;
using Xamarin.Forms;

namespace easyMedicine
{
    public class LabelValue : ContentView
    {

        public Label Title
        {
            get;
            set;
        }
        public Label Description
        {
            get;
            set;
        }
        public LabelValue(string label, string valueBinding)
        {
            var grid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            var titleHeight = 15;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    titleHeight = 15;
                    break;
                case Device.Android:
                    titleHeight = 15;
                    break;
            }

            var titleRowDefinition = new RowDefinition() { Height = new GridLength(titleHeight, GridUnitType.Absolute) };
            var descriptionRowDefinition = new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) };


            grid.RowDefinitions.Add(titleRowDefinition);
            grid.RowDefinitions.Add(descriptionRowDefinition);

            Title = new Label()
            {
                Text = label,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };

            Description = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                LineBreakMode = LineBreakMode.WordWrap
            };
            Description.SetBinding(Label.TextProperty, valueBinding);

            Description.SetBinding(Label.IsVisibleProperty, valueBinding, BindingMode.OneWay, new StringToBoolConverter());
            Title.SetBinding(Label.IsVisibleProperty, valueBinding, BindingMode.OneWay, new StringToBoolConverter());


            grid.Children.Add(Title, 0, 0);
            grid.Children.Add(Description, 0, 1);

            Content = grid;
        }
    }
}

