using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{

    public class SurgeriesReferralPage : ContentPageBase
    {
        private SurgeriesReferralPageModel Model
        {
            get
            {
                return (SurgeriesReferralPageModel)base._model;
            }
        }


        public SurgeriesReferralPage(SurgeriesReferralPageModel model) : base(model)
        {
            Title = "Referenciação Cirúrgica";
            Icon = "ic_explore_white_48px.png";
            var layout = new StackLayout()
            {

            };


            var cell = new DataTemplate(typeof(CustomCell));
            cell.SetBinding(CustomCell.NameProperty, "Scope");


            var list = new ListView()
            {
                BindingContext = Model,
                ItemTemplate = cell,
                HasUnevenRows = true,
                SeparatorColor = Styles.BLUE_COLOR,

            };
            list.SetBinding(ListView.ItemsSourceProperty, SurgeriesReferralPageModel.SurgeriesReferralPropertyName);

            list.ItemTapped += OnItemTapped;


            //var headerSL = new StackLayout()
            //{
            //    Padding = new Thickness(5),
            //    VerticalOptions = LayoutOptions.Center
            //};
            //var lbMemorium = new Label()
            //{
            //    VerticalTextAlignment = TextAlignment.Center,
            //    HorizontalTextAlignment = TextAlignment.Center,
            //    Text = "Em memória do\nProf. Dr. Tiago Henriques Coelho"
            //};


            //headerSL.Children.Add(lbMemorium);
            //list.Header = headerSL;

            var footerSL = new StackLayout()
            {
                Padding = new Thickness(5),
                VerticalOptions = LayoutOptions.Center
            };
            var lbFooter = new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            lbFooter.SetBinding(Label.TextProperty, SurgeriesReferralPageModel.FooterInfoPropertyName);

            footerSL.Children.Add(lbFooter);



            var lbMemorium = new Label()
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelIndincValueStyle],
                Text = "Em memória do\nProf. Dr. Tiago Henriques Coelho"
            };

            footerSL.Children.Add(lbMemorium);

            list.Footer = footerSL;

            layout.Children.Add(list);


            Content = layout;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.Model.SurgeryReferralSelectedCommand != null && this.Model.SurgeryReferralSelectedCommand.CanExecute(e))
            {
                Model.SurgeryReferralSelectedCommand.Execute(e.Item);
            }
        }
    }
}
