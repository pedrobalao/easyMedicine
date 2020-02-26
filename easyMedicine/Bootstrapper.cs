using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using Xamarin;
using easyMedicine;
using easyMedicine.Core.Bootstrapping;
using easyMedicine.Core.Factory;
using easyMedicine.Core.Services;
using easyMedicine.Pages;
using easyMedicine.ViewModels;
using easyMedicine.Services;

namespace easyMedicine
{
    public class Bootstrapper : AutofacBootstrapper
    {
        private readonly App _application;
        public static Bootstrapper Instance;

        public Bootstrapper(App application)
        {

            _application = application;
            Setup();


            Instance = this;

        }
        public T Resolve<T>()
        {
            return _container.Resolve<T>();

        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<AppModule>();

        }
        //@ADD VIEW
        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<SearchPageModel, SearchPage>();
            viewFactory.Register<ExplorePageModel, ExplorePage>();
            viewFactory.Register<SubCategoryExplorePageModel, SubCategoryExplorePage>();
            viewFactory.Register<DrugExplorePageModel, DrugExplorePage>();
            viewFactory.Register<DrugPageModel, DrugPage>();
            viewFactory.Register<FavouritesPageModel, FavouritesPage>();
            viewFactory.Register<RootPageModel, RootPage>();
            viewFactory.Register<AboutPageModel, AboutPage>();
            viewFactory.Register<ReportErrorPageModel, ReportErrorPage>();
            viewFactory.Register<CalculatorListPageModel, CalculatorListPage>();
            viewFactory.Register<MedicalCalculationListPageModel, MedicalCalculationListPage>();
            viewFactory.Register<MedicalCalculationPageModel, MedicalCalculationPage>();
            viewFactory.Register<MenuMorePageModel, MenuMorePage>();
            viewFactory.Register<SurgeriesReferralPageModel, SurgeriesReferralPage>();
            viewFactory.Register<SurgeryReferralPageModel, SurgeryReferralPage>();
            viewFactory.Register<PercentilesPageModel, PercentilesPage>();
            viewFactory.Register<LoginPageModel, LoginPage>();
            viewFactory.Register<AuthenticatorPageModel, AuthenticatorPage>();
            viewFactory.Register<ProfilePageModel, ProfilePage>();
            viewFactory.Register<DiseasesListPageModel, DiseasesListPage>();
            viewFactory.Register<DiseasePageModel, DiseasePage>();
            viewFactory.Register<CollectUserInfoPageModel, CollectUserInfoPage>();
        }


        public void Start()
        {

            AuthenticationService.LoadAuth();

            if (AuthenticationService.IsUserAuthenticated)
            {
                _container.Resolve<INavigatorService>().Start<RootPageModel>("Root", _application);
            }
            else
            {
                _container.Resolve<INavigatorService>().Start<LoginPageModel>("Login", _application);
            }



        }


    }
}
