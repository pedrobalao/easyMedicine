using System;
using easyMedicine.Core.Models;
using easyMedicine.Services;
using System.Collections.ObjectModel;
using easyMedicine.Models;
using easyMedicine.Core.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace easyMedicine.ViewModels
{
	public class ExplorePageModel : PageModelBase
	{
		IDrugsDataService _drugsDataServ;
		INavigatorService _navigator;

		public ICommand CategorySelectedCommand { get; private set; }

		private ObservableCollection<ClinicalCategory> _ClinicalCategories;

		public ObservableCollection<ClinicalCategory> ClinicalCategories {
			get {
				return _ClinicalCategories;
			}
			set {
				_ClinicalCategories = value;
				OnPropertyChanged (ClinicalCategoriesPropertyName);
			}
		}

		public const string ClinicalCategoriesPropertyName = "ClinicalCategories";


		private ClinicalCategory _SelectedClinicalCategory;

		public ClinicalCategory SelectedClinicalCategory
		{
			get
			{
				return _SelectedClinicalCategory;
			}
			set
			{
				_SelectedClinicalCategory = value;
				OnPropertyChanged(SelectedClinicalCategoryPropertyName);
			}
		}

		public const string SelectedClinicalCategoryPropertyName = "SelectedClinicalCategory";





		public ExplorePageModel (INavigatorService navigator, IDrugsDataService drugsDataServ)
		{
			_navigator = navigator;
			_drugsDataServ = drugsDataServ;

			ClinicalCategories = new ObservableCollection<ClinicalCategory> ();

			CategorySelectedCommand = new Command<ClinicalCategory>(async (cat) => await CategorySelected(cat));
		}



		protected override async System.Threading.Tasks.Task Started ()
		{
			await base.Started ();

			ClinicalCategories.Clear ();


			var data = await _drugsDataServ.GetClinicalCategories ();
			foreach (var clicat in data) {
				ClinicalCategories.Add (clicat);
			}
		}


		async Task CategorySelected(ClinicalCategory tappedItem) 
		{
			Debug.WriteLine("Tapped Cat -> " + tappedItem.Description);

			await _navigator.PushAsync<SubCategoryExplorePageModel>("SubCategory", (model) =>
			{
				model.ClinicalCategoryId = tappedItem.Id;
				model.ClinicalCategoryDescription = tappedItem.Description;
			});
		}
	}
}

