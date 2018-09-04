using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using Microsoft.Azure.Mobile.Analytics;

namespace easyMedicine.ViewModels
{

    public class SurgeryReferralPageModel : PageModelBase
    {

        public SurgeryReferralPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;
            Observations = new ObservableCollection<string>();
            Referrals = new ObservableCollection<string>();
        }

        // bool _isLoadRunning;
        //public async Task Load()
        //{
        //    _isLoadRunning = true;


        //    _isLoadRunning = false;
        //}



        protected override async System.Threading.Tasks.Task Started()
        {
            await base.Started();


        }

        protected override async Task Activated()
        {
            await base.Activated();
            //if (!_isLoadRunning)
            //await Load();
        }

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;


        private ObservableCollection<string> _Referrals;

        public ObservableCollection<string> Referrals
        {
            get
            {
                return _Referrals;
            }
            set
            {
                _Referrals = value;
                OnPropertyChanged(ReferralsPropertyName);
            }
        }

        public const string ReferralsPropertyName = "Referrals";

        private ObservableCollection<string> _Observations;

        public ObservableCollection<string> Observations
        {
            get
            {
                return _Observations;
            }
            set
            {
                _Observations = value;
                OnPropertyChanged(ObservationsPropertyName);
            }
        }

        private bool _HasObservations;

        public bool HasObservations
        {
            get
            {
                return _HasObservations;
            }
            set
            {
                _HasObservations = value;
                OnPropertyChanged(HasObservationsPropertyName);
            }
        }

        public const string HasObservationsPropertyName = "HasObservations";

        public const string ObservationsPropertyName = "Observations";

        private SurgeryReferral _Surgery;

        public SurgeryReferral Surgery
        {
            get
            {
                return _Surgery;
            }
            set
            {
                _Surgery = value;
                Referrals.Clear();
                foreach (var refe in Surgery.Referral)
                {
                    Referrals.Add(refe);
                }
                Observations.Clear();
                foreach (var obs in Surgery.Observations)
                {
                    HasObservations = true;
                    Observations.Add(obs);
                }

                OnPropertyChanged(SurgeryPropertyName);

                Analytics.TrackEvent("SugeryReferral Opened", new Dictionary<string, string> {
                    { "Surgery", _Surgery.Scope }
                });
            }
        }

        public const string SurgeryPropertyName = "Surgery";


    }
}
