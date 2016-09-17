using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace easyMedicine.Models
{
	public class Category
	{
		[PrimaryKey]
		public int Id {
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
		public int CategoryId {
			get;
			set;
		}
	}

	[Table ("Drug")]
	public class Drug
    {
		

		[PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ConterIndications { get; set; }

        public string SecondaryEfects { get; set; }

        public string ComercialBrands { get; set; }

        public string Obs { get; set; }

        public string Presentation { get; set; }

		[Ignore]
		public string Detail { get; set; }

    }
    [Table ("Dose")]
    public class Dose
    {
		[PrimaryKey]
        public int Id { get; set; }

        public int IndicationId { get; set; }

        public string IdVia { get; set; }

        public string PediatricDose { get; set; }

        public string IdUnityPediatricDose { get; set; }

        public string AdultDose { get; set; }

        public string IdUnityAdultDose { get; set; }

        public string TakesPerDay { get; set; }

        public string MaxDosePerDay { get; set; }

        public string IdUnityMaxDosePerDay { get; set; }

        public string Obs { get; set; }


    }
	[Table ("DrugCategory")]
    public class DrugCategory
    {
		[PrimaryKey]
        public int DrugId { get; set; }
		[PrimaryKey]
        public int SubCategoryId { get; set; }

    }
	[Table ("Indication")]
    public class Indication
    {
		[PrimaryKey]
        public int Id { get; set; }

        public int DrugId { get; set; }
		public string IndicationText { get; set; }

    }

    
[Table ("Unity")]
    public class Unity
    {
		[PrimaryKey]
        public string Id { get; set; }
    }
[Table ("Via")]
    public class Via
    {
		[PrimaryKey]
        public string Id { get; set; }
    }


	public class IndicationFull 
	{
		public Indication Indication
		{
			get;
			set;
		}
		public List<Dose> Doses
		{
			get;
			set;
		}
	}

	public class DrugFull :Drug
	{
		
		public List<SubCategory> SubCategories
		{
			get;
			set;
		}

		public List<IndicationFull> Indications
		{
			get;set;
		}

	}
}

