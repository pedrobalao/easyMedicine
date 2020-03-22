using System;
using System.Threading.Tasks;
using easyMedicine.Services;
using easyMedicine.ViewModels;
using Xamarin.Auth;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class LoginPage : ContentPageBase
    {
        private LoginPageModel Model
        {
            get
            {
                return (LoginPageModel)base._model;
            }
        }

        public LoginPage(LoginPageModel model) : base(model)
        {
            this.BindingContext = Model;

            MessagingCenter.Subscribe<LoginPageModel, string>(this, "AuthenticationError", (sender, arg) =>
            {
                try
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        //UserDialogs.Instance.
                        this.DisplayAlert("AuthenticationError", arg, "OK");
                    });
                }
                catch (Exception e1) { }
            });

            CreateUI();

        }

        private void CreateUI()
        {
            BackgroundColor = Styles.BLUE_COLOR;
            var layout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var grid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });


            var oneLineRowDefinition = new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) };
            //var descriptionRowDefinition = new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) };

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.3, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.3, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.3, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.2, GridUnitType.Star) });

            var brandLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelBrandlStyle],
                Text = "easyPed",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            grid.Children.Add(brandLabel, 0, 0);


            var hashLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelHashlStyle],
                Text = "#makinghealthcareeasier",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            grid.Children.Add(hashLabel, 0, 1);


            var loginLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };


            var facebook = new Button()
            {
                Text = "Facebook",
                TextColor = Color.White,
                //TranslationY = -50,
                Opacity = 5,
                HeightRequest = 40,
                WidthRequest = 200,
                CornerRadius = 20,
                Margin = new Thickness(40, 10, 40, 10),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#3B5998"),
                BindingContext = Model,
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };
            facebook.SetBinding(Button.CommandProperty, LoginPageModel.FacebookSelectedCommandPropertyName);
            loginLayout.Children.Add(facebook);

            var google = new Button()
            {
                Text = "Google",
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
                BindingContext = Model
            };

            google.SetBinding(Button.CommandProperty, LoginPageModel.GoogleSelectedCommandPropertyName);

            loginLayout.Children.Add(google);

            grid.Children.Add(loginLayout, 0, 2);


            var skip = new Button()
            {
                Text = "Avançar",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BindingContext = Model
            };

            skip.Clicked += async (object sender, EventArgs e) =>
            {
                var result = await this.DisplayAlert("Atenção", "Algumas funcionalidades não estão disponíveis para users não autenticados.", "Continuar", "Autenticar");

                if (result)
                {
                    Model.SkipAuthentication();
                }
            };

            grid.Children.Add(skip, 0, 3);

            this.Content = grid;
        }

    }
}


