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
            Credits = "Ruben Rocha\nAna Reis Melo\nClaudia Teles Silva\nJoão Sarmento\nMariana Adrião\nMarta Rosário\nSofia Ferreira\nSónia Silva";
            Discloser = "Esta aplicação pretende ser um auxilio na prescrição médica pediatrica. Todos os fármacos foram inseridos com o máximo rigor e precaução, todavia é impossível assegurar a ausência total de erros. Assim sendo, os autores declinam qualquer responsabilidade na utilização da mesma, devendo qualquer dose ou indicação ser confirmada em documentos de referencia atualizados aquando da prescrição. " +
                "Pretendemos que a aplicação seja revista periodicamente para se manter atualizada. Qualquer erro relativo aos fármacos pode e deve ser reportado no espaço próprio de cada fármaco. Qualquer sugestão de adição de fármacos ou outra sugestão é bem-vinda e pode ser reportada do mesmo modo que os fármacos. ";
            Biblio = "Takemoto CK, Hodding JH, Kraus, DM. Pediatric & Neonatal Dosage Handbook, 21st ed. Hudson, Ohio, Lexi-Comp, Inc. 2014" +
                    "\nProntuário terapêutico. Infarmed. Versão on-line. Acedida no ano 2016 - 2017." + "European medicines agency database. Acesso online. Ano 2016 - 2017" +
                    "\nFormulário hospitalar nacional do medicamento. Infarmed. Versão on-line. Acedida no ano 2016 - 2017." +
                    "\nAnjos R, Bandeira T, Marques JG. Formulário de Pediatria. 3 edição." +
                "\nMedscape drug database. Acesso online. Ano 2016 - 2017";
        }



        protected override async System.Threading.Tasks.Task Started()
        {
            await base.Started();

        }

    }
}

