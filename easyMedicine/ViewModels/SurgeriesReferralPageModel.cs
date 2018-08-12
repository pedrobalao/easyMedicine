using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace easyMedicine.ViewModels
{
    public class SurgeriesReferralPageModel : PageModelBase
    {
        bool _isFirstRun;
        public SurgeriesReferralPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _isFirstRun = true;
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;

            SurgeriesReferral = new ObservableCollection<SurgeryReferral>();

            SurgeryReferralSelectedCommand = new Command<SurgeryReferral>(async (cat) => await SurgeryReferralSelected(cat));
        }

        bool _isLoadRunning;
        public async Task Load()
        {
            _isLoadRunning = true;
            SurgeriesReferral.Clear();


            var data = await _drugsDataServ.GetMedicalInfos("PEDIATRIC_SURGERIES_REFERRAL");
            var surgeriesReferral = JsonConvert.DeserializeObject<SurgeriesReferral>(data.DATA);
            foreach (var surg in surgeriesReferral.PediatricSurgeries.OrderBy(x => x.Scope))
            {
                SurgeriesReferral.Add(surg);
            }

            FooterInfo = surgeriesReferral.FooterInfo;

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


        public ICommand SurgeryReferralSelectedCommand { get; private set; }

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;


        private ObservableCollection<SurgeryReferral> _SurgeriesReferral;

        public ObservableCollection<SurgeryReferral> SurgeriesReferral
        {
            get
            {
                return _SurgeriesReferral;
            }
            set
            {
                _SurgeriesReferral = value;
                OnPropertyChanged(SurgeriesReferralPropertyName);
            }
        }

        public const string SurgeriesReferralPropertyName = "SurgeriesReferral";

        private string _FooterInfo;

        public string FooterInfo
        {
            get
            {
                return _FooterInfo;
            }
            set
            {
                _FooterInfo = value;
                OnPropertyChanged(FooterInfoPropertyName);
            }
        }

        public const string FooterInfoPropertyName = "FooterInfo";


        async Task SurgeryReferralSelected(SurgeryReferral tappedItem)
        {
            Debug.WriteLine("Tapped Cat -> " + tappedItem.Scope);

            await _navigator.PushAsync<SurgeryReferralPageModel>("SurgeryReferral", (model) =>
            {
                model.Surgery = tappedItem;
            });

        }
    }
}
