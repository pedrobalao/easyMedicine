using System;
using SQLite.Net;
using SQLite.Net.Async;
using easyMedicine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Nito.AsyncEx;
using easyMedicine.Helpers;

namespace easyMedicine.Services
{



    public class DrugsDataService : IDrugsDataService
    {



        //private static readonly AsyncLock Mutex = new AsyncLock ();

        SQLiteAsyncConnection database;


        ISQLite _sqlLiteService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public DrugsDataService(
            ISQLite sqlLiteService
        )
        {
            _sqlLiteService = sqlLiteService;
            database = _sqlLiteService.GetConnection();


        }

        public List<Via> Vias
        {
            get;
            private set;
        }


        public async Task<IEnumerable<Via>> GetVias()
        {
            if (Vias != null && Vias.Count > 0)
                return Vias;

            Vias = new List<Via>();
            //using (await Mutex.LockAsync ().ConfigureAwait (false)) {
            Vias = await database.Table<Via>().OrderBy(x => x.Id).ToListAsync().ConfigureAwait(false);
            //}
            return Vias;
        }

        public List<Unity> Unities
        {
            get;
            private set;
        }
        public async Task<IEnumerable<Unity>> GetUnities()
        {
            if (Unities != null && Unities.Count > 0)
                return Unities;

            Unities = new List<Unity>();
            //using (await Mutex.LockAsync ().ConfigureAwait (false)) {
            Unities = await database.Table<Unity>().OrderBy(x => x.Id).ToListAsync().ConfigureAwait(false);
            //}
            return Unities;
        }

        /*
		public async Task CreateDatabaseAsync ()
		{
			// create the tables
			using (await Mutex.LockAsync ().ConfigureAwait (false)) {
				database.CreateTableAsync<ClinicalCategory> ();
				database.CreateTableAsync<SubCategory> ();
				database.CreateTableAsync<Drug> ();
				database.CreateTableAsync<SubCategory> ();
				database.CreateTableAsync<Favourite> ();
			}
		}*/

        public async Task<IEnumerable<ClinicalCategory>> GetClinicalCategories()
        {
            List<ClinicalCategory> categories = new List<ClinicalCategory>();
            //using (await Mutex.LockAsync ().ConfigureAwait (false)) {
            categories = await database.Table<ClinicalCategory>().OrderBy(x => x.Description).ToListAsync().ConfigureAwait(false);
            //}
            return categories;
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories(int categoryId)
        {
            List<SubCategory> subcategories = new List<SubCategory>();
            //using (await Mutex.LockAsync ().ConfigureAwait (false)) {
            subcategories = await database.Table<SubCategory>().Where(x => x.CategoryId == categoryId).OrderBy(x => x.Description).ToListAsync().ConfigureAwait(false);
            //}
            return subcategories;
        }


        private async Task<IEnumerable<Drug>> CompleteDrugsInfo(IEnumerable<Drug> res)
        {
            var ids = res.Select(z => z.Id);

            var drugCategories = await database.Table<DrugCategory>().Where(y => ids.Contains(y.DrugId)).ToListAsync(); ;

            var distinctCats = drugCategories.Select(x => x.SubCategoryId).Distinct().ToList();

            var cats = await database.Table<SubCategory>().Where(z => distinctCats.Contains(z.Id)).ToListAsync();

            foreach (var dc in drugCategories)
            {
                var drug = res.First(x => x.Id == dc.DrugId);
                var cat = cats.First(x => x.Id == dc.SubCategoryId);
                drug.Detail += string.IsNullOrEmpty(drug.Detail) ? cat.Description : ", " + cat.Description;
            }

            return res;
        }

        public async Task<IEnumerable<Drug>> GetDrugsByCategory(int subCategoryId)
        {

            //var res = await database.QueryAsync<Drug>("select * from Drug");


            var res = await database.QueryAsync<Drug>("select a.* from Drug a inner join DrugCategory b on a.Id = b.DrugId " +
                                      "\twhere b.SubCategoryId = ? order by Name", subCategoryId);

            return await CompleteDrugsInfo(res);
        }


        public async Task<IEnumerable<Drug>> SearchDrug(string searchStr)
        {

            //searchStr = searchStr.ToUpper();

            var searchStrLike = "%" + searchStr.ToUpper() + "%";
            //			var drugs = await database.Table<Drug>().Where(x => x.Name.Contains(searchStr) || x.ComercialBrands.Contains(searchStr)).OrderBy(x => x.Name).ToListAsync().ConfigureAwait(false);

            /*
			var drugs = await database.QueryAsync<Drug>("select a.* from Drug a " +
														 "\twhere upper(Name) like ? or ComercialBrands like ? ", searchStrLike);
*/

            //var searchStrLike = "%" + searchStr + "%";
            var drugs2 = await database.QueryAsync<Drug>("select distinct a.* from Drug a inner join Indication b on a.Id = b.DrugId " +
                                                         "\twhere upper(Name) like ? or ComercialBrands like ? or upper(IndicationText) like ?", searchStrLike, searchStrLike, searchStrLike);

            /*
			var ids = drugs.Select(y => y.Id);
			drugs2.RemoveAll(x => ids.Contains(x.Id));

			drugs.AddRange(drugs2);
*/
            return await CompleteDrugsInfo(drugs2);
            //return drugs;
        }


        public async Task<IEnumerable<Drug>> GetFavourites()
        {
            var favs = Settings.FavouriteSettings.Select(x => Int32.Parse(x));


            var drugs = await database.Table<Drug>().Where(x => favs.Contains(x.Id)).OrderBy(x => x.Name).ToListAsync().ConfigureAwait(false);

            return await CompleteDrugsInfo(drugs);
            //return drugs;
        }


        public async Task<IEnumerable<Drug>> GetDrugsWithCalc()
        {
            var drugs2 = await database.QueryAsync<Drug>("select distinct a.* from Drug a " +
                                                         "where a.Id in (select DrugId from Calculation) order by a.Name");

            return await CompleteDrugsInfo(drugs2);
        }



        public async Task<List<VariableMedicalCalculationFull>> GetVariableMedicalCalculationFull(int medicalCalculationId)
        {

            var ret = new List<VariableMedicalCalculationFull>();

            var vmcs = await database.Table<VariableMedicalCalculation>().Where(x => x.MedicalCalculationId == medicalCalculationId).ToListAsync();

            var varids = vmcs.Select(x => x.VariableId);

            var valuesVars = await database.Table<VariableValues>().Where(x => varids.Contains(x.VariableId)).ToListAsync();

            var variables = await database.Table<Variable>().Where(x => varids.Contains(x.Id)).ToListAsync();

            foreach (var vmc in vmcs)
            {
                ret.Add(new VariableMedicalCalculationFull()
                {
                    Variable = variables.First(x => x.Id == vmc.VariableId),
                    VariableMedicalCalculation = vmc,
                    Values = valuesVars.Where(y => y.VariableId == vmc.VariableId).Select(x => x.Value).OrderBy(y => y).ToList()
                });
            }

            return ret;

        }


        public async Task<MedicalCalculationFull> GetMedicalCalculation(int medicalCalculationId)
        {

            var ret = new MedicalCalculationFull();

            ret.Calculation = await database.Table<MedicalCalculation>().Where(x => x.Id == medicalCalculationId).FirstAsync();

            ret.Group = await database.Table<MedicalCalculationGroup>().Where(x => x.Id == ret.Calculation.CalculationGroupId).FirstOrDefaultAsync();

            ret.Variables = await GetVariableMedicalCalculationFull(medicalCalculationId);

            return ret;

        }

        public async Task<IEnumerable<MedicalCalculation>> GetMedicalCalculations()
        {
            var mcs = await database.QueryAsync<MedicalCalculation>("select a.* from MedicalCalculation a " +
                                                         "order by a.Description");

            return mcs;
        }




        public async Task<DrugFull> GetDrug(int drugId)
        {


            var ret = new DrugFull();
            var drug = await database.Table<Drug>().Where(x => x.Id == drugId).FirstAsync().ConfigureAwait(false);

            ret.Id = drug.Id;
            ret.Name = drug.Name;
            ret.Obs = drug.Obs;
            ret.Presentation = drug.Presentation;
            ret.SecondaryEfects = drug.SecondaryEfects;
            ret.ComercialBrands = drug.ComercialBrands;
            ret.ConterIndications = drug.ConterIndications;

            var indications = await database.Table<Indication>().Where(x => x.DrugId == drugId).ToListAsync().ConfigureAwait(false);

            ret.Indications = new List<IndicationFull>();
            ret.SubCategories = new List<SubCategory>();

            indications.All((x) =>
            {
                ret.Indications.Add(new IndicationFull()
                {
                    Indication = x,
                    Doses = new List<Dose>()

                });
                return true;
            }
            );

            var indicationsIds = indications.Select(x => x.Id);

            var doses = await database.Table<Dose>().Where(x => indicationsIds.Contains(x.IndicationId)).ToListAsync().ConfigureAwait(false);

            ret.Indications.All(
                (x) =>
                {
                    x.Doses.AddRange(doses.Where(y => y.IndicationId == x.Indication.Id));
                    return true;
                }
            );

            ret.SubCategories = await database.QueryAsync<SubCategory>("select a.* from SubCategory a inner join DrugCategory b on a.Id = b.SubCategoryId " +
                                                                "\twhere b.DrugId = ? order by Description", drugId);



            ret.Variables = await database.QueryAsync<Variable>("select a.* from Variable a inner join VariableDrug b on a.Id = b.VariableId" +
                                                                "\twhere b.DrugId = ? order by a.Description", drugId);


            ret.Calculations = (await database.QueryAsync<Calculation>("select a.* from Calculation a " +
                                                                      "\twhere a.DrugId = ? order by ResultDescription", drugId));


            return ret;
        }


    }
}

