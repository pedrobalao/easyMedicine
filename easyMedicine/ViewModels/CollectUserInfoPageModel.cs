using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Services;
using Xamarin.Forms;

namespace easyMedicine.ViewModels
{

    public class KeyValuePairViewModel<T, C>
    {
        public T Key
        {
            get;
            set;
        }

        public C Value
        {
            get;
            set;
        }

        public ICommand Command { get; set; }

        public KeyValuePairViewModel(T key, C value, ICommand command)
        {
            this.Key = key;
            this.Value = value;
            this.Command = command;
        }

    }
    public class CollectUserInfoPageModel : PageModelBase
    {
        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;
        //public ICommand DrugSelectedCommand { get; private set; }



        public CollectUserInfoPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;

            TypeOfUserSelectedCommand = new Command<string>(async (type) =>
            {
                try
                {

                    var result = await AuthenticationService.SetUserType(new SetUserTypeRequest()
                    {
                        professional_id = "",
                        type = type
                    });


                }
                catch (Exception e1)
                {
                    Console.WriteLine($"Erro {e1.Message}");
                }
                finally
                {
                    navigator.PopModalAsync();
                }
            });

            UserTypeOptions = new ObservableCollection<KeyValuePairViewModel<string, string>>();
            UserTypeOptions.Add(new KeyValuePairViewModel<string, string>("doctor", "Médico", TypeOfUserSelectedCommand));
            UserTypeOptions.Add(new KeyValuePairViewModel<string, string>("dentist", "Médico Dentista", TypeOfUserSelectedCommand));
            UserTypeOptions.Add(new KeyValuePairViewModel<string, string>("nurse", "Enfermeiro", TypeOfUserSelectedCommand));
            UserTypeOptions.Add(new KeyValuePairViewModel<string, string>("pharmaceutical", "Farmacêutico", TypeOfUserSelectedCommand));
            UserTypeOptions.Add(new KeyValuePairViewModel<string, string>("other", "Outro", TypeOfUserSelectedCommand));





        }

        public ICommand TypeOfUserSelectedCommand
        {
            get;
            private set;
        }


        public const string TypeOfUserSelectedCommandPropertyName = "TypeOfUserSelectedCommand";


        public static string UserName
        {
            get
            {
                return AuthenticationService.User.DisplayName;
            }
        }

        private ObservableCollection<KeyValuePairViewModel<string, string>> _UserTypeOptions;

        public ObservableCollection<KeyValuePairViewModel<string, string>> UserTypeOptions
        {
            get
            {
                return _UserTypeOptions;
            }
            set
            {
                _UserTypeOptions = value;
                OnPropertyChanged(UserTypeOptionsPropertyName);
            }
        }

        public const string UserTypeOptionsPropertyName = "UserTypeOptions";



        private string _UserType;

        public string UserType
        {
            get
            {
                return _UserType;
            }
            set
            {
                _UserType = value;
                OnPropertyChanged(UserTypePropertyName);
            }
        }

        public const string UserTypePropertyName = "UserType";


        private string _UserProfessionalId;

        public string UserProfessionalId
        {
            get
            {
                return _UserProfessionalId;
            }
            set
            {
                _UserProfessionalId = value;
                OnPropertyChanged(UserProfessionalIdPropertyName);
            }
        }

        public const string UserProfessionalIdPropertyName = "UserProfessionalId";





    }
}
