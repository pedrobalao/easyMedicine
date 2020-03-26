using System;
using easyMedicine.Core.Services;
using easyMedicine.Core.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using easyMedicine.Services;
using System.Diagnostics;
using easyMedicine.Helpers;
using Microsoft.AppCenter.Analytics;
using System.Collections.Generic;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace easyMedicine.ViewModels
{

    public class NewMenuItem
    {
        public string Id
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string Icon
        {
            get;
            set;
        }

        public string Group
        {
            get;
            set;
        }

        public Color Color
        {
            get;
            set;
        }


    }
    public class NewRootPageModel : PageModelBase
    {
        private readonly INavigatorService _navigatorService;

        private readonly IDatabaseService _databaseService;

        public bool CollectUserInfo
        {
            get;
            set;
        }

        private Command _LoadPageCommand;

        public Command LoadPageCommand
        {
            get
            {
                return _LoadPageCommand;
            }
            set
            {
                _LoadPageCommand = value;
                OnPropertyChanged(LoadPageCommandPropertyName);
            }
        }

        public const string LoadPageCommandPropertyName = "LoadPageCommand";



        public async Task LoadPage(string id)
        {
            if (id == "Favourites")
            {
                await _navigatorService.PushAsync<FavouritesPageModel>(id);
            }
            else if (id == "Search")
            {
                await _navigatorService.PushAsync<SearchPageModel>(id);
            }
            else if (id == "Explore")
            {
                await _navigatorService.PushAsync<ExplorePageModel>(id);
            }
            else if (id == "Calculator")
            {
                await _navigatorService.PushAsync<CalculatorListPageModel>(id);
            }
            else if (id == "Percentiles")
            {
                await _navigatorService.PushAsync<PercentilesPageModel>(id);
            }
            else if (id == "Percentiles")
            {
                await _navigatorService.PushAsync<PercentilesPageModel>(id);
            }
            else if (id == "About")
            {
                await _navigatorService.PushAsync<AboutPageModel>(id);
            }
            else if (id == "Calculations")
            {
                await _navigatorService.PushAsync<MedicalCalculationListPageModel>(id);
            }
            else if (id == "Surgeries")
            {
                await _navigatorService.PushAsync<SurgeriesReferralPageModel>(id);
            }
            else if (id == "Profile")
            {
                await _navigatorService.PushAsync<ProfilePageModel>(id);
            }
            else if (id == "Diseases")
            {
                await _navigatorService.PushAsync<DiseasesListPageModel>(id);
            }
            else
            {
                throw new Exception("Invalid Menu Option");
            }

        }

        public NewRootPageModel(
            INavigatorService navigator, IDatabaseService databaseService)
        {
            _navigatorService = navigator;
            _databaseService = databaseService;


            LoadPageCommand = new Command<string>(async (id) =>
            {
                await LoadPage(id);
            });

            Task.Factory.StartNew(async () => await InitializeAsync());
            // Task.Run(new Action(async () => await InitializeAsync()));
        }

        public override async Task LoadChildPages()
        {
            if (AuthenticationService.IsUserAuthenticated && CollectUserInfo)
            {
                await _navigatorService.PushModalAsync<CollectUserInfoPageModel>("CollectUserInfo");
            }
        }

        private async Task InitializeAsync()
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var newVersion = await _databaseService.GetLatesDB();
                    if (newVersion > -1)
                    {
                        Analytics.TrackEvent("Database Updated", new Dictionary<string, string> {
                        { "New Version", newVersion.ToString() }});

                        MessagingCenter.Send<NewRootPageModel, string>(this, "Alert", "A base de dados da sua easyPed foi atualizada.");
                    }
                }
            }
            catch (Exception e1)
            {
                Analytics.TrackEvent("Error Updating Database", new Dictionary<string, string> {
                    { "", e1.Message.ToString() + ":" + e1.InnerException != null ? e1.InnerException.Message : ""}
                });
                Debug.WriteLine("Não foi possível actualizar a bd. " + e1.Message);
            }
        }
    }
}
