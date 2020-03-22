using System;
using System.Collections.Generic;

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

    public class Condition
    {
        public long id
        {
            get;
            set;
        }
        public string condition
        {
            get;
            set;
        }

        public string firstline
        {
            get;
            set;
        }
        public string secondline
        {
            get;
            set;
        }
        public string thirdline
        {
            get;
            set;
        }
    }
    public class Treatment
    {
        public List<Condition> conditions
        {
            get;
            set;
        }

        public string initial_evaluation
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

        public Treatment treatment
        {
            get;
            set;
        }
        public string general_measures
        {
            get;
            set;
        }
    }
}
