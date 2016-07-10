using System;
using SQLite.Net;
using SQLite.Net.Async;
using easyMedicine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Nito.AsyncEx;

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
		public DrugsDataService (
			ISQLite sqlLiteService
		)
		{
			_sqlLiteService = sqlLiteService;
			database = _sqlLiteService.GetConnection ();

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

		public async Task<IEnumerable<ClinicalCategory>> GetClinicalCategories ()
		{
			List<ClinicalCategory> categories = new List<ClinicalCategory> ();
			//using (await Mutex.LockAsync ().ConfigureAwait (false)) {
			categories = await database.Table<ClinicalCategory> ().OrderBy (x => x.Description).ToListAsync ().ConfigureAwait (false);
			//}
			return categories;
		}

		public async Task<IEnumerable<SubCategory>> GetSubCategories (string categoryId)
		{
			List<SubCategory> subcategories = new List<SubCategory> ();
			//using (await Mutex.LockAsync ().ConfigureAwait (false)) {
			subcategories = await database.Table<SubCategory> ().Where (x => x.CategoryId == categoryId).OrderBy (x => x.Description).ToListAsync ().ConfigureAwait (false);
			//}
			return subcategories;
		}

		public async Task<IEnumerable<Drug>> GetDrugsByCategory(string categoryId, string subCategoryId)
		{

			//var res = await database.QueryAsync<Drug>("select * from Drug");


			var res = await database.QueryAsync<Drug>("select a.* from Drug a inner join DrugCategory b on a.Id = b.DrugId " +
									  "\twhere b.CategoryId = ? and b.SubCategoryId = ?", categoryId, subCategoryId); 

			return res;
		}


		public async Task<IEnumerable<Drug>> SearchDrug(string searchStr)
		{
			//List<Drug> drugs = new List<Drug>();
			//using (await Mutex.LockAsync ().ConfigureAwait (false)) {
			var drugs = await database.Table<Drug>().Where(x => x.SearchString.Contains(searchStr)).OrderBy(x => x.Name).ToListAsync().ConfigureAwait(false);
			//}
			return drugs;
		}



	}
}

