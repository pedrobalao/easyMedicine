using System;
using easyMedicine.Core.Views;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class ReportErrorPage : ContentPageBase
    {
        private ReportErrorPageModel Model
        {
            get
            {
                return (ReportErrorPageModel)base._model;
            }
        }



        public ReportErrorPage(ReportErrorPageModel model) : base(model)
        {
            this.BindingContext = Model;
            Title = "Reporte de Erro";

            Model.Page = this;

            var layout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var layoutHeader = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5),
            };

            var lbtname = new LabelValue("Medicamento Errado", "Drug.Name");
            layoutHeader.Children.Add(lbtname);

            var lbtName = new Label()
            {
                Text = "Nome",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };

            var entName = new Entry()
            {
                //Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                Placeholder = "Primeiro e último nome"
            };

            entName.SetBinding(Entry.TextProperty, ReportErrorPageModel.NamePropertyName, BindingMode.TwoWay);
            layoutHeader.Children.Add(lbtName);
            layoutHeader.Children.Add(entName);

            var lbtEmail = new Label()
            {
                Text = "Email",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };

            var entEmail = new Entry()
            {
                //Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                Placeholder = "exemplo@email.com"
            };
            entEmail.SetBinding(Entry.TextProperty, ReportErrorPageModel.EmailPropertyName, BindingMode.TwoWay);
            layoutHeader.Children.Add(lbtEmail);
            layoutHeader.Children.Add(entEmail);

            var lbtError = new Label()
            {
                Text = "Descrição",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };


            var edtError = new CustomEditor()
            {
                BackgroundColor = Color.Transparent,
                HeightRequest = 50,
                Placeholder = "Descreva o erro/sugestão",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            edtError.SetBinding(CustomEditor.TextProperty, ReportErrorPageModel.TextPropertyName, BindingMode.TwoWay);
            layoutHeader.Children.Add(lbtError);
            layoutHeader.Children.Add(edtError);

            layout.Children.Add(layoutHeader);

            var btnReportProblem = new Button()
            {
                BindingContext = Model,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Submeter",
                Style = (Style)Application.Current.Resources[Styles.Style_ButtonMediumNegStyle],
            };

            btnReportProblem.SetBinding(Button.CommandProperty, ReportErrorPageModel.CommandReportPropertyName);

            layout.Children.Add(btnReportProblem);


            Content = layout;
        }
    }
}
