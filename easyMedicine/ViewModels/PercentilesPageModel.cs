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
using Microsoft.Azure.Mobile.Analytics;
using System.Globalization;

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
            MinDate = DateTime.Now.AddDays(-1856).Date;
            Birthdate = DateTime.Today;
            WeightUnit = "kg";
            HeightUnit = "cm";
            Genders = new ObservableCollection<string>
            {
                "Feminino",
                "Masculino"
            };
            SelectedGender = Genders.First();

            FooterInfo = "Dados WHO Child Growth Standards";
            CalculateCommand = new Command(async () => await Calculate());
        }

        public async Task Calculate()
        {
            List<Task> tasks = new List<Task>();
            Task<Percentile> weightTask = null, heightTask = null;
            bool calculateWeight = false, calculateHeight = false;

            ErrorMessage = String.Empty;

            try
            {
                decimal weightDec;

                if (!String.IsNullOrEmpty(Weight) && decimal.TryParse(Weight.Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out weightDec) && weightDec > 0)
                {
                    weightTask = _percentilesService.GetWeightPercentile(SelectedGenderValue, Birthdate, weightDec);
                    tasks.Add(weightTask);
                    calculateWeight = true;
                }
                else
                {
                    WeightPercentile = null;
                }

                decimal heightDec;
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

                await Task.WhenAll(tasks.ToArray());

                if (calculateWeight)
                {
                    var res = weightTask.Result;
                }
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
