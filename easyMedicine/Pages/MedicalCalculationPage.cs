using System;
using easyMedicine.Core.Converters;
using easyMedicine.Core.Views;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class MedicalCalculationPage : ContentPageBase
    {
        private MedicalCalculationPageModel Model
        {
            get
            {
                return (MedicalCalculationPageModel)base._model;
            }
        }


        public MedicalCalculationPage(MedicalCalculationPageModel model) : base(model)
        {
            Title = "Calculadora";

            this.BindingContext = model;
            this.SetBinding(Page.TitleProperty, "MedicalCalculationFull.Calculation.Description");

            Icon = "ic_explore_white_48px.png";
            var layout = new StackLayout()
            {

            };

            var calculationView = GetCalculationView();
            layout.Children.Add(calculationView);

            Content = layout;
        }


        private View GetCalculationView()
        {

            var stackCalculation = new StackLayout()
            {
                BindingContext = Model,
                Padding = new Thickness(5),

            };

            var lbtVar = new Label()
            {
                Text = "Variáveis",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };

            stackCalculation.Children.Add(lbtVar);

            var lstView = new Repeater()
            {
            };
            lstView.SetBinding(Repeater.ItemsSourceProperty, MedicalCalculationPageModel.VariablesPropertyName);
            lstView.ItemTemplate = new DataTemplate(typeof(VariableCell));
            lstView.ItemTemplate.SetBinding(VariableCell.DescriptionProperty, "Description");
            lstView.ItemTemplate.SetBinding(VariableCell.UnitProperty, "IdUnit");
            lstView.ItemTemplate.SetBinding(VariableCell.ValueProperty, "Value");
            lstView.ItemTemplate.SetBinding(VariableCell.ValueStrProperty, "ValueStr");
            lstView.ItemTemplate.SetBinding(VariableCell.HasFixedValuesProperty, "HasFixedValues");
            lstView.ItemTemplate.SetBinding(VariableCell.ValuesProperty, "Values");


            lstView.ItemTemplate.SetBinding(VariableCell.InputChangedCommandProperty, "ValueChangedCommand");

            stackCalculation.Children.Add(lstView);

            var lbtRes = new Label()
            {
                Text = "Resultado",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            stackCalculation.Children.Add(lbtRes);

            var resStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var resultLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelResultValueStyle],
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            resultLabel.BindingContext = Model;
            resultLabel.SetBinding(Label.TextProperty, MedicalCalculationPageModel.ResultPropertyName);

            resStack.Children.Add(resultLabel);

            var unitLabel = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelResultUnitStyle],
                VerticalOptions = LayoutOptions.Center
            };
            unitLabel.BindingContext = Model;
            unitLabel.SetBinding(Label.TextProperty, MedicalCalculationPageModel.ResultUnitIdPropertyName);

            resStack.Children.Add(unitLabel);

            stackCalculation.Children.Add(resStack);

            var lbtConterIndications = new LabelValue("Observações", "MedicalCalculationFull.Calculation.Observation");
            stackCalculation.Children.Add(lbtConterIndications);


            return stackCalculation;
        }

    }
}
