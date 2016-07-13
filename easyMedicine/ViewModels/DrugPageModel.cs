using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using Xamarin.Forms;

namespace easyMedicine
{
	public class DrugPageModel : PageModelBase
	{

		IDrugsDataService _drugsDataServ;
		INavigatorService _navigator;

		public ICommand ChangeFavouriteStatus { get; private set;}

		public const string ChangeFavouriteStatusPropertyName = "ChangeFavouriteStatus";



		public DrugPageModel(INavigatorService navigator, IDrugsDataService drugServ )
		{
			_drugsDataServ = drugServ;
			_navigator = navigator;

			ChangeFavouriteStatus = new Command(FavouriteStatusChange);
		}


		private Drug _Drug;

		public Drug Drug
		{
			get
			{
				return _Drug;
			}
			set
			{
				_Drug = value;
				OnPropertyChanged(DrugPropertyName);
			}
		}

		public const string DrugPropertyName = "Drug";


		private bool _IsFavourite;

		public bool IsFavourite
		{
			get
			{
				return _IsFavourite;
			}
			set
			{
				_IsFavourite = value;
				OnPropertyChanged(IsFavouritePropertyName);
				OnPropertyChanged(FavouriteIconPropertyName);
			}
		}

		public const string IsFavouritePropertyName = "IsFavourite";

		private string _FavouriteIcon;

		public string FavouriteIcon
		{
			get
			{
				if (IsFavourite)
					return "ic_favorite_36pt.png";
				return "ic_favorite_border_36pt.png"; 
			}
		}

		public const string FavouriteIconPropertyName = "FavouriteIcon";


		void FavouriteStatusChange()
		{
			if (IsFavourite)
			{
				Settings.RemoveFavourite(Drug.Id.ToString());
			}
			else
			{
				Settings.AddFavourite(Drug.Id.ToString());
			}
			IsFavourite = Settings.IsFavourite(Drug.Id.ToString());

		}


		protected override async System.Threading.Tasks.Task Started()
		{
			await base.Started();
			IsFavourite = Settings.IsFavourite(Drug.Id.ToString());

		}
	}
}

