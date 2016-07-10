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



namespace easyMedicine
{
	public class Bootstrapper : AutofacBootstrapper
	{
		private readonly App _application;
		public static Bootstrapper Instance;

		public Bootstrapper (App application)
		{

			_application = application;
			Setup ();


			Instance = this;

		}

		protected override void ConfigureContainer (ContainerBuilder builder)
		{
			base.ConfigureContainer (builder);
			builder.RegisterModule<AppModule> ();

		}
		//@ADD VIEW
		protected override void RegisterViews (IViewFactory viewFactory)
		{
			viewFactory.Register<SearchPageModel, SearchPage> ();
			viewFactory.Register<ExplorePageModel, ExplorePage> ();
			viewFactory.Register<SubCategoryExplorePageModel, SubCategoryExplorePage>();
			viewFactory.Register<DrugExplorePageModel, DrugExplorePage>();
			viewFactory.Register<DrugPageModel, DrugPage>();
			viewFactory.Register<FavouritesPageModel, FavouritesPage> ();
			viewFactory.Register<RootPageModel, RootPage> ();


		}


		public void Start ()
		{
			/*/CrossConnectivity.Current.ConnectivityChanged += (sender, args) => {
				CheckConnectivity ();

			};

			if (!CheckConnectivity ())
				return;*/

			/*
			if (Device.OS != TargetPlatform.WinPhone) {
				try {
					AppResources.Culture = new CultureInfo (_container.Resolve<ILocalizeService> ().GetCurrentCultureInfo ());
				} catch {
					AppResources.Culture = new CultureInfo ("en-US");
				}
			}
			*/

			//bool authenticated = _container.Resolve<IAuthenticationService> ().IsAuthenticated ();

			_container.Resolve<INavigatorService> ().Start<RootPageModel> ("Root", _application);

		}


	}
}
