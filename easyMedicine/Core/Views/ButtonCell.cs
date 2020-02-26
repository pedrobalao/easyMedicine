
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace easyMedicine
{
    public class ButtonCell : ViewCell
    {


        Button button;

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(CustomCell), "Text");

        public static readonly BindableProperty IdObjProperty =
            BindableProperty.Create("IdObj", typeof(string), typeof(CustomCell), "Id");

        public static readonly BindableProperty ButtonPressedCommandProperty =
            BindableProperty.Create("ButtonPressedCommand", typeof(ICommand), typeof(ButtonCell), default(ICommand), BindingMode.TwoWay);


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string IdObj
        {
            get { return (string)GetValue(IdObjProperty); }
            set { SetValue(IdObjProperty, value); }
        }

        public ICommand ButtonPressedCommand
        {
            get
            {
                return (ICommand)GetValue(ButtonPressedCommandProperty);
            }
            set
            {
                SetValue(ButtonPressedCommandProperty, value);
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                button.Text = Text;
            }
        }
        public ButtonCell()
        {

            var layout = new StackLayout()
            {
                Padding = new Thickness(5),
                VerticalOptions = LayoutOptions.Center
            };

            button = new Button()
            {
                TextColor = Color.White,
                //TranslationY = -50,
                Opacity = 5,
                HeightRequest = 40,
                WidthRequest = 200,
                CornerRadius = 20,
                Margin = new Thickness(40, 10, 40, 10),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#DB4437"),
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };

            button.Clicked += Button_Clicked;


            layout.Children.Add(button);

            View = layout;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            var button = (Button)sender;

            if (ButtonPressedCommand == null)
            {
                return;
            }
            if (ButtonPressedCommand.CanExecute(this))
            {
                ButtonPressedCommand.Execute(this.IdObj);
            }

        }
    }
}


