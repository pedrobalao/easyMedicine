using System;
using easyMedicine.Core.Converters;
using Xamarin.Forms;

namespace easyMedicine
{
    public class LabelValueNB : ContentView
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
        public LabelValueNB()
        {

            var stack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            Title = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            stack.Children.Add(Title);

            Description = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                LineBreakMode = LineBreakMode.WordWrap
            };
            stack.Children.Add(Description);

            Content = stack;

            //var grid = new Grid()
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //};

            //grid.ColumnDefinitions.Add(new ColumnDefinition()
            //{
            //    Width = new GridLength(1, GridUnitType.Star)
            //});

            //var titleHeight = 15;

            //switch (Device.RuntimePlatform)
            //{
            //    case Device.iOS:
            //        titleHeight = 15;
            //        break;
            //    case Device.Android:
            //        titleHeight = 15;
            //        break;
            //}

            //var titleRowDefinition = new RowDefinition() { Height = new GridLength(titleHeight, GridUnitType.Absolute) };
            //var descriptionRowDefinition = new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) };


            //grid.RowDefinitions.Add(titleRowDefinition);
            //grid.RowDefinitions.Add(descriptionRowDefinition);

            //Title = new Label()
            //{
            //    Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            //};

            //Description = new Label()
            //{
            //    Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
            //    LineBreakMode = LineBreakMode.WordWrap
            //};

            //grid.Children.Add(Title, 0, 0);
            //grid.Children.Add(Description, 0, 1);

            //Content = grid;
        }
    }
}

