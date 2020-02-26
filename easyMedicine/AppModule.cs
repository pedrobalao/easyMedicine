using System;
using Autofac;
using easyMedicine.ViewModels;
using easyMedicine.Pages;

namespace easyMedicine
{
    public class AppModule : Module
    {
        //@ADD VIEW
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<SearchPageModel>()
                .SingleInstance();
            builder.RegisterType<SearchPage>()
                .SingleInstance();
            builder.RegisterType<ExplorePageModel>()
                .SingleInstance();
            builder.RegisterType<ExplorePage>()
                .SingleInstance();

            builder.RegisterType<SubCategoryExplorePageModel>()
                .SingleInstance();
            builder.RegisterType<SubCategoryExplorePage>()
                .SingleInstance();

            builder.RegisterType<DrugExplorePageModel>()
                .SingleInstance();
            builder.RegisterType<DrugExplorePage>()
                .SingleInstance();

            builder.RegisterType<DrugPageModel>()
                .SingleInstance();
            builder.RegisterType<DrugPage>()
                .SingleInstance();

            builder.RegisterType<ReportErrorPageModel>()
                .SingleInstance();
            builder.RegisterType<ReportErrorPage>()
                .SingleInstance();


            builder.RegisterType<FavouritesPageModel>()
                .SingleInstance();
            builder.RegisterType<FavouritesPage>()
                .SingleInstance();

            builder.RegisterType<RootPageModel>()
                .SingleInstance();
            builder.RegisterType<RootPage>()
                .SingleInstance();

            builder.RegisterType<AboutPageModel>()
                .SingleInstance();
            builder.RegisterType<AboutPage>()
                .SingleInstance();

            builder.RegisterType<CalculatorListPageModel>()
                .SingleInstance();
            builder.RegisterType<CalculatorListPage>()
               .SingleInstance();

            builder.RegisterType<MedicalCalculationListPageModel>()
                .SingleInstance();
            builder.RegisterType<MedicalCalculationListPage>()
               .SingleInstance();

            builder.RegisterType<MedicalCalculationPageModel>()
                .SingleInstance();
            builder.RegisterType<MedicalCalculationPage>()
               .SingleInstance();

            builder.RegisterType<MenuMorePageModel>()
                .SingleInstance();
            builder.RegisterType<MenuMorePage>()
               .SingleInstance();

            builder.RegisterType<SurgeriesReferralPageModel>()
                .SingleInstance();
            builder.RegisterType<SurgeriesReferralPage>()
               .SingleInstance();

            builder.RegisterType<SurgeryReferralPageModel>()
                .SingleInstance();
            builder.RegisterType<SurgeryReferralPage>()
               .SingleInstance();
            builder.RegisterType<PercentilesPageModel>()
               .SingleInstance();
            builder.RegisterType<PercentilesPage>()
               .SingleInstance();

            builder.RegisterType<LoginPageModel>()
               .SingleInstance();
            builder.RegisterType<LoginPage>()
               .SingleInstance();


            builder.RegisterType<AuthenticatorPageModel>()
               .SingleInstance();
            builder.RegisterType<AuthenticatorPage>()
               .SingleInstance();

            builder.RegisterType<ProfilePageModel>()
               .SingleInstance();
            builder.RegisterType<ProfilePage>()
               .SingleInstance();

            builder.RegisterType<DiseasesListPageModel>()
               .SingleInstance();
            builder.RegisterType<DiseasesListPage>()
               .SingleInstance();
            builder.RegisterType<DiseasePageModel>()
               .SingleInstance();
            builder.RegisterType<DiseasePage>()
               .SingleInstance();

            builder.RegisterType<CollectUserInfoPageModel>()
               .SingleInstance();
            builder.RegisterType<CollectUserInfoPage>()
               .SingleInstance();





        }
    }
}

