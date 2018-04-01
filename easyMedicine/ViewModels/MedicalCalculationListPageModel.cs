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

namespace easyMedicine.ViewModels
{
    public class MedicalCalculationListPageModel : PageModelBase
    {
        bool _isFirstRun;
        public MedicalCalculationListPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _isFirstRun = true;
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;

            MedicalCalculations = new ObservableCollection<MedicalCalculation>();

            MedicalCalculationSelectedCommand = new Command<MedicalCalculation>(async (cat) => await MedicalCalculationSelected(cat));
        }

        bool _isLoadRunning;
        public async Task Load()
        {
            _isLoadRunning = true;
            MedicalCalculations.Clear();


            var data = await _drugsDataServ.GetMedicalCalculations();
            foreach (var clicat in data)
            {
                MedicalCalculations.Add(clicat);
            }

            _isLoadRunning = false;
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


        public ICommand MedicalCalculationSelectedCommand { get; private set; }

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;


        private ObservableCollection<MedicalCalculation> _MedicalCalculations;

        public ObservableCollection<MedicalCalculation> MedicalCalculations
        {
            get
            {
                return _MedicalCalculations;
            }
            set
            {
                _MedicalCalculations = value;
                OnPropertyChanged(MedicalCalculationsPropertyName);
            }
        }

        public const string MedicalCalculationsPropertyName = "MedicalCalculations";



        async Task MedicalCalculationSelected(MedicalCalculation tappedItem)
        {
            Debug.WriteLine("Tapped Cat -> " + tappedItem.Description);

            await _navigator.PushAsync<MedicalCalculationPageModel>("MedicalCalculation", (model) =>
            {
                model.MedicalCalculationId = tappedItem.Id;
            });
        }
    }
}
