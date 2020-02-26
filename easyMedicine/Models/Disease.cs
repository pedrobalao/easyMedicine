using System;
namespace easyMedicine.Models
{
    public class DiseaseLight
    {
        public int id
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public string indication
        {
            get;
            set;
        }
    }

    public class Disease : DiseaseLight
    {
        public string author
        {
            get;
            set;
        }

        public string followup
        {
            get;
            set;
        }

        public string example
        {
            get;
            set;
        }

        public string bibliography
        {
            get;
            set;
        }

        public string observation
        {
            get;
            set;
        }

        public string treatment_description
        {
            get;
            set;
        }

        public string status
        {
            get;
            set;
        }
    }
}
