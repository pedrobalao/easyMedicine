using System;
using easyMedicine.Core.Models;
using easyMedicine.Services;
using System.Collections.ObjectModel;
using easyMedicine.Models;
using easyMedicine.Core.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace easyMedicine.ViewModels
{
    public class AboutPageModel : PageModelBase
    {

        INavigatorService _navigator;


        private string _Credits;

        public string Credits
        {
            get
            {
                return _Credits;
            }
            set
            {
                _Credits = value;
                OnPropertyChanged(CreditsPropertyName);
            }
        }

        public const string CreditsPropertyName = "Credits";



        public AboutPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _navigator = navigator;
            Credits = "Ruben Rocha\nAna Reis Melo\nClaudia Silva\nJoão Sarmento\nMariana Adrião\nMarta Rosário\nSofia Ferreira\nSónia Silva";

        }



        protected override async System.Threading.Tasks.Task Started()
        {
            await base.Started();

        }

    }
}

