using System;
using System.Collections.Generic;

namespace easyMedicine.Models
{
    public class SurgeriesReferral
    {
        public List<SurgeryReferral> PediatricSurgeries
        {
            get;
            set;
        }

        public string FooterInfo
        {
            get;
            set;
        }
    }

    public class SurgeryReferral
    {

        public SurgeryReferral()
        {
            Referral = new List<string>();
            Observations = new List<string>();
        }

        public string Scope
        {
            get;
            set;

        }

        public List<string> Referral
        {
            get;
            set;
        }

        public List<string> Observations
        {
            get;
            set;
        }

    }
}
