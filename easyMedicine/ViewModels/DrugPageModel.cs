using System;
using System.Collections.ObjectModel;
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

	public class IndicationViewModel : ObservableCollection<Dose>
	{
		public string Description
		{
			get;
			set;
		}

	}

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
			Indications = new ObservableCollection<IndicationViewModel>();

			ChangeFavouriteStatus = new Command(FavouriteStatusChange);
		}


		private int _DrugId;

		public int DrugId
		{
			get
			{
				return _DrugId;
			}
			set
			{
				_DrugId = value;
				OnPropertyChanged(DrugIdPropertyName);
			}
		}

		public const string DrugIdPropertyName = "DrugId";



		private ObservableCollection<IndicationViewModel> _Indications;

		public ObservableCollection<IndicationViewModel> Indications
		{
			get
			{
				return _Indications;
			}
			set
			{
				_Indications = value;
				OnPropertyChanged(IndicationsPropertyName);
			}
		}

		public const string IndicationsPropertyName = "Indications";




		private DrugFull _Drug;

		public DrugFull Drug
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


		public string FavouriteIcon
		{
			get
			{
				if (IsFavourite)
					return "tb_ic_favorite_white_48px.png";
				return "tb_ic_favorite_border_white_48px.png"; 
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
			IsFavourite = Settings.IsFavourite(DrugId.ToString());

			Drug = await _drugsDataServ.GetDrug(DrugId);

			Indications.Clear();
			foreach (var indic in Drug.Indications)
			{
				var idvm = new IndicationViewModel()
				{
					Description = indic.Indication.IndicationText
				};
				foreach (var dos in indic.Doses)
				{
					idvm.Add(dos);
				}
				Indications.Add(idvm);
			}

		}


	}
}

