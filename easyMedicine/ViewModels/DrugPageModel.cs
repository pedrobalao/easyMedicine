using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Helpers;
using easyMedicine.Models;
using easyMedicine.Services;
using easyMedicine.ViewModels;
using Jint;
using Xamarin.Forms;

namespace easyMedicine
{

    public class IndicationViewModel : ObservableCollection<Dose>
    {
        public string Description
        {
            get;
            set;
        }

    }

    public class VariableViewModel : Variable
    {
        public VariableViewModel() { }
        public VariableViewModel(Variable vari, ICommand command)
        {
            this.Description = vari.Description;
            this.Id = vari.Id;
            this.IdUnit = vari.IdUnit;
            this.ValueChangedCommand = command;
        }
        public decimal Value
        {
            get;
            set;
        }

        public ICommand ValueChangedCommand { get; set; }

    }

    public class CalculationViewModel : Calculation
    {
        public CalculationViewModel() { }

        public CalculationViewModel(Calculation cal)
        {
            this.DrugId = cal.DrugId;
            this.Function = cal.Function;
            this.Id = cal.Id;
            this.ResultIdUnit = cal.ResultIdUnit;
            this.ResultDescription = cal.ResultDescription;
            this.Type = cal.Type;
            this.Description = cal.Description;
        }

        public decimal Result
        {
            get;
            set;
        }

    }

    public class DrugPageModel : PageModelBase
    {

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;

        public ICommand ChangeFavouriteStatus { get; private set; }

        public const string ChangeFavouriteStatusPropertyName = "ChangeFavouriteStatus";


        private ICommand _CalculateDoseCommand;

        public ICommand CalculateDoseCommand
        {
            get
            {
                return _CalculateDoseCommand;
            }
            set
            {
                _CalculateDoseCommand = value;
                OnPropertyChanged(CalculateDoseCommandPropertyName);
            }
        }

        public const string CalculateDoseCommandPropertyName = "CalculateDoseCommand";

        private ICommand _ReportErrorCommand;

        public ICommand ReportErrorCommand
        {
            get
            {
                return _ReportErrorCommand;
            }
            set
            {
                _ReportErrorCommand = value;
                OnPropertyChanged(ReportErrorCommandPropertyName);
            }
        }

        public const string ReportErrorCommandPropertyName = "ReportErrorCommand";

        public DrugPageModel(INavigatorService navigator, IDrugsDataService drugServ)
        {
            _drugsDataServ = drugServ;
            _navigator = navigator;
            Indications = new ObservableCollection<IndicationViewModel>();
            Variables = new ObservableCollection<VariableViewModel>();
            Calculations = new ObservableCollection<CalculationViewModel>();

            ChangeFavouriteStatus = new Command(FavouriteStatusChange);

            CalculateDoseCommand = new Command(CalculateDoses);

            ReportErrorCommand = new Command(async () => await ReportErrorTapped());
        }


        async Task ReportErrorTapped()
        {

            await _navigator.PushAsync<ReportErrorPageModel>("ReportError", (model) =>
            {
                model.Drug = this.Drug;
            });
        }

        private int _DrugId;

        public int DrugId
        {
            get
            {
                return _DrugId;
            }
            set
            {
                _DrugId = value;
                OnPropertyChanged(DrugIdPropertyName);
            }
        }

        public const string DrugIdPropertyName = "DrugId";



        private ObservableCollection<IndicationViewModel> _Indications;

        public ObservableCollection<IndicationViewModel> Indications
        {
            get
            {
                return _Indications;
            }
            set
            {
                _Indications = value;
                OnPropertyChanged(IndicationsPropertyName);
            }
        }

        public const string IndicationsPropertyName = "Indications";




        private DrugFull _Drug;

        public DrugFull Drug
        {
            get
            {
                return _Drug;
            }
            set
            {
                _Drug = value;
                OnPropertyChanged(DrugPropertyName);
                OnPropertyChanged(CanCalculateDosePropertyName);
            }
        }

        public const string DrugPropertyName = "Drug";


        private bool _IsFavourite;

        public bool IsFavourite
        {
            get
            {
                return _IsFavourite;
            }
            set
            {
                _IsFavourite = value;
                OnPropertyChanged(IsFavouritePropertyName);
                OnPropertyChanged(FavouriteIconPropertyName);
            }
        }

        public const string IsFavouritePropertyName = "IsFavourite";


        public string FavouriteIcon
        {
            get
            {
                if (IsFavourite)
                    return "tb_ic_favorite_white_48px.png";
                return "tb_ic_favorite_border_white_48px.png";
            }
        }

        public const string FavouriteIconPropertyName = "FavouriteIcon";

        private ObservableCollection<VariableViewModel> _Variables;

        public ObservableCollection<VariableViewModel> Variables
        {
            get
            {
                return _Variables;
            }
            set
            {
                _Variables = value;
                OnPropertyChanged(VariablesPropertyName);
            }
        }

        public const string VariablesPropertyName = "Variables";

        public bool CanCalculateDose
        {
            get
            {
                if (Drug == null || Drug.Variables == null || Drug.Variables.Count == 0 || Drug.Calculations == null || Drug.Calculations.Count == 0)
                    return false;

                return true;
            }

        }

        public const string CanCalculateDosePropertyName = "CanCalculateDose";

        private ObservableCollection<CalculationViewModel> _Calculations;

        public ObservableCollection<CalculationViewModel> Calculations
        {
            get
            {
                return _Calculations;
            }
            set
            {
                _Calculations = value;
                OnPropertyChanged(CalculationsPropertyName);
            }
        }

        public const string CalculationsPropertyName = "Calculations";


        void FavouriteStatusChange()
        {
            if (IsFavourite)
            {
                Settings.RemoveFavourite(Drug.Id.ToString());
            }
            else
            {
                Settings.AddFavourite(Drug.Id.ToString());
            }
            IsFavourite = Settings.IsFavourite(Drug.Id.ToString());

        }

        private decimal CalculateDose(CalculationViewModel cal)
        {
            var eng = new Engine();

            foreach (var varis in Variables)
            {
                eng.SetValue(varis.Id, varis.Value);
            }

            var res = eng.Execute(cal.Function).GetCompletionValue().AsNumber();

            return (decimal)res;

        }

        void CalculateDoses()
        {
            var calcstemp = new List<CalculationViewModel>();

            for (int i = 0; i < Calculations.Count; i++)
            {
                var caltmp = Calculations[i];

                caltmp.Result = CalculateDose(caltmp);

                calcstemp.Add(caltmp);

            }
            Calculations.Clear();

            foreach (var cal in calcstemp)
            {
                Calculations.Add(cal);
            }
        }


        protected override async System.Threading.Tasks.Task Started()
        {
            await base.Started();
            IsFavourite = Settings.IsFavourite(DrugId.ToString());

            Drug = await _drugsDataServ.GetDrug(DrugId);

            Indications.Clear();
            foreach (var indic in Drug.Indications)
            {
                var idvm = new IndicationViewModel()
                {
                    Description = indic.Indication.IndicationText
                };
                foreach (var dos in indic.Doses)
                {
                    idvm.Add(dos);
                }
                Indications.Add(idvm);
            }

            Variables.Clear();

            foreach (var varia in Drug.Variables)
            {
                Variables.Add(new VariableViewModel(varia, CalculateDoseCommand));
            }

            Calculations.Clear();

            foreach (var cal in Drug.Calculations)
            {
                Calculations.Add(new CalculationViewModel(cal));
            }
        }




    }
}

