using System;
using SQLite.Net.Attributes;

namespace easyMedicine.Models
{
	public class Category
	{
		[PrimaryKey]
		public string Id {
			get;
			set;
		}

		public string Description{ get; set; }
	}

	[Table ("ClinicalCategory")]
	public class ClinicalCategory : Category
	{
		
	}

	[Table ("SubCategory")]
	public class SubCategory : Category
	{
		[Indexed]
		public string CategoryId {
			get;
			set;
		}
	}

	/*
	[Table("DrugCategory")]
	public class DrugCategory
	{
		[PrimaryKey]
		public int Id { get; set; }

		[Indexed("DrugCatIdx", 1)]
		public string DrugId
		{
			get;
			set;
		}

		[Indexed("catsubx", 1)]
		public string CategoryId
		{
			get;
			set;
		}
		[Indexed("catsubx", 2)]
		public string SubCategoryId
		{
			get;
			set;
		}
	}*/


	[Table ("Drug")]
	public class Drug
	{

		[PrimaryKey]
		public int Id { get; set; }

		[Indexed ("CatIdx", 1)]
		public string ClinicalCategoryId {
			get;
			set;
		}

		[Indexed ("CatIdx", 2)]
		public string SubCategoryId {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}



		public string Indication{ get; set; }

		public string Via{ get; set; }

		public string ConterIndications { get; set; }

		public string Observations { get; set; }

		public string SecondaryEffects { get; set; }

		[Indexed]
		public string SearchString { get; set; }

		/*public decimal PediatricDoseValue{ get; set; }

		public string PediatricDoseUnit{ get; set; }

		public decimal AdultDoseValue{ get; set; }

		public string AdultDoseUnit{ get; set; }

		public decimal MaxDailyDoseValue{ get; set; }

		public string MaxDailyDoseUnit{ get; set; }

		public string Takes { get; set; }

		public string Presentation { get; set; }

		public string CommercialBrand { get; set; }*/

		

	}

	[Table ("Favourite")]
	public class Favourite
	{
		[PrimaryKey]
		public string DrugID { get; set; }
	}


}

