using System;
using easyMedicine.Core.Views;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{

    public class SurgeryReferralPage : ContentPageBase
    {
        private SurgeryReferralPageModel Model
        {
            get
            {
                return (SurgeryReferralPageModel)base._model;
            }
        }


        public SurgeryReferralPage(SurgeryReferralPageModel model) : base(model)
        {
            this.BindingContext = Model;
            //this.SetBinding(Page.TitleProperty, "Surgery.Scope");
            Title = "Referenciação Cirúrgica";


            var layoutHeader = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5),
            };

            var lbtname = new LabelValue("Cirurgia", "Surgery.Scope")
            {
                Padding = new Thickness(0, 5, 0, 5)
            };
            layoutHeader.Children.Add(lbtname);


            var refView = GetReferralView();

            layoutHeader.Children.Add(refView);

            var obsView = GetObservationsView();
            layoutHeader.Children.Add(obsView);

            var sv = new ScrollView
            {
                Content = layoutHeader
            };

            Content = sv;

        }


        private View GetObservationsView()
        {
            var mainLayout = new StackLayout() { };
            mainLayout.SetBinding(StackLayout.IsVisibleProperty, SurgeryReferralPageModel.HasObservationsPropertyName);


            var labelDoseCalc = new Label()
            {
                Text = "Observações",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            mainLayout.Children.Add(labelDoseCalc);


            var lstView = new Repeater()
            {
                BindingContext = Model
            };
            lstView.ItemTemplate = new DataTemplate(typeof(SimpleTextCell));
            lstView.ItemTemplate.SetBinding(SimpleTextCell.NameProperty, ".");
            lstView.SetBinding(Repeater.ItemsSourceProperty, SurgeryReferralPageModel.ObservationsPropertyName);

            mainLayout.Children.Add(lstView);

            return mainLayout;
        }

        private View GetReferralView()
        {
            var mainLayout = new StackLayout() { };
            //mainLayout.SetBinding(StackLayout.IsVisibleProperty, DrugPageModel.CanCalculateDosePropertyName);


            var labelDoseCalc = new Label()
            {
                Text = "Referenciação",
                Style = (Style)Application.Current.Resources[Styles.Style_LabelSmallStyle],
            };
            mainLayout.Children.Add(labelDoseCalc);


            var lstView = new Repeater()
            {
                BindingContext = Model
            };
            lstView.ItemTemplate = new DataTemplate(typeof(SimpleTextCell));
            lstView.ItemTemplate.SetBinding(SimpleTextCell.NameProperty, ".");
            lstView.SetBinding(Repeater.ItemsSourceProperty, SurgeryReferralPageModel.ReferralsPropertyName);


            mainLayout.Children.Add(lstView);

            return mainLayout;
        }
    }

}
