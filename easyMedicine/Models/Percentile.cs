using System;
namespace easyMedicine.Models
{
    public enum Gender
    {
        male,
        female
    }

    public class PercentilesForAge
    {
        public decimal P01 { get; set; }
        public decimal P1 { get; set; }
        public decimal P3 { get; set; }
        public decimal P5 { get; set; }
        public decimal P10 { get; set; }
        public decimal P15 { get; set; }
        public decimal P25 { get; set; }
        public decimal P50 { get; set; }
        public decimal P75 { get; set; }
        public decimal P85 { get; set; }
        public decimal P90 { get; set; }
        public decimal P95 { get; set; }
        public decimal P99 { get; set; }
        public decimal P999 { get; set; }

    }

    public class Percentile
    {
        public decimal percentile
        {
            get;
            set;
        }

        public PercentilesForAge percentilesforage
        {
            get;
            set;
        }
    }
}
