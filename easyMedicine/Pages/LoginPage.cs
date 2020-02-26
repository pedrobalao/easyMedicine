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


            MessagingCenter.Subscribe<LoginPageModel, string>(this, "AuthenticationSuccess", (sender, arg) =>
            {
                try
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        //UserDialogs.Instance.
                        //this.DisplayAlert("easyPed", $"Bem-vindo {AuthenticationService.User.DisplayName}", "OK");
                    });
                }
                catch (Exception e1) { }
            });

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


            var headerLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            var brandLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelBrandlStyle],
                Text = "easyPed",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(40, 100)
            };
            headerLayout.Children.Add(brandLabel);

            var hashLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelHashlStyle],
                Text = "#makinghealthcareeasier",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Margin = new Thickness(40, 100)
            };
            headerLayout.Children.Add(hashLabel);

            layout.Children.Add(headerLayout);

            //var email = new Entry()
            //{
            //    Placeholder = "E-mail",
            //    Keyboard = Keyboard.Email
            //};
            //layout.Children.Add(email);

            //var password = new Entry()
            //{
            //    Placeholder = "Password",
            //    IsPassword = true
            //};

            //layout.Children.Add(password);

            var loginLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Margin = new Thickness(0, 50, 00, 200),
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



            var skip = new Button()
            {
                Text = "avançar",
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

            // google.SetBinding(Button.CommandProperty, LoginPageModel.GoogleSelectedCommandPropertyName);
            loginLayout.Children.Add(skip);
            layout.Children.Add(loginLayout);
            this.Content = layout;
        }

    }
}


