using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using Xamarin.Forms;

namespace easyMedicine.ViewModels
{
    public class ReportErrorPageModel : PageModelBase
    {

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;

        public ReportErrorPageModel(INavigatorService navigator, IDrugsDataService drugServ)
        {
            _navigator = navigator;
            _drugsDataServ = drugServ;
            CommandReport = new Command(async () => await ReportErrorPressed());
        }

        public async Task ReportErrorPressed()
        {
            if (String.IsNullOrWhiteSpace(this.Email) || String.IsNullOrWhiteSpace(this.Name) || String.IsNullOrWhiteSpace(this.Text))
            {
                await Page.DisplayAlert("Reporte de erro", "Por favor preencha todos os campos.", "OK");
                return;
            }

            if (!Regex.IsMatch(this.Email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                await Page.DisplayAlert("Reporte de erro", "Por favor introduza um email válido.", "OK");
                return;
            }

            //insert
            await Page.DisplayAlert("Reporte de erro", "Obrigado pela contribuição.", "Fechar");
            await _navigator.PopAsync();
        }

        public Page Page
        {
            get;
            set;
        }

        private Drug _Drug;

        public Drug Drug
        {
            get
            {
                return _Drug;
            }
            set
            {
                _Drug = value;
                OnPropertyChanged(DrugPropertyName);
            }
        }

        public const string DrugPropertyName = "Drug";
        private string _Text;

        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
                OnPropertyChanged(TextPropertyName);
            }
        }

        public const string TextPropertyName = "Text";

        private string _Email;

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged(EmailPropertyName);
            }
        }

        public const string EmailPropertyName = "Email";


        private string _Name;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged(NamePropertyName);
            }
        }

        public const string NamePropertyName = "Name";

        private ICommand _CommandReport;

        public ICommand CommandReport
        {
            get
            {
                return _CommandReport;
            }
            set
            {
                _CommandReport = value;
                OnPropertyChanged(CommandReportPropertyName);
            }
        }

        public const string CommandReportPropertyName = "CommandReport";
    }
}
