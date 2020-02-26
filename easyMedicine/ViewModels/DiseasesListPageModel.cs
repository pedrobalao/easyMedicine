using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Microsoft.AppCenter.Analytics;
using Xamarin.Essentials;

namespace easyMedicine.ViewModels
{
    public class DiseasesListPageModel : PageModelBase
    {

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;
        //public ICommand DrugSelectedCommand { get; private set; }
        DiseaseService diseaseService;
        List<DiseaseLight> diseaseFullList;

        public DiseasesListPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;
            diseaseService = new DiseaseService();

            DiseaseSelectedCommand = new Command<DiseaseLight>(async (cat) =>
            {
                await _navigator.PushAsync<DiseasePageModel>("Disease", (model) =>
                {
                    model.DiseaseId = cat.id;
                });
            });

            SearchResult = new ObservableCollection<DiseaseLight>();
            diseaseFullList = new List<DiseaseLight>();
        }

        public async Task GoBack()
        {
            await _navigator.PopAsync();
        }

        public async Task Authenticate()
        {
            await _navigator.ReplaceRoot<LoginPageModel>("login");
        }

        public ICommand DiseaseSelectedCommand
        {
            get;
            private set;
        }


        public const string DiseaseSelectedCommandPropertyName = "DiseaseSelectedCommand";



        private ObservableCollection<DiseaseLight> _SearchResult;

        public ObservableCollection<DiseaseLight> SearchResult
        {
            get
            {
                return _SearchResult;
            }
            set
            {
                _SearchResult = value;
                OnPropertyChanged(SearchResultPropertyName);
            }
        }

        public const string SearchResultPropertyName = "SearchResult";



        private string _SearchString;

        public string SearchString
        {
            get
            {
                return _SearchString;
            }
            set
            {
                _SearchString = value;
                OnPropertyChanged(SearchStringPropertyName);
            }
        }

        public const string SearchStringPropertyName = "SearchString";

        public async Task SearchDisease()
        {
            SearchResult.Clear();

            try
            {


                if (String.IsNullOrWhiteSpace(SearchString))
                {
                    diseaseFullList.All((x) =>
                    {
                        SearchResult.Add(x);
                        return true;
                    });
                    return;
                }
                else if (SearchString.Length < 3)
                {
                    return;
                }

                var res = await diseaseService.Search(SearchString);
                //@TODO validar erros

                res.All((x) =>
                {
                    SearchResult.Add(x);
                    return true;
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

                Analytics.TrackEvent("Search diseases Error", new Dictionary<string, string>
                {
                    {"Message", e1.Message},
                    {"Exception", e1.StackTrace}
                });

            }
        }

        public event EventHandler Unauthorized;

        public event EventHandler<string> Error;

        protected override async Task Activated()
        {
            try
            {
                if (!AuthenticationService.IsUserAuthenticated)
                {
                    Unauthorized?.Invoke(this, EventArgs.Empty);
                    return;
                }
                diseaseFullList = await diseaseService.List();
                await SearchDisease();
                Analytics.TrackEvent("Disease Listed", new Dictionary<string, string>
                {
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

                Analytics.TrackEvent("Search diseases Error", new Dictionary<string, string>
                {
                    {"Message", e1.Message},
                    {"Exception", e1.StackTrace}
                });

            }
        }

    }
}
