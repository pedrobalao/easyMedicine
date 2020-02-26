using System;
using System.Threading.Tasks;
using easyMedicine.Core.Views;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class DiseasesListPage : ContentPageBase
    {
        private DiseasesListPageModel Model
        {
            get
            {
                return (DiseasesListPageModel)base._model;
            }
        }

        public DiseasesListPage(DiseasesListPageModel model) : base(model)
        {
            Title = "Doenças";
            Icon = "ic_search_white_48px.png";

            Model.Unauthorized += async (object sender, EventArgs e) =>
            {
                await ShowUnauthorizeUI();
            };

            Model.Error += async (object sender, string e) =>
            {
                await ShowErrorUI(e);
            }
;
            BuildUI();
        }

        private void BuildUI()
        {
            var layout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var sbar = GetSearchBar();

            var list = GetList();

            layout.Children.Add(sbar);
            layout.Children.Add(list);
            Content = layout;

        }

        private async Task ShowErrorUI(string message)
        {
            await DisplayAlert(this.Title, message, "OK");

            await Model.GoBack();

        }

        private async Task ShowUnauthorizeUI()
        {
            var result = await DisplayAlert(this.Title, "O acesso a esta funcionalidade exige autenticação.", "Autenticar", "Sair");

            if (result)
            {
                await Model.Authenticate();
            }

            await Model.GoBack();

        }

        private View GetList()
        {
            var cell = new DataTemplate(typeof(CustomCell));
            cell.SetBinding(CustomCell.NameProperty, "description");
            //cell.SetBinding(CustomCell.DetailProperty, "indication");

            var list = new ListView()
            {
                BindingContext = Model,
                ItemTemplate = cell,
                HasUnevenRows = true,
                SeparatorColor = Styles.BLUE_COLOR,
            };
            list.SetBinding(ListView.ItemsSourceProperty, DiseasesListPageModel.SearchResultPropertyName);

            list.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item != null && this.Model.DiseaseSelectedCommand != null && this.Model.DiseaseSelectedCommand.CanExecute(e))
                {
                    Model.DiseaseSelectedCommand.Execute(e.Item);
                }
            };

            return list;


        }

        private View GetSearchBar()
        {
            var sbar = new SearchBarDelayChange()
            {
                BindingContext = Model,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Placeholder = "Pesquisa",
            };
            sbar.SetBinding(SearchBar.TextProperty, DiseasesListPageModel.SearchStringPropertyName, BindingMode.TwoWay);


            if (Device.RuntimePlatform == Device.Android)
            {
                //Fixes an android bug where the search bar would be hidden
                sbar.HeightRequest = 40.0;
            }
            //sbar.SetBinding(SearchBar.SearchCommandProperty, SearchPageModel.SearchStringPropertyName, BindingMode.TwoWay);

            sbar.DelayedTextChanged += async (sender, e) => await Model.SearchDisease();
            sbar.SearchButtonPressed += async (sender, e) =>
            {
                await Model.SearchDisease();
            };

            return sbar;
        }

    }
}
