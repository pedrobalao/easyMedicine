using System;

using System.Collections.ObjectModel;
using easyMedicine.Models;
using easyMedicine.Core.Models;
using System.Threading.Tasks;
using easyMedicine.Services;
using easyMedicine.Core.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace easyMedicine.ViewModels
{
	public class SearchPageModel : PageModelBase
	{

		IDrugsDataService _drugsDataServ;
		INavigatorService _navigator;
		public ICommand DrugSelectedCommand { get; private set; }

		public SearchPageModel (INavigatorService navigator, IDrugsDataService drugsDataServ)
		{
			_drugsDataServ = drugsDataServ;
			_navigator = navigator;
		
			DrugSelectedCommand = new Command<Drug>(async (cat) => await DrugSelected(cat));

			SearchResult = new ObservableCollection<Drug> ();
		}

		private ObservableCollection<Drug> _SearchResult;

		public ObservableCollection<Drug> SearchResult {
			get {
				return _SearchResult;
			}
			set {
				_SearchResult = value;
				OnPropertyChanged (SearchResultPropertyName);
			}
		}

		public const string SearchResultPropertyName = "SearchResult";

		private string _SearchString;

		public string SearchString {
			get {
				return _SearchString;
			}
			set {
				_SearchString = value;
				OnPropertyChanged (SearchStringPropertyName);

			}
		}

		public const string SearchStringPropertyName = "SearchString";


		async Task DrugSelected(Drug tappedItem)
		{
			Debug.WriteLine("Tapped Cat -> " + tappedItem.Name);

			await _navigator.PushAsync<DrugPageModel>("Drug", (model) =>
			{
				model.Drug = tappedItem;
			});
		}

		public async Task FilterDrugs() 
		{
			SearchResult.Clear();

			if (string.IsNullOrEmpty(SearchString))
				return;

			var data = await _drugsDataServ.SearchDrug(SearchString);

			foreach (var item in data)
			{
				SearchResult.Add(item);
			}

		} 


	}
}

