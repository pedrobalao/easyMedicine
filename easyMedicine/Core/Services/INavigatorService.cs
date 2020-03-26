
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using easyMedicine.Core.Models;
using easyMedicine.ViewModels;
using Xamarin.Forms;

namespace easyMedicine.Core.Services
{
    public interface INavigatorService
    {

        Page RootPage { get; }

        Task PopAsync();

        Task PopModalAsync();

        Task PopToRootAsync();

        Task ReplaceRoot<TPageModel>(string screen, Action<TPageModel> setStateAction = null)
            where TPageModel : class, IPageModel;

        void InsertPageBefore<TPageModel, TPageModelBefore>()
            where TPageModel : class, IPageModel
            where TPageModelBefore : class, IPageModel;

        Task<TViewModel> PushAsync<TViewModel>(string screen, Action<TViewModel> setStateAction = null)
            where TViewModel : class, IPageModel;

        Task<TViewModel> PushAsync<TViewModel>(string screen, TViewModel viewModel)
            where TViewModel : class, IPageModel;

        Task<TViewModel> PushModalAsync<TViewModel>(string screen, Action<TViewModel> setStateAction = null)
            where TViewModel : class, IPageModel;

        Task<TViewModel> PushModalAsync<TViewModel>(string screen, TViewModel viewModel)
            where TViewModel : class, IPageModel;


        Task<TViewModel> PushDetail<TViewModel>(string screen, Action<TViewModel> setStateAction = null)
            where TViewModel : class, IPageModel;

        Task<TViewModel> PushDetail<TViewModel>(string screen, TViewModel viewModel)
        where TViewModel : class, IPageModel;

        void Start<TViewModel>(string screen, App app = null, Action<TViewModel> setStateAction = null)
             where TViewModel : class, IPageModel;

        TPageModel PushTab<TPageModel>(string screen, Action<TPageModel> setStateAction = null)
            where TPageModel : class, IPageModel;

        Task<AuthenticatorPageModel> PushAuthenticatorModal(Action<AuthenticatorPageModel> setStateAction = null);
    }
}
