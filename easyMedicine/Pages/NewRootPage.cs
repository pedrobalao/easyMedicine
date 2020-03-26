using System;
using easyMedicine.Core;
using easyMedicine.Core.Services;
using easyMedicine.Services;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class NewRootPage : ContentPageBase
    {
        private NewRootPageModel Model
        {
            get
            {
                return (NewRootPageModel)base._model;
            }
        }

        public NewRootPage(NewRootPageModel model) : base(model)

        {
            Title = "easyPed";
            //this.ba = Color.Red;

            MessagingCenter.Subscribe<NewRootPageModel, string>(this, "Alert", (sender, arg) =>
            {
                try
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        //UserDialogs.Instance.
                        this.DisplayAlert("easyPed", arg, "OK");
                    });
                }
                catch (Exception e1) { }
            });

            CreateIU();

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                //UserDialogs.Instance.
                this.DisplayAlert("ATENÇÃO", "A informação presente no easyPed pode conter erros. Não nos responsabilizamos por qualquer consequência do uso da mesma. Toda a informação deve ser validada pelo médico.", "Li e Concordo");
            });

        }

        public View CreateMenuCard(string id, string text, string group, string icon, Color color)
        {

            var frame = new Frame()
            {
                BorderColor = Color.Transparent,
                CornerRadius = 10,
                HasShadow = false,
                BackgroundColor = color,
                WidthRequest = 120,
                HeightRequest = 120
            };

            var stackLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };


            //var img = new Image()
            //{
            //    VerticalOptions = LayoutOptions.Center,
            //    HorizontalOptions = LayoutOptions.Center
            //};

            //img.Source = new FontImageSource()
            //{
            //    FontFamily = (string)Application.Current.Resources[Styles.Font_MaterialFontFamily],
            //    Glyph = icon,
            //    Size = 44,
            //    Color = Color.White
            //};
            //stackLayout.Children.Add(img);

            var labelText = new Label()
            {
                Text = text,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelTilelStyle],
                //BackgroundColor = Color.White,
                TextColor = Color.White,
            };
            //var labelGroup = new Label()
            //{
            //    Text = group
            //};
            stackLayout.Children.Add(labelText);
            //stackLayout.Children.Add(labelGroup);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                // handle the tap
                await Model.LoadPage(id);
            };
            frame.GestureRecognizers.Add(tapGestureRecognizer);

            frame.Content = stackLayout;
            return frame;
        }

        public void CreateIU()
        {

            var scv = new ScrollView()
            {

            };

            var layout = new FlexLayout()
            {
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.SpaceEvenly,
                Margin = new Thickness(5),
                Padding = new Thickness(5)

            };

            var favs = CreateMenuCard("Favourites", "Medicamentos Favoritos", "Medicamentos", String.Empty, Color.FromHex("#38B7EE"));
            layout.Children.Add(favs);
            var search = CreateMenuCard("Search", "Pesquisa de Medicamentos", "Medicamentos", String.Empty, Color.FromHex("#38B7EE"));
            layout.Children.Add(search);
            var explorer = CreateMenuCard("Explore", "Explorar Medicamentos", "Medicamentos", String.Empty, Color.FromHex("#38B7EE"));
            layout.Children.Add(explorer);

            if (Device.RuntimePlatform != "iOS")
            {
                var calc = CreateMenuCard("Calculator", "Calculadoras de Doses", "Medicamentos", String.Empty, Color.FromHex("#38B7EE"));
                layout.Children.Add(calc);

            }
            var diseases = CreateMenuCard("Diseases", "Doenças", "Diseases", String.Empty, Color.FromHex("#EA5B4B"));
            layout.Children.Add(diseases);

            var percentis = CreateMenuCard("Percentiles", "Percentis", "Percentis", String.Empty, Color.FromHex("#0F112A"));
            layout.Children.Add(percentis);

            var medCals = CreateMenuCard("Calculations", "Calculos Médicos", "Calculations", String.Empty, Color.FromHex("#478D52"));
            layout.Children.Add(medCals);

            var refSur = CreateMenuCard("Surgeries", "Referenciação Cirúrgica", "Surgeries", String.Empty, Color.FromHex("#A61D3C"));
            layout.Children.Add(refSur);

            var prof = CreateMenuCard("Profile", "Perfil", "Profile", String.Empty, Color.FromHex("#4B4345"));
            layout.Children.Add(prof);


            var about = CreateMenuCard("About", "Sobre", "About", String.Empty, Styles.BLUE_COLOR);
            layout.Children.Add(about);


            scv.Content = layout;

            this.Content = scv;
        }

    }
}
