using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class CalculatorListPage : ContentPageBase
    {
        private CalculatorListPageModel Model
        {
            get
            {
                return (CalculatorListPageModel)base._model;
            }
        }


        public CalculatorListPage(CalculatorListPageModel model) : base(model)
        {
            Title = "Calcular Doses";
            Icon = "ic_opacity_white.png";

            var cell = new DataTemplate(typeof(CustomCell));
            cell.SetBinding(CustomCell.NameProperty, "Name");
            cell.SetBinding(CustomCell.DetailProperty, "Detail");

            var list = new ListView()
            {
                BindingContext = Model,
                ItemTemplate = cell,
                HasUnevenRows = true,
                SeparatorColor = Styles.BLUE_COLOR,
            };
            list.SetBinding(ListView.ItemsSourceProperty, CalculatorListPageModel.DrugsPropertyName);

            list.ItemTapped += OnItemTapped;

            this.Content = list;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.Model.DrugSelectedCommand != null && this.Model.DrugSelectedCommand.CanExecute(e))
            {
                Model.DrugSelectedCommand.Execute(e.Item);
            }
        }
    }
}
