using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using easyMedicine.Models;

namespace easyMedicine.Services
{
	public interface IDrugsDataService
	{
		
		Task<IEnumerable<ClinicalCategory>> GetClinicalCategories ();

		Task<IEnumerable<SubCategory>> GetSubCategories (string categoryId);

		Task<IEnumerable<Drug>> SearchDrug(string searchStr);

		Task<IEnumerable<Drug>> GetDrugsByCategory(string subCategoryId);

		Task<IEnumerable<Drug>> GetFavourites();

		Task<DrugFull> GetDrug(int drugId);
	}
}

