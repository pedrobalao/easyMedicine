using System;
using Xamarin.Forms;

namespace easyMedicine
{
    public class CustomCell : ViewCell
    {


        Label nameLabel, detailLabel;

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name", typeof(string), typeof(CustomCell), "Name");
        public static readonly BindableProperty DetailProperty =
            BindableProperty.Create("Detail", typeof(string), typeof(CustomCell), String.Empty);

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }



        public string Detail
        {
            get { return (string)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                nameLabel.Text = Name;
                detailLabel.Text = Detail;
            }
        }
        public CustomCell()
        {

            var layout = new StackLayout()
            {
                Padding = new Thickness(5),
            };

            nameLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],
                VerticalTextAlignment = TextAlignment.Start,
            };
            detailLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
                VerticalTextAlignment = TextAlignment.Start,
            };

            //Set properties for desired design
            layout.Children.Add(nameLabel);
            layout.Children.Add(detailLabel);

            View = layout;
        }
    }
}

