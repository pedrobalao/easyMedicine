﻿using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class AboutPage : ContentPageBase
    {
        private AboutPageModel Model
        {
            get
            {
                return (AboutPageModel)base._model;
            }
        }

        [Obsolete]
        public AboutPage(AboutPageModel model) : base(model)
        {
            Title = "Sobre";

            if (Device.RuntimePlatform == Device.iOS)
                IconImageSource = "ic_error_white_18pt.png";
            else
                IconImageSource = "ic_error_white_48px.png";

            var scroll = new ScrollView()
            { };

            var layout = new StackLayout()
            {
                Padding = new Thickness(5, 20),
            };

            var labelfb = new Label()
            {
                Text = "Entra em contato connosco",
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],

            };
            layout.Children.Add(labelfb);

            var fbLink = new Label()
            {
                Text = "facebook.com/easyped",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],

            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Device.OpenUri(new Uri(@"https://www.facebook.com/easyPed"));
            };
            fbLink.GestureRecognizers.Add(tapGestureRecognizer);
            layout.Children.Add(fbLink);


            var siteLink = new Label()
            {
                Text = "easyped.eu",
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],

            };
            var siteLinktapGestureRecognizer = new TapGestureRecognizer();
            siteLinktapGestureRecognizer.Tapped += (s, e) =>
            {
                Device.OpenUri(new Uri(@"http://www.easyped.eu"));
            };
            siteLink.GestureRecognizers.Add(siteLinktapGestureRecognizer);
            layout.Children.Add(siteLink);



            var labelAuthors = new Label()
            {
                Text = "Autores",
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],

            };
            layout.Children.Add(labelAuthors);

            var labelNames = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyleNormal],

            };

            labelNames.SetBinding(Label.TextProperty, AboutPageModel.CreditsPropertyName);
            layout.Children.Add(labelNames);



            var labelAbout = new Label()
            {
                Text = "Isenção de Responsabilidade",
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],

            };
            layout.Children.Add(labelAbout);

            var labelDiscloser = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyleNormal],
            };

            labelDiscloser.SetBinding(Label.TextProperty, AboutPageModel.DiscloserPropertyName);
            layout.Children.Add(labelDiscloser);

            var labelBiblioLb = new Label()
            {
                Text = "Bibliografia essencial consultada",
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],

            };
            layout.Children.Add(labelBiblioLb);

            var labelBiblio = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyleNormal],
            };

            labelBiblio.SetBinding(Label.TextProperty, AboutPageModel.BiblioPropertyName);
            layout.Children.Add(labelBiblio);




            var bdLB = new Label()
            {
                Text = "Versão Base de Dados",
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],

            };
            layout.Children.Add(bdLB);

            var bdVersion = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],

            };
            bdVersion.SetBinding(Label.TextProperty, AboutPageModel.BDVersionPropertyName);

            layout.Children.Add(bdVersion);




            scroll.Content = layout;
            //var lbtCredits = new LabelValue("Créditos", AboutPageModel.CreditsPropertyName);
            //layout.Children.Add(lbtCredits);

            Content = scroll;
        }

    }
}

