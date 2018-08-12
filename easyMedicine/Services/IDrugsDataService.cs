using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using easyMedicine.Models;

namespace easyMedicine.Services
{
    public interface IDrugsDataService
    {

        Task<IEnumerable<ClinicalCategory>> GetClinicalCategories();

        Task<IEnumerable<SubCategory>> GetSubCategories(int categoryId);

        Task<IEnumerable<Drug>> SearchDrug(string searchStr);

        Task<IEnumerable<Drug>> GetDrugsByCategory(int subCategoryId);

        Task<IEnumerable<Drug>> GetFavourites();

        Task<DrugFull> GetDrug(int drugId);

        Task<IEnumerable<Drug>> GetDrugsWithCalc();

        Task<IEnumerable<MedicalCalculation>> GetMedicalCalculations();

        Task<MedicalCalculationFull> GetMedicalCalculation(int medicalCalculationId);

        Task<MedicalInfo> GetMedicalInfos(string Id);
    }
}

