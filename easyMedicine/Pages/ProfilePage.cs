using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class ProfilePage : ContentPageBase
    {
        public ProfilePage(ProfilePageModel model) : base(model)
        {
            Title = "Perfil";

            BuildUI();

        }

        private void BuildUI()
        {

            var layout = new StackLayout()
            {
                Padding = 40
            };

            var frame = new Frame()
            {
                CornerRadius = 50,
                HeightRequest = 100,
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                IsClippedToBounds = true
            };
            var image = new Image()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BindingContext = Model
            };

            image.SetBinding(Image.SourceProperty, ProfilePageModel.PhotoUrlPropertyName);
            frame.Content = image;
            layout.Children.Add(frame);

            var name = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BindingContext = Model
            };

            name.SetBinding(Label.TextProperty, ProfilePageModel.DisplayNamePropertyName);
            layout.Children.Add(name);

            var logout = new Button
            {
                BindingContext = Model,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Logout",
                Style = (Style)Application.Current.Resources[Styles.Style_ButtonMediumNegStyle]
            };
            logout.SetBinding(Button.CommandProperty, ProfilePageModel.LogoutCommandPropertyName);
            layout.Children.Add(logout);

            Content = layout;
        }

        private ProfilePageModel Model
        {
            get
            {
                return (ProfilePageModel)base._model;
            }
        }

    }
}
