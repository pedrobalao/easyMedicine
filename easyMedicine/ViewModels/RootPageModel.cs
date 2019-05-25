using System;
using easyMedicine.Core.Services;
using easyMedicine.Core.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using easyMedicine.Services;
using System.Diagnostics;
using easyMedicine.Helpers;

namespace easyMedicine.ViewModels
{
    class RootPageModel : PageModelBase
    {
        private readonly INavigatorService _navigatorService;



        public RootPageModel(
            INavigatorService navigator)
        {
            _navigatorService = navigator;
            Task.Run(new Action(async () => await InitializeAsync()));

        }

        public override void LoadChildPages()
        {
            var favsModel = _navigatorService.PushTab<FavouritesPageModel>("Favourites");
            _navigatorService.PushTab<SearchPageModel>("Search");
            _navigatorService.PushTab<ExplorePageModel>("Explore");
            if (Device.RuntimePlatform == Device.Android)
                _navigatorService.PushTab<CalculatorListPageModel>("Calculator");
            _navigatorService.PushTab<PercentilesPageModel>("Percentiles");
            _navigatorService.PushTab<MenuMorePageModel>("MenuMore");

            //_navigatorService.PushTab<MedicalCalculationListPageModel>("Calculator");
            //_navigatorService.PushTab<AboutPageModel>("About");
        }

        private async Task InitializeAsync()
        {
            try
            {
                DatabaseService dbServ = new DatabaseService();

                await dbServ.GetLatesDB(16);

            }
            catch (Exception e1)
            {
                Debug.WriteLine("Não foi possível actualizar a bd. " + e1.Message);
            }
        }
    }
}
