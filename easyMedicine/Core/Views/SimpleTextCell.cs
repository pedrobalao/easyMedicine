
using System;
using Xamarin.Forms;

namespace easyMedicine
{
    public class SimpleTextCell : ViewCell
    {


        Label nameLabel;

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name", typeof(string), typeof(CustomCell), "Name");

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }



        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                nameLabel.Text = Name;
            }
        }
        public SimpleTextCell()
        {

            var layout = new StackLayout()
            {
                Padding = new Thickness(5),
                VerticalOptions = LayoutOptions.Center
            };

            nameLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                VerticalTextAlignment = TextAlignment.Center,
            };

            //Set properties for desired design
            layout.Children.Add(nameLabel);

            View = layout;
        }
    }
}


