using System;
using System.Threading.Tasks;
using easyMedicine.Core.Converters;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class DiseasePage : ContentPageBase
    {
        private DiseasePageModel Model
        {
            get
            {
                return (DiseasePageModel)base._model;
            }
        }

        public DiseasePage(DiseasePageModel model) : base(model)
        {
            this.BackgroundColor = Color.White;
            this.BindingContext = Model;
            this.SetBinding(Page.TitleProperty, "Disease.description");

            Model.Error += async (object sender, string e) =>
            {
                await ShowErrorUI(e);
            }

            BuildUI();
        }
        private async Task ShowErrorUI(string message)
        {
            await DisplayAlert(this.Title, message, "OK");

            await Model.GoBack();

        }


        void BuildUI()
        {
            var layoutHeader = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5),
                BackgroundColor = Color.White
            };

            var lbtname = new LabelValue("Doença", "Disease.description");
            layoutHeader.Children.Add(lbtname);

            var lbtauthor = new LabelValue("Autor", "Disease.author");
            layoutHeader.Children.Add(lbtauthor);

            var lbtindication = new LabelValue("Indicação", "Disease.indication");
            layoutHeader.Children.Add(lbtindication);

            var lbttreatment_description = new Label()
            {
                Text = "Tratamento",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };

            layoutHeader.Children.Add(lbttreatment_description);
            var treatmentWV = new WebView()
            {
                BindingContext = Model,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            treatmentWV.SetBinding(WebView.SourceProperty, "Disease.treatment_description", BindingMode.OneWay, new HtmlSourceConverter());
            layoutHeader.Children.Add(treatmentWV);

            var lbtfollowup = new LabelValue("Follow up", "Disease.followup");
            lbtfollowup.SetBinding(LabelValue.IsVisibleProperty, "Disease.followup", BindingMode.OneWay, new StringToBoolConverter());
            layoutHeader.Children.Add(lbtfollowup);

            var lbtexample = new LabelValue("Exemplo", "Disease.example");
            lbtexample.SetBinding(LabelValue.IsVisibleProperty, "Disease.example", BindingMode.OneWay, new StringToBoolConverter());
            layoutHeader.Children.Add(lbtexample);

            var lbtbibliography = new LabelValue("Bibliografia", "Disease.bibliography");
            lbtbibliography.SetBinding(LabelValue.IsVisibleProperty, "Disease.bibliography", BindingMode.OneWay, new StringToBoolConverter());
            layoutHeader.Children.Add(lbtbibliography);

            var lbtobservation = new LabelValue("Observações", "Disease.observation");
            lbtobservation.SetBinding(LabelValue.IsVisibleProperty, "Disease.observation", BindingMode.OneWay, new StringToBoolConverter());
            layoutHeader.Children.Add(lbtobservation);


            ScrollView scrollView = new ScrollView();
            scrollView.Content = layoutHeader;
            Content = scrollView;

        }
    }
}
