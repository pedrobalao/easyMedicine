using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Models;
using easyMedicine.Services;
using System.Linq;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Globalization;
using Microsoft.AppCenter.Analytics;

namespace easyMedicine.ViewModels
{
    public class PercentilesPageModel : PageModelBase
    {

        public ICommand DrugSelectedCommand { get; private set; }

        private ICommand _CalculateCommand;

        public ICommand CalculateCommand
        {
            get
            {
                return _CalculateCommand;
            }
            set
            {
                _CalculateCommand = value;
                OnPropertyChanged(CalculateCommandPropertyName);
            }
        }

        public const string CalculateCommandPropertyName = "CalculateCommand";



        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;

        private string _Height;

        public string Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
                OnPropertyChanged(HeightPropertyName);
            }
        }

        public const string HeightPropertyName = "Height";


        private string _Weight;

        public string Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                _Weight = value;
                OnPropertyChanged(WeightPropertyName);
            }
        }

        public const string WeightPropertyName = "Weight";

        private DateTime _Birthdate;

        public DateTime Birthdate
        {
            get
            {
                return _Birthdate;
            }
            set
            {
                _Birthdate = value;
                OnPropertyChanged(BirthdatePropertyName);
            }
        }

        public const string BirthdatePropertyName = "Birthdate";


        private DateTime _MaxDate;

        public DateTime MaxDate
        {
            get
            {
                return _MaxDate;
            }
            set
            {
                _MaxDate = value;
                OnPropertyChanged(MaxDatePropertyName);
            }
        }

        public const string MaxDatePropertyName = "MaxDate";

        private DateTime _MinDate;

        public DateTime MinDate
        {
            get
            {
                return _MinDate;
            }
            set
            {
                _MinDate = value;
                OnPropertyChanged(MinDatePropertyName);
            }
        }

        public const string MinDatePropertyName = "MinDate";

        private string _HeightUnit;

        public string HeightUnit
        {
            get
            {
                return _HeightUnit;
            }
            set
            {
                _HeightUnit = value;
                OnPropertyChanged(HeightUnitPropertyName);
            }
        }

        public const string HeightUnitPropertyName = "HeightUnit";

        private string _WeightUnit;

        public string WeightUnit
        {
            get
            {
                return _WeightUnit;
            }
            set
            {
                _WeightUnit = value;
                OnPropertyChanged(WeightUnitPropertyName);
            }
        }

        public const string WeightUnitPropertyName = "WeightUnit";

        private ObservableCollection<string> _Genders;

        public ObservableCollection<string> Genders
        {
            get
            {
                return _Genders;
            }
            set
            {
                _Genders = value;
                OnPropertyChanged(GendersPropertyName);
            }
        }

        public const string GendersPropertyName = "Genders";


        private string _SelectedGender;

        public string SelectedGender
        {
            get
            {
                return _SelectedGender;
            }
            set
            {
                _SelectedGender = value;

                SelectedGenderValue = (_SelectedGender.Equals("Feminino") ? Gender.female : Gender.male);
                OnPropertyChanged(SelectedGenderPropertyName);
            }
        }

        public const string SelectedGenderPropertyName = "SelectedGender";


        private Gender SelectedGenderValue = Gender.female;

        private decimal? _HeightPercentile;

        public decimal? HeightPercentile
        {
            get
            {
                return _HeightPercentile;
            }
            set
            {
                _HeightPercentile = value;
                OnPropertyChanged(HeightPercentilePropertyName);
                OnPropertyChanged(HasHeightPercentilePropertyName);
            }
        }

        public const string HeightPercentilePropertyName = "HeightPercentile";

        public bool HasHeightPercentile
        {
            get
            {
                return HeightPercentile.HasValue;
            }
            set
            {
            }
        }

        public const string HasHeightPercentilePropertyName = "HasHeightPercentile";


        private decimal? _WeightPercentile;

        public decimal? WeightPercentile
        {
            get
            {
                return _WeightPercentile;
            }
            set
            {
                _WeightPercentile = value;
                OnPropertyChanged(WeightPercentilePropertyName);
                OnPropertyChanged(HasWeightPercentilePropertyName);
            }
        }

        public const string WeightPercentilePropertyName = "WeightPercentile";

        public bool HasWeightPercentile
        {
            get
            {
                return WeightPercentile.HasValue;
            }
            set
            {
            }
        }

        public const string HasWeightPercentilePropertyName = "HasWeightPercentile";


        private decimal? _BMI;

        public decimal? BMI
        {
            get
            {
                return _BMI;
            }
            set
            {
                _BMI = value;
                OnPropertyChanged(BMIPropertyName);
                OnPropertyChanged(HasBMIPropertyName);
            }
        }

        public const string BMIPropertyName = "BMI";

        public bool HasBMI
        {
            get
            {
                return BMI.HasValue;
            }
            set
            {
            }
        }

        public const string HasBMIPropertyName = "HasBMI";

        private decimal? _BMIPercentile;

        public decimal? BMIPercentile
        {
            get
            {
                return _BMIPercentile;
            }
            set
            {
                _BMIPercentile = value;
                OnPropertyChanged(BMIPercentilePropertyName);
                OnPropertyChanged(HasBMIPercentilePropertyName);
            }
        }

        public const string BMIPercentilePropertyName = "BMIPercentile";


        public bool HasBMIPercentile
        {
            get
            {
                return BMIPercentile.HasValue;
            }
            set
            {
            }
        }

        public const string HasBMIPercentilePropertyName = "HasBMIPercentile";

        private string _BMIConclusion;

        public string BMIConclusion
        {
            get
            {
                return _BMIConclusion;
            }
            set
            {
                _BMIConclusion = value;
                OnPropertyChanged(BMIConclusionPropertyName);
            }
        }

        public const string BMIConclusionPropertyName = "BMIConclusion";


        private Color _BMIPercentilColor;

        public Color BMIPercentilColor
        {
            get
            {
                return _BMIPercentilColor;
            }
            set
            {
                _BMIPercentilColor = value;
                OnPropertyChanged(BMIPercentilColorPropertyName);
            }
        }

        public const string BMIPercentilColorPropertyName = "BMIPercentilColor";




        private string _FooterInfo;

        public string FooterInfo
        {
            get
            {
                return _FooterInfo;
            }
            set
            {
                _FooterInfo = value;
                OnPropertyChanged(FooterInfoPropertyName);
            }
        }

        public const string FooterInfoPropertyName = "FooterInfo";


        private readonly PercentileService _percentilesService;


        public PercentilesPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _percentilesService = new PercentileService();
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;
            MaxDate = DateTime.Now.Date;
            MinDate = DateTime.Now.AddYears(-18).Date;
            Birthdate = DateTime.Today;
            WeightUnit = "kg";
            HeightUnit = "cm";
            Genders = new ObservableCollection<string>
            {
                "Feminino",
                "Masculino"
            };
            SelectedGender = Genders.First();

            FooterInfo = "Dados WHO Child Growth Standards. WHO Child Growth Standards não disponibiliza percentis de peso para idades superiores a 10 anos.";
            CalculateCommand = new Command(async () => await Calculate());
        }

        public async Task Calculate()
        {
            List<Task> tasks = new List<Task>();
            Task<Percentile> weightTask = null, heightTask = null;
            Task<decimal> bmiTask = null;
            bool calculateWeight = false, calculateHeight = false, calculateBMI = false;

            ErrorMessage = String.Empty;

            try
            {
                decimal heightDec = 0, weightDec = 0;

                if (!String.IsNullOrEmpty(Weight) && decimal.TryParse(Weight.Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out weightDec) && weightDec > 0 && Birthdate > DateTime.Now.AddYears(-10))
                {
                    weightTask = _percentilesService.GetWeightPercentile(SelectedGenderValue, Birthdate, weightDec);
                    tasks.Add(weightTask);
                    calculateWeight = true;
                }
                else
                {
                    WeightPercentile = null;
                }

                ;
                if (!String.IsNullOrEmpty(Height) && decimal.TryParse(Height.Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out heightDec) && heightDec > 0)
                {
                    heightTask = _percentilesService.GetHeightPercentile(SelectedGenderValue, Birthdate, heightDec);
                    tasks.Add(heightTask);
                    calculateHeight = true;
                }
                else
                {
                    HeightPercentile = null;
                }
                if (tasks.Count == 0)
                    return;


                if (weightDec > 0 && heightDec > 0)
                {
                    calculateBMI = true;
                    bmiTask = _percentilesService.GetBMI(weightDec, heightDec);
                    tasks.Add(bmiTask);
                }
                else
                {
                    BMI = null;
                    BMIPercentile = null;
                    BMIConclusion = string.Empty;
                }

                await Task.WhenAll(tasks.ToArray());


                if (calculateWeight)
                {
                    WeightPercentile = weightTask.Result.percentile;
                    Debug.WriteLine("Weight: " + WeightPercentile);
                }

                if (calculateHeight)
                {
                    HeightPercentile = heightTask.Result.percentile;
                    Debug.WriteLine("Height: " + HeightPercentile);
                }

                if (calculateBMI)
                {
                    BMI = Math.Round(bmiTask.Result, 2);
                    var bmiPerc = await _percentilesService.GetBMIPercentile(SelectedGenderValue, Birthdate, BMI.Value);
                    BMIPercentile = bmiPerc.percentile;
                    BMIConclusion = TranslateToPT(bmiPerc.conclusion);
                    BMIPercentilColor = TranslateToColor(bmiPerc.conclusion);
                }
            }
            catch (Exception e1)
            {

                var current = Connectivity.NetworkAccess;

                if (current != NetworkAccess.Internet)
                {
                    // Connection to internet is available
                    ErrorMessage = "Esta funcionalidade exige acesso à internet. Por favor valide que tem conectividade e tente novamente. Obrigado";
                }
                else
                {
                    ErrorMessage = "Ups!! Algo correu mal. Temos os nossos melhores engenheiros a tentar resolvê-lo.";
                }

                Analytics.TrackEvent("Percentiles Error", new Dictionary<string, string>
                {
                    {"Message", e1.Message},
                    {"Exception", e1.StackTrace}
                });

            }
        }

        public Color TranslateToColor(string enStr)
        {
            if (enStr == "underweight")
            {
                return Styles.WARNING_COLOR;
            }
            else if (enStr == "healthy weight")
            {
                return Styles.SUCCESS_COLOR;
            }
            else if (enStr == "overweight")
            {
                return Styles.WARNING_COLOR;
            }
            else if (enStr == "obesity")
            {
                return Styles.NEGATIVE_COLOR;
            }
            else
            {
                return Styles.SUCCESS_COLOR;
            }
        }

        public string TranslateToPT(string enStr)
        {
            if (enStr == "underweight")
            {
                return "Abaixo do peso";
            }
            else if (enStr == "healthy weight")
            {
                return "Peso saudável";
            }
            else if (enStr == "overweight")
            {
                return "Acima do peso";
            }
            else if (enStr == "obesity")
            {
                return "Obesidade";
            }
            else
            {
                return "";
            }
        }

        private string _ErrorMessage;

        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                _ErrorMessage = value;
                OnPropertyChanged(ErrorMessagePropertyName);
            }
        }

        public const string ErrorMessagePropertyName = "ErrorMessage";



        protected override Task Activated()
        {
            Analytics.TrackEvent("Percentiles Opened", new Dictionary<string, string>
            {
            });

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                // Connection to internet is available
                ErrorMessage = "Esta funcionalidade exige acesso à internet. Por favor, garanta que o seu dispositivo tem acesso à internet e tente novamente.";
            }

            return base.Activated();
        }

    }
}
