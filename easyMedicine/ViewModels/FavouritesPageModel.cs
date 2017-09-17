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
        bool _isFirstRun;
        public FavouritesPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _isFirstRun = true;
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;

            Drugs = new ObservableCollection<Drug>();

            DrugSelectedCommand = new Command<Drug>(async (cat) => await DrugSelected(cat));
        }

        bool _isLoadRunning;
        public async Task Load()
        {
            _isLoadRunning = true;
            Drugs.Clear();


            var data = await _drugsDataServ.GetFavourites();
            foreach (var clicat in data)
            {
                Drugs.Add(clicat);
            }

            if (_isFirstRun)
            {
                if (Drugs.Count() == 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        _navigator.RootPage.CurrentPage = _navigator.RootPage.Children[2];
                    });
                }
            }

            _isFirstRun = false;
            _isLoadRunning = false;
        }

        public async Task<bool> HasFavourites()
        {
            var data = await _drugsDataServ.GetFavourites();

            return data.Count() > 0;
        }


        protected override async System.Threading.Tasks.Task Started()
        {
            await base.Started();


#if __IOS__
            await Load();
#endif
        }

        protected override async Task Activated()
        {
            await base.Activated();
            if (!_isLoadRunning)
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

