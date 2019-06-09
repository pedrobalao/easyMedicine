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
using easyMedicine.Helpers;

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

        private string _Discloser;

        public string Discloser
        {
            get
            {
                return _Discloser;
            }
            set
            {
                _Discloser = value;
                OnPropertyChanged(DiscloserPropertyName);
            }
        }

        public const string DiscloserPropertyName = "Discloser";


        private string _Biblio;

        public string Biblio
        {
            get
            {
                return _Biblio;
            }
            set
            {
                _Biblio = value;
                OnPropertyChanged(BiblioPropertyName);
            }
        }

        public const string BiblioPropertyName = "Biblio";

        public AboutPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ)
        {
            _navigator = navigator;
            Credits = "Dr. Ruben Rocha - Pediatra\n" +
                "Dra. Ana Reis Melo - Interna de Pediatria\n" +
                "Dra. Claudia Teles Silva - Interna de Pediatria\n" +
                "Dr. João Sarmento - Interno de Cardiologia Pediátrica\n" +
                "Dra. Mariana Adrião - Interna de Pediatria\n" +
                "Dra. Marta Rosário - Interna de Pediatria\n" +
                "Dr. Ruben Pinheiro - Cirurgião Pediátrico\n" +
                "Dra. Sofia Ferreira - Interna de Pediatria\n" +
                "Dra. Sónia Silva - Interna de Pediatria";

            Discloser = "Esta aplicação é dirigida a profissionais de saúde. Pretende ser um auxilio à prática da medicina pediátrica. Todos os dados foram inseridos e validados por médicos do corpo clínico do Centro Materno Infantil do Norte e Centro Hospitalar São João. " +
                "Embora envidemos todos os esforços razoáveis para garantir que as informações contidas na easyPed sejam corretas, esteja ciente de que as informações podem estar incompletas, imprecisas ou desatualizadas e não podem ser garantidas. Assim, está excluída a garantia ou responsabilidade de qualquer tipo. Os autores declinam qualquer responsabilidade na utilização da mesma, devendo qualquer dose ou indicação ser confirmada em documentos de referencia atualizados aquando da prescrição. " +
                "Qualquer erro relativo aos fármacos pode e deve ser reportado no espaço próprio de cada fármaco. Qualquer sugestão de adição de fármacos ou outra sugestão é bem-vinda e pode ser reportada do mesmo modo que os fármacos. ";

            Biblio = "Takemoto CK, Hodding JH, Kraus, DM. Pediatric & Neonatal Dosage Handbook, 21st ed. Hudson, Ohio, Lexi-Comp, Inc. 2014" +
                    "\nProntuário terapêutico. Infarmed. Versão on-line. Acedida no ano 2016 - 2017." + "European medicines agency database. Acesso online. Ano 2016 - 2017" +
                    "\nFormulário hospitalar nacional do medicamento. Infarmed. Versão on-line. Acedida no ano 2016 - 2017." +
                    "\nAnjos R, Bandeira T, Marques JG. Formulário de Pediatria. 3 edição." +
                "\nMedscape drug database. Acesso online. Ano 2016 - 2017";
        }

        public int BDVersion
        {
            get
            {
                Settings.GetDB(out int dbVersion, out string dbFile, out bool initalDB);
                return dbVersion;
            }

        }

        public const string BDVersionPropertyName = "BDVersion";




        protected override async System.Threading.Tasks.Task Started()
        {
            await base.Started();

        }

    }
}

