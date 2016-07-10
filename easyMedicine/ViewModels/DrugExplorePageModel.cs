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
	public class DrugExplorePageModel : PageModelBase
	{

		public ICommand DrugSelectedCommand { get; private set; }

		IDrugsDataService _drugsDataServ;
		INavigatorService _navigator;

		private ObservableCollection<Drug> _Drugs;

		public ObservableCollection<Drug> Drugs
		{
			get
			{
				return _Drugs;
			}
			set
			{
				_Drugs = value;
				OnPropertyChanged(DrugsPropertyName);
			}
		}

		public const string DrugsPropertyName = "Drugs";


		private string _ClinicalCategoryId;

		public string ClinicalCategoryId
		{
			get
			{
				return _ClinicalCategoryId;
			}
			set
			{
				_ClinicalCategoryId = value;
				OnPropertyChanged(ClinicalCategoryIdPropertyName);
			}
		}

		public const string ClinicalCategoryIdPropertyName = "ClinicalCategoryId";



		private string _ClinicalCategoryDescription;

		public string ClinicalCategoryDescription
		{
			get
			{
				return _ClinicalCategoryDescription;
			}
			set
			{
				_ClinicalCategoryDescription = value;
				OnPropertyChanged(ClinicalCategoryDescriptionPropertyName);
			}
		}

		public const string ClinicalCategoryDescriptionPropertyName = "ClinicalCategoryDescription";

		private string _SubCategoryId;

		public string SubCategoryId
		{
			get
			{
				return _SubCategoryId;
			}
			set
			{
				_SubCategoryId = value;
				OnPropertyChanged(SubCategoryIdPropertyName);
			}
		}

		public const string SubCategoryIdPropertyName = "SubCategoryId";

		private string _SubCategoryDescription;

		public string SubCategoryDescription
		{
			get
			{
				return _SubCategoryDescription;
			}
			set
			{
				_SubCategoryDescription = value;
				OnPropertyChanged(SubCategoryDescriptionPropertyName);
			}
		}

		public const string SubCategoryDescriptionPropertyName = "SubCategoryDescription";



		protected override async System.Threading.Tasks.Task Started()
		{
			await base.Started();

			Drugs.Clear();


			var data = await _drugsDataServ.GetDrugsByCategory(ClinicalCategoryId, SubCategoryId);
			foreach (var clicat in data
			        )
			{
				Drugs.Add(clicat);
			}

		}

		private Drug _SelectedDrug;

		public Drug SelectedDrug
		{
			get
			{
				return _SelectedDrug;
			}
			set
			{
				_SelectedDrug = value;
				OnPropertyChanged(SelectedDrugPropertyName);
			}
		}

		public const string SelectedDrugPropertyName = "SelectedDrug";


		async Task DrugSelected(Drug tappedItem)
		{
			Debug.WriteLine("Tapped Cat -> " + tappedItem.Name);

			await _navigator.PushAsync<DrugPageModel>("Drug", (model) =>
			{
				model.Drug = tappedItem;
			});
		}


		public DrugExplorePageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
		{
			_drugsDataServ = drugsDataServ;
			_navigator = navigator;

			Drugs = new ObservableCollection<Drug>();

			DrugSelectedCommand = new Command<Drug>(async (cat) => await DrugSelected(cat));
		}
	}
}

