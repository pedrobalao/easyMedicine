using System;
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


        public AboutPage(AboutPageModel model) : base(model)
        {
            Title = "Créditos";
            Icon = "ic_report_problem_white_48pt.png";


            var layout = new StackLayout()
            {
                Padding = new Thickness(5, 20),
            };


            var labelNames = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumStyle],

            };

            labelNames.SetBinding(Label.TextProperty, AboutPageModel.CreditsPropertyName);
            layout.Children.Add(labelNames);

            //var lbtCredits = new LabelValue("Créditos", AboutPageModel.CreditsPropertyName);
            //layout.Children.Add(lbtCredits);

            Content = layout;
        }

    }
}

