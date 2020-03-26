using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Services;
using Xamarin.Forms;
using System.Linq;
using easyMedicine.Core;

namespace easyMedicine.ViewModels
{
    public class MenuItem
    {
        public MenuItem(string id, string title, string icon)
        {
            Id = id;
            Title = title;
            Icon = icon;
        }

        public string Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }

        public string Icon
        {
            get;
            set;
        }


    }

    public class MenuMorePageModel : PageModelBase
    {
        INavigatorService _navigator;
        public MenuMorePageModel(INavigatorService navigator)
        {
            _navigator = navigator;

            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem("CALCULATIONS", "Cálculos", String.Empty),
                new MenuItem("SURGERIES", "Referenciação Cirúrgica", String.Empty),
                new MenuItem("DISEASES", "Doenças", String.Empty),
                new MenuItem("ABOUT", "Sobre", String.Empty),

            };

            if (AuthenticationService.IsUserAuthenticated)
            {
                MenuItems.Add(new MenuItem("PROFILE", AuthenticationService.User.DisplayName, AuthenticationService.User.PhotoUrl));
            }

            SelectedItemCommand = new Command<MenuItem>(async (item) =>
            {

                switch (item.Id)
                {
                    case "ABOUT":
                        await _navigator.PushAsync<AboutPageModel>("About", (model) => { });
                        break;
                    case "CALCULATIONS":
                        await _navigator.PushAsync<MedicalCalculationListPageModel>("Calculations", (model) => { });
                        break;
                    case "SURGERIES":
                        await _navigator.PushAsync<SurgeriesReferralPageModel>("Surgeries", (model) => { });
                        break;
                    case "PROFILE":
                        await _navigator.PushAsync<ProfilePageModel>("Profile", (model) => { });
                        break;
                    case "DISEASES":
                        await _navigator.PushAsync<DiseasesListPageModel>("Diseases", (model) => { });
                        break;


                    default:
                        throw new NotImplementedException("Menu desconhecido: " + SelectedItem.Id);
                }
            });
        }

        protected override async Task Activated()
        {
            if (AuthenticationService.IsUserAuthenticated && !MenuItems.Any(x => x.Id == "PROFILE"))
            {
                MenuItems.Add(new MenuItem("PROFILE", AuthenticationService.User.DisplayName, AuthenticationService.User.PhotoUrl));
            }
        }

        private ICommand _SelectedItemCommand;

        public ICommand SelectedItemCommand
        {
            get
            {
                return _SelectedItemCommand;
            }
            set
            {
                _SelectedItemCommand = value;
                OnPropertyChanged(SelectedItemCommandPropertyName);
            }
        }

        public const string SelectedItemCommandPropertyName = "SelectedItemCommand";

        private MenuItem _SelectedItem;

        public MenuItem SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged(SelectedItemPropertyName);
            }
        }

        public const string SelectedItemPropertyName = "SelectedItem";

        private ObservableCollection<MenuItem> _MenuItems;

        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                return _MenuItems;
            }
            set
            {
                _MenuItems = value;
                OnPropertyChanged(MenuItemsPropertyName);
            }
        }

        public const string MenuItemsPropertyName = "MenuItems";


    }
}
