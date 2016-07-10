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
	public class SubCategoryExplorePageModel : PageModelBase
	{

		IDrugsDataService _drugsDataServ;
		INavigatorService _navigator;

		public ICommand SubCategorySelectedCommand { get; private set; }

		private ObservableCollection<SubCategory> _SubClinicalCategories;

		public ObservableCollection<SubCategory> SubClinicalCategories
		{
			get
			{
				return _SubClinicalCategories;
			}
			set
			{
				_SubClinicalCategories = value;
				OnPropertyChanged(SubClinicalCategoriesPropertyName);
			}
		}

		public const string SubClinicalCategoriesPropertyName = "SubClinicalCategories";


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



		private SubCategory _SelectedSubClinicalCategory;

		public SubCategory SelectedSubClinicalCategory
		{
			get
			{
				return _SelectedSubClinicalCategory;
			}
			set
			{
				_SelectedSubClinicalCategory = value;
				OnPropertyChanged(SelectedSubClinicalCategoryPropertyName);
			}
		}

		public const string SelectedSubClinicalCategoryPropertyName = "SelectedSubClinicalCategory";



		public SubCategoryExplorePageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
		{
			_navigator = navigator;
			_drugsDataServ = drugsDataServ;

			SubClinicalCategories = new ObservableCollection<SubCategory>();

			SubCategorySelectedCommand = new Command<SubCategory>(async (cat) => await SubCategorySelected(cat));
		}


		protected override async System.Threading.Tasks.Task Started()
		{
			await base.Started();

			SubClinicalCategories.Clear();


			var data = await _drugsDataServ.GetSubCategories(ClinicalCategoryId);
			foreach (var clicat in data)
			{
				SubClinicalCategories.Add(clicat);
			}


		}


		async Task SubCategorySelected(SubCategory tappedItem)
		{
			Debug.WriteLine("Tapped Cat -> " + tappedItem.Description);

			await _navigator.PushAsync<DrugExplorePageModel>("Drugs", (model) =>
			{
				model.ClinicalCategoryId = tappedItem.CategoryId;
				model.SubCategoryId = tappedItem.Id;
				model.SubCategoryDescription = tappedItem.Description;
				//model.ClinicalCategoryDescription = tappedItem.Description;
			});
		}
	}
}

