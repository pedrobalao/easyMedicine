using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{

    public class MedicalCalculationListPage : ContentPageBase
    {
        private MedicalCalculationListPageModel Model
        {
            get
            {
                return (MedicalCalculationListPageModel)base._model;
            }
        }


        public MedicalCalculationListPage(MedicalCalculationListPageModel model) : base(model)
        {
            Title = "Cálculos";
            Icon = "ic_explore_white_48px.png";
            var layout = new StackLayout()
            {

            };


            var cell = new DataTemplate(typeof(CustomCell));
            cell.SetBinding(CustomCell.NameProperty, "Description");


            var list = new ListView()
            {
                BindingContext = Model,
                ItemTemplate = cell,
                HasUnevenRows = true,
                SeparatorColor = Styles.BLUE_COLOR,

            };
            list.SetBinding(ListView.ItemsSourceProperty, MedicalCalculationListPageModel.MedicalCalculationsPropertyName);

            list.ItemTapped += OnItemTapped;

            layout.Children.Add(list);
            Content = layout;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.Model.MedicalCalculationSelectedCommand != null && this.Model.MedicalCalculationSelectedCommand.CanExecute(e))
            {
                Model.MedicalCalculationSelectedCommand.Execute(e.Item);
            }
        }
    }

}
