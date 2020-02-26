using System;
using easyMedicine.Core.Views;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class CollectUserInfoPage : ContentPageBase
    {
        private CollectUserInfoPageModel Model
        {
            get
            {
                return (CollectUserInfoPageModel)base._model;
            }
        }

        public CollectUserInfoPage(CollectUserInfoPageModel model) : base(model)
        {
            this.BackgroundColor = Styles.BLUE_COLOR;
            this.BindingContext = Model;


            BuildUI();
        }

        private void BuildUI()
        {
            var layout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var quest = new Label
            {
                Text = $"Bem-vindo {CollectUserInfoPageModel.UserName}",
                TextColor = Color.White,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelBrandlStyle]
            };
            layout.Children.Add(quest);
            var sl = new Label
            {
                Text = $"Que tipo utilizador(a) é?",
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                Style = (Style)Application.Current.Resources[Styles.Style_LabelMediumBackgroundStyle]
            };
            layout.Children.Add(sl);


            var lstView = new Repeater()
            {
                Padding = new Thickness(5, 50)
            };
            lstView.SetBinding(Repeater.ItemsSourceProperty, CollectUserInfoPageModel.UserTypeOptionsPropertyName);
            //lstView.SeparatorVisibility = SeparatorVisibility.None;
            lstView.ItemTemplate = new DataTemplate(typeof(ButtonCell));
            lstView.ItemTemplate.SetBinding(ButtonCell.TextProperty, "Value");
            lstView.ItemTemplate.SetBinding(ButtonCell.IdObjProperty, "Key");
            lstView.ItemTemplate.SetBinding(ButtonCell.ButtonPressedCommandProperty, "Command");
            //lstView.SetBinding(ListView.IsVisibleProperty, DrugPageModel.CanCalculateDosePropertyName);

            layout.Children.Add(lstView);

            Content = layout;
        }
    }
}