using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using Jint;
using Microsoft.Azure.Mobile.Analytics;
using Xamarin.Forms;

namespace easyMedicine.ViewModels
{



    public class MedicalCalculationPageModel : PageModelBase
    {

        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;

        public MedicalCalculationPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {

            _DataLoaded = false;
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;
            Variables = new ObservableCollection<VariableViewModel>();

            ChangedVariablesValueCommand = new Command(Calculate);

        }
        bool _DataLoaded;
        bool _isLoadRunning;
        public async Task Load()
        {
            _isLoadRunning = true;
            _DataLoaded = false;
            Variables.Clear();
            MedicalCalculationFull = await _drugsDataServ.GetMedicalCalculation(MedicalCalculationId);

            foreach (var varmc in MedicalCalculationFull.Variables)
            {
                Variables.Add(new VariableViewModel(varmc.Variable, ChangedVariablesValueCommand, varmc.Values, varmc.VariableMedicalCalculation.Optional != 0 ? true : false));
            }

            OnPropertyChanged(ResultUnitIdPropertyName);

            _DataLoaded = true;
            _isLoadRunning = false;

            Analytics.TrackEvent("MedicalCalculation Opened", new Dictionary<string, string> {
                { "MedicalCalculationId", MedicalCalculationFull.Calculation.Id.ToString() },
                {"MedicalCalculationName", MedicalCalculationFull.Calculation.Description}
                });
        }

        private ICommand _ChangedVariablesValueCommand;

        public ICommand ChangedVariablesValueCommand
        {
            get
            {
                return _ChangedVariablesValueCommand;
            }
            set
            {
                _ChangedVariablesValueCommand = value;
                OnPropertyChanged(ChangedVariablesValueCommandPropertyName);
            }
        }

        public const string ChangedVariablesValueCommandPropertyName = "ChangedVariablesValueCommand";


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


        private MedicalCalculationFull _MedicalCalculationFull;

        public MedicalCalculationFull MedicalCalculationFull
        {
            get
            {
                return _MedicalCalculationFull;
            }
            set
            {
                _MedicalCalculationFull = value;
                OnPropertyChanged(MedicalCalculationFullPropertyName);


            }
        }

        public const string MedicalCalculationFullPropertyName = "MedicalCalculationFull";


        public string ResultUnitId
        {
            get
            {
                if (MedicalCalculationFull != null && MedicalCalculationFull.Calculation != null)
                    return MedicalCalculationFull.Calculation.ResultUnitId;
                return string.Empty;
            }
            set
            {

            }

        }

        public const string ResultUnitIdPropertyName = "ResultUnitId";


        private int _MedicalCalculationId;

        public int MedicalCalculationId
        {
            get
            {
                return _MedicalCalculationId;
            }
            set
            {
                _MedicalCalculationId = value;
                OnPropertyChanged(MedicalCalculationIdPropertyName);
            }
        }

        public const string MedicalCalculationIdPropertyName = "MedicalCalculationId";



        protected override async System.Threading.Tasks.Task Started()
        {
            await base.Started();


#if __IOS__
            await Load();
#endif
        }

        protected override async Task Activated()
        {
            await base.Activated();
            if (!_isLoadRunning)
                await Load();
        }


        private string _Result;

        public string Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
                OnPropertyChanged(ResultPropertyName);
            }
        }

        public const string ResultPropertyName = "Result";


        private string GetDefaultResult()
        {
            if (MedicalCalculationFull.Calculation.ResultType == "NUMBER")
                return "0";
            else
                return "";
        }

        private void Calculate()
        {
            if (!_DataLoaded)
            {

                Result = GetDefaultResult();
                return;
            }

            var eng = new Engine();

            Debug.WriteLine("---NEW");
            foreach (var varis in Variables)
            {
                if (((varis.Type == "NUMBER" && varis.Value == null) || (varis.Type != "NUMBER" && string.IsNullOrWhiteSpace(varis.ValueStr)))
                     && !varis.Optional)
                {
                    Result = GetDefaultResult();
                    return;
                }

                if (varis.Type.ToUpper().Equals("NUMBER"))
                    eng.SetValue(varis.Id, varis.Value);
                else
                    eng.SetValue(varis.Id, varis.ValueStr);
                Debug.WriteLine("var - " + varis.Id);
            }
            Debug.WriteLine("function - " + MedicalCalculationFull.Calculation.Formula);


            if (MedicalCalculationFull.Calculation.ResultType == "NUMBER")
            {
                var res = eng.Execute(MedicalCalculationFull.Calculation.Formula).GetCompletionValue().AsNumber();
                if (MedicalCalculationFull.Calculation.Precision.HasValue)
                    res = Math.Round(res, MedicalCalculationFull.Calculation.Precision.Value);
                Result = res.ToString();
            }
            else
            {
                var res = eng.Execute(MedicalCalculationFull.Calculation.Formula).GetCompletionValue().AsString();
                Result = res;
            }

            Debug.WriteLine("---END");



        }




    }
}
