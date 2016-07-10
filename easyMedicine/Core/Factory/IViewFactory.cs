
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using easyMedicine.Core.Models;

namespace easyMedicine.Core.Factory
{
	public interface IViewFactory
	{
		void Register<TViewModel, TView> ()
            where TViewModel : class, IPageModel
            where TView : Page;

		Page Resolve<TViewModel> (Action<TViewModel> setStateAction = null)
            where TViewModel : class, IPageModel;

		Page Resolve<TViewModel> (out TViewModel viewModel, Action<TViewModel> setStateAction = null)
            where TViewModel : class, IPageModel;

		Page Resolve<TViewModel> (TViewModel viewModel)
            where TViewModel : class, IPageModel;
	}
}
