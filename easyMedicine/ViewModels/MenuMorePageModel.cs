using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using Xamarin.Forms;

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
                new MenuItem("CALCULATIONS", "Cálculos", "ic_poll.png"),
                new MenuItem("SURGERIES", "Referenciação Cirúrgica", "round_verified_user_black_24pt.png"),
                new MenuItem("ABOUT", "Sobre", "ic_info.png"),
            };

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
                    default:
                        throw new NotImplementedException("Menu desconhecido: " + SelectedItem.Id);
                }
            });
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
