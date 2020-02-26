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

namespace easyMedicine.ViewModels
{
    class RootPageModel : PageModelBase
    {
        private readonly INavigatorService _navigatorService;

        private readonly IDatabaseService _databaseService;

        public bool CollectUserInfo
        {
            get;
            set;
        }

        public RootPageModel(
            INavigatorService navigator, IDatabaseService databaseService)
        {
            _navigatorService = navigator;
            _databaseService = databaseService;

            Task.Factory.StartNew(async () => await InitializeAsync());
            // Task.Run(new Action(async () => await InitializeAsync()));

        }

        public override async Task LoadChildPages()
        {

            var favsModel = _navigatorService.PushTab<FavouritesPageModel>("Favourites");
            //_navigatorService.PushTab<LoginPageModel>("Login");
            _navigatorService.PushTab<SearchPageModel>("Search");
            _navigatorService.PushTab<ExplorePageModel>("Explore");
            if (Device.RuntimePlatform == Device.Android)
                _navigatorService.PushTab<CalculatorListPageModel>("Calculator");
            _navigatorService.PushTab<PercentilesPageModel>("Percentiles");
            _navigatorService.PushTab<MenuMorePageModel>("MenuMore");


            if (AuthenticationService.IsUserAuthenticated && CollectUserInfo)
            {
                await _navigatorService.PushModalAsync<CollectUserInfoPageModel>("CollectUserInfo");
            }

            //_navigatorService.PushTab<MedicalCalculationListPageModel>("Calculator");
            //_navigatorService.PushTab<AboutPageModel>("About");
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

                        MessagingCenter.Send<RootPageModel, string>(this, "Alert", "A base de dados da sua easyPed foi atualizada.");
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
