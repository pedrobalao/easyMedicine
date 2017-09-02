using System;
using easyMedicine.Core.Services;
using easyMedicine.Core.Models;
using Xamarin.Forms;

namespace easyMedicine.ViewModels
{
    class RootPageModel : PageModelBase
    {
        private readonly INavigatorService _navigatorService;


        public RootPageModel(
            INavigatorService navigator)
        {
            _navigatorService = navigator;

        }

        public override void LoadChildPages()
        {
            var favsModel = _navigatorService.PushTab<FavouritesPageModel>("Favourites");
            _navigatorService.PushTab<SearchPageModel>("Search");
            _navigatorService.PushTab<ExplorePageModel>("Explore");





        }
    }
}
