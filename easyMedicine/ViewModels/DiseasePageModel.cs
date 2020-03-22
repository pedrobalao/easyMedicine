using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using Microsoft.AppCenter.Analytics;
using Xamarin.Essentials;

namespace easyMedicine.ViewModels
{
    public class DiseasePageModel : PageModelBase
    {

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;
        //public ICommand DrugSelectedCommand { get; private set; }
        DiseaseService diseaseService;

        private int _DiseaseId;

        public int DiseaseId
        {
            get
            {
                return _DiseaseId;
            }
            set
            {
                _DiseaseId = value;
                OnPropertyChanged(DiseaseIdPropertyName);
            }
        }

        public const string DiseaseIdPropertyName = "DiseaseId";

        private Disease _Disease;

        public Disease Disease
        {
            get
            {
                return _Disease;
            }
            set
            {
                _Disease = value;
                OnPropertyChanged(DiseasePropertyName);
            }
        }

        public const string DiseasePropertyName = "Disease";


        private ObservableCollection<Condition> _Conditions;

        public ObservableCollection<Condition> Conditions
        {
            get
            {
                return _Conditions;
            }
            set
            {
                _Conditions = value;
                OnPropertyChanged(ConditionsPropertyName);
            }
        }

        public const string ConditionsPropertyName = "Conditions";


        public DiseasePageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;
            diseaseService = new DiseaseService();
            Conditions = new ObservableCollection<Condition>();

        }

        public async Task GoBack()
        {
            await _navigator.PopAsync();
        }

        public event EventHandler<string> Error;

        protected override async Task Activated()
        {
            try
            {
                this.Disease = await diseaseService.GetDisease(this.DiseaseId);
                Conditions.Clear();
                if (Disease.treatment != null && Disease.treatment.conditions != null)
                {
                    foreach (var cond in Disease.treatment.conditions)
                    {
                        Conditions.Add(cond);
                    }
                }
                Analytics.TrackEvent("Disease Opened", new Dictionary<string, string> {
                { "DiseaseId", this.DiseaseId.ToString() },
                { "DiseaseName", Disease.description}
            });
            }
            catch (Exception e1)
            {
                var current = Connectivity.NetworkAccess;

                if (current != NetworkAccess.Internet)
                {
                    // Connection to internet is available
                    Error?.Invoke(this, "Esta funcionalidade exige acesso à internet. Por favor valide que tem conectividade e tente novamente. Obrigado");

                }
                else
                {
                    Error?.Invoke(this, "Ups!! Algo correu mal. Temos os nossos melhores engenheiros a tentar resolvê-lo.");
                }

                Analytics.TrackEvent("Open diseases Error", new Dictionary<string, string>
                {
                    {"Message", e1.Message},
                    {"Exception", e1.StackTrace}
                });

            }

        }

    }
}
