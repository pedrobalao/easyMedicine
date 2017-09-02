using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using Xamarin.Forms;
using System.Linq;

namespace easyMedicine.ViewModels
{
    public class FavouritesPageModel : PageModelBase
    {
        public FavouritesPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;

            Drugs = new ObservableCollection<Drug>();

            DrugSelectedCommand = new Command<Drug>(async (cat) => await DrugSelected(cat));
        }

        public async Task Load()
        {
            Drugs.Clear();


            var data = await _drugsDataServ.GetFavourites();
            foreach (var clicat in data)
            {
                Drugs.Add(clicat);
            }
        }

        public async Task<bool> HasFavourites()
        {
            var data = await _drugsDataServ.GetFavourites();

            return data.Count() > 0;
        }


        protected override async System.Threading.Tasks.Task Started()
        {
            await base.Started();

            await Load();

            if (Drugs.Count() == 0)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _navigator.RootPage.CurrentPage = _navigator.RootPage.Children[2];
                });
            }

        }

        protected override async Task Activated()
        {
            await base.Activated();

            await Load();
        }


        public ICommand DrugSelectedCommand { get; private set; }

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;

        private ObservableCollection<Drug> _Drugs;

        public ObservableCollection<Drug> Drugs
        {
            get
            {
                return _Drugs;
            }
            set
            {
                _Drugs = value;
                OnPropertyChanged(DrugsPropertyName);
            }
        }

        public const string DrugsPropertyName = "Drugs";


        private Drug _SelectedDrug;

        public Drug SelectedDrug
        {
            get
            {
                return _SelectedDrug;
            }
            set
            {
                _SelectedDrug = value;
                OnPropertyChanged(SelectedDrugPropertyName);
            }
        }

        public const string SelectedDrugPropertyName = "SelectedDrug";


        async Task DrugSelected(Drug tappedItem)
        {
            Debug.WriteLine("Tapped Cat -> " + tappedItem.Name);

            await _navigator.PushAsync<DrugPageModel>("Drug", (model) =>
            {
                model.DrugId = tappedItem.Id;
            });
        }
    }
}

