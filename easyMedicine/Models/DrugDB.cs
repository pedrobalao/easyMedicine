using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace easyMedicine.Models
{
    public class Category
    {
        [PrimaryKey]
        public int Id
        {
            get;
            set;
        }

        public string Description { get; set; }
    }

    [Table("ClinicalCategory")]
    public class ClinicalCategory : Category
    {

    }

    [Table("SubCategory")]
    public class SubCategory : Category
    {
        [Indexed]
        public int CategoryId
        {
            get;
            set;
        }
    }

    [Table("Drug")]
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
    [Table("Dose")]
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
    [Table("DrugCategory")]
    public class DrugCategory
    {
        [PrimaryKey]
        public int DrugId { get; set; }
        [PrimaryKey]
        public int SubCategoryId { get; set; }

    }
    [Table("Indication")]
    public class Indication
    {
        [PrimaryKey]
        public int Id { get; set; }

        public int DrugId { get; set; }
        public string IndicationText { get; set; }

    }


    [Table("Unity")]
    public class Unity
    {
        [PrimaryKey]
        public string Id { get; set; }
    }
    [Table("Via")]
    public class Via
    {
        [PrimaryKey]
        public string Id { get; set; }
    }

    [Table("Variable")]
    public class Variable
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Description { get; set; }

        public string IdUnit { get; set; }

        public string Type { get; set; }

    }

    [Table("VariableValues")]
    public class VariableValues
    {
        [PrimaryKey]
        public Int64 Id { get; set; }

        public string VariableId { get; set; }

        public string Value { get; set; }

    }


    [Table("VariableDrug")]
    public class VariableDrug
    {
        [PrimaryKey]
        public string Id { get; set; }

        public int DrugId { get; set; }

        public string VariableId { get; set; }

        public string Type { get; set; }

    }

    [Table("Calculation")]
    public class Calculation
    {
        [PrimaryKey]
        public string Id { get; set; }

        public int DrugId { get; set; }

        public string Type { get; set; }

        public string Function { get; set; }

        public string ResultDescription { get; set; }

        public string ResultIdUnit { get; set; }

        public string Description { get; set; }

    }


    [Table("MedicalCalculation")]
    public class MedicalCalculation
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Description { get; set; }

        public string Formula { get; set; }

        public string ResultUnitId { get; set; }

        public string Observation { get; set; }

        public int CalculationGroupId { get; set; }

    }

    [Table("MedicalCalculationGroup")]
    public class MedicalCalculationGroup
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Description { get; set; }
    }

    [Table("VariableMedicalCalculation")]
    public class VariableMedicalCalculation
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string VariableId { get; set; }
        public int MedicalCalculationId { get; set; }
        public int Optional { get; set; }
    }

    public class MedicalCalculationFull
    {
        public MedicalCalculation Calculation { get; set; }
        public MedicalCalculationGroup Group { get; set; }
        public List<VariableMedicalCalculationFull> Variables { get; set; }

    }

    public class VariableMedicalCalculationFull
    {
        public VariableMedicalCalculation VariableMedicalCalculation { get; set; }
        public Variable Variable
        {
            get;
            set;
        }
        public List<string> Values
        {
            get;
            set;
        }
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

    public class DrugFull : Drug
    {

        public List<SubCategory> SubCategories
        {
            get;
            set;
        }

        public List<IndicationFull> Indications
        {
            get; set;
        }

        public List<Variable> Variables
        {
            get;
            set;
        }

        public List<Calculation> Calculations
        {
            get;
            set;
        }
    }




}

