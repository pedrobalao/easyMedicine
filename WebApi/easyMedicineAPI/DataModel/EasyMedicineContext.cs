
using Microsoft.EntityFrameworkCore;

namespace easyMedicineAPI.DataModel
{

    public class EasyMedicineContext : DbContext
    {
		
        public DbSet<Drug> Drug { get; set; }

		public DbSet<DBVersion> DBVersion { get; set; }
		

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:xjx88a6lt5.database.windows.net,1433;Initial Catalog=smartwalletservice_db;Persist Security Info=False;User ID=smartwallet@xjx88a6lt5;Password=walletsmart!1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("smartwalletservice");
        }

/*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //quick and dirty takes care of my entities not all scenarios
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entity.Name).ToTable(entity.ClrType.Name + "s");
            }
        }*/
    }
    public class Drug
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ConterIndications { get; set; }

        public string SecondaryEfects { get; set; }

        public string ComercialBrands { get; set; }

        public string Obs { get; set; }

        public string Presentation { get; set; }

    }
    public class ClinicalCategory
    {
        public int id { get; set; }

        public string Description { get; set; }

    }
    public class Dose
    {
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
    public class DrugCategory
    {
        public int DrugId { get; set; }

        public int SubCategoryId { get; set; }

    }
    public class Indication
    {
        public int Id { get; set; }

        public int DrugId { get; set; }
		public string IndicationText { get; set; }

    }

    public class SubCategory
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

    }

    public class Unity
    {
        public string Id { get; set; }
    }

    public class Via
    {
        public string Id { get; set; }
    }

	public class DBVersion
	{
		[System.ComponentModel.DataAnnotations.Key]
        public int AppVersion { get; set; }
		public int DataVersion { get; set; }
	}

}