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



		public DrugPageModel(INavigatorService navigator, IDrugsDataService drugServ )
		{
			_drugsDataServ = drugServ;
			_navigator = navigator;


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




		protected override async System.Threading.Tasks.Task Started()
		{
			await base.Started();

		}
	}
}

