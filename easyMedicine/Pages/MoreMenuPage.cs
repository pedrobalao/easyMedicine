using System;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{

    public class MenuMorePage : ContentPageBase
    {
        private MenuMorePageModel Model
        {
            get
            {
                return (MenuMorePageModel)base._model;
            }
        }

        public MenuMorePage(MenuMorePageModel model) : base(model)
        {
            Title = "Mais";
            Icon = "ic_more_horiz_white.png";
            var layout = new StackLayout()
            {

            };

            DataTemplate cell;
            if (Device.RuntimePlatform == Device.iOS)
            {
                cell = new DataTemplate(typeof(ImageCell));
                cell.SetBinding(ImageCell.TextProperty, "Title");
                cell.Values[ImageCell.TextColorProperty] = Styles.LETTER_COLOR;
                cell.SetBinding(ImageCell.ImageSourceProperty, "Icon");
            }
            else
            {
                cell = new DataTemplate(typeof(CustomCell));
                cell.SetBinding(CustomCell.NameProperty, "Title");
                //cell.SetBinding(CustomCell.DetailProperty, "Detail");
            }



            var list = new ListView()
            {
                BindingContext = Model,
                ItemTemplate = cell,
                HasUnevenRows = true,
                SeparatorColor = Styles.BLUE_COLOR,
            };
            list.SetBinding(ListView.ItemsSourceProperty, MenuMorePageModel.MenuItemsPropertyName);
            list.SetBinding(ListView.SelectedItemProperty, MenuMorePageModel.SelectedItemPropertyName);

            list.ItemTapped += OnItemTapped;

            layout.Children.Add(list);
            Content = layout;

        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.Model.SelectedItemCommand != null && this.Model.SelectedItemCommand.CanExecute(e))
            {
                Model.SelectedItemCommand.Execute(e.Item);
            }
        }
    }


}
