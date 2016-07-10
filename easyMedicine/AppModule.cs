using System;
using Autofac;
using easyMedicine.ViewModels;
using easyMedicine.Pages;

namespace easyMedicine
{
	public class AppModule : Module
	{
		//@ADD VIEW
		protected override void Load (ContainerBuilder builder)
		{
			
			builder.RegisterType<SearchPageModel> ()
				.SingleInstance ();
			builder.RegisterType<SearchPage> ()
				.SingleInstance ();
			builder.RegisterType<ExplorePageModel> ()
				.SingleInstance ();
			builder.RegisterType<ExplorePage> ()
				.SingleInstance ();

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



			builder.RegisterType<FavouritesPageModel> ()
				.SingleInstance ();
			builder.RegisterType<FavouritesPage> ()
				.SingleInstance ();

			builder.RegisterType<RootPageModel> ()
				.SingleInstance ();
			builder.RegisterType<RootPage> ()
				.SingleInstance ();



			
		}
	}
}

