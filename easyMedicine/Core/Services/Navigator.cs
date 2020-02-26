
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin;
using easyMedicine.Core.Factory;
using easyMedicine.Core.Models;
using easyMedicine.Pages;
using easyMedicine.Services;

namespace easyMedicine.Core.Services
{
    public class Navigator : INavigatorService
    {
        #region Vars

        private readonly Lazy<INavigation> _navigation;
        private readonly IViewFactory _viewFactory;
        private App _app;
        private Page _root;

        #endregion

        public Navigator(IViewFactory viewFactory, Lazy<INavigation> navigation)
        {
            _navigation = navigation;
            _viewFactory = viewFactory;
        }

        #region Props

        private INavigation Navigation
        {
            get
            {
                if (_app.MainPage is MasterDetailPage)
                    return ((MasterDetailPage)_app.MainPage).Detail.Navigation;
                else
                    return _app.MainPage.Navigation;
            }
        }


        public Page RootPage
        {
            get
            {
                return (Page)_root;
            }
        }


        #endregion

        public async Task PopAsync()
        {
            await Navigation.PopAsync();
            return;
        }

        public async Task PopModalAsync()
        {
            if (Navigation.ModalStack.Count > 0)
                Navigation.PopModalAsync();
        }

        public async Task ReplaceRoot<TPageModel>(string screen, Action<TPageModel> setStateAction = null)
            where TPageModel : class, IPageModel
        {
            TPageModel viewModel;
            Page view;
            if (setStateAction != null)
                view = _viewFactory.Resolve<TPageModel>(out viewModel, setStateAction) as Page;
            else
                view = _viewFactory.Resolve<TPageModel>(out viewModel) as Page;

            Navigation.InsertPageBefore(view, _root);
            _root = view;

            if (_root is CustomTabbedPage)
            {
                await viewModel.LoadChildPages();
            }

            await Navigation.PopToRootAsync();
        }

        public void InsertPageBefore<TPageModel, TPageModelBefore>()
            where TPageModel : class, IPageModel
            where TPageModelBefore : class, IPageModel
        {
            TPageModel viewModel;
            var view = _viewFactory.Resolve<TPageModel>(out viewModel);

            TPageModelBefore viewModelBefore;
            var viewBefore = _viewFactory.Resolve<TPageModelBefore>(out viewModelBefore);

            Navigation.InsertPageBefore(view, viewBefore);
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public async Task<TPageModel> PushAsync<TPageModel>(string screen, Action<TPageModel> setStateAction = null)
            where TPageModel : class, IPageModel
        {
            TPageModel viewModel;
            var view = _viewFactory.Resolve<TPageModel>(out viewModel, setStateAction);
            viewModel.CreationAction = true;
            /*using (Insights.TrackTime("Loading " + screen, new Dictionary<string, string> { { "Screen", screen } }))
            {
                 await viewModel.LoadAsync();
            }*/
            await Navigation.PushAsync(view);
            return viewModel;
        }


        public async Task<TPageModel> PushAsync<TPageModel>(string screen, TPageModel viewModel)
            where TPageModel : class, IPageModel
        {
            /* using (Insights.TrackTime("Loading " + screen, new Dictionary<string, string> { { "Screen", screen } }))
            {
                await viewModel.LoadAsync();
            }*/
            viewModel.CreationAction = true;
            var view = _viewFactory.Resolve(viewModel);

            await Navigation.PushAsync(view);
            return viewModel;
        }

        public async Task<TPageModel> PushDetail<TPageModel>(string screen, Action<TPageModel> setStateAction = null)
            where TPageModel : class, IPageModel
        {
            TPageModel viewModel;
            var view = _viewFactory.Resolve<TPageModel>(out viewModel, setStateAction);
            viewModel.CreationAction = true;


            //RootPage.CurrentPage.Navigation.PushAsync(view);
            await Navigation.PushAsync(view);

            return viewModel;
        }

        public async Task<TPageModel> PushDetail<TPageModel>(string screen, TPageModel viewModel)
           where TPageModel : class, IPageModel
        {

            /*using (Insights.TrackTime("Loading " + screen, new Dictionary<string, string> { { "Screen", screen } }))
            {
                await viewModel.LoadAsync();
            }*/
            viewModel.CreationAction = true;
            var view = _viewFactory.Resolve(viewModel);

            await Navigation.PushAsync(view);
            //RootPage.CurrentPage = new eMNavigationPage(view)
            //{


            //};
            return viewModel;
        }


        public TPageModel PushTab<TPageModel>(string screen, Action<TPageModel> setStateAction = null)
           where TPageModel : class, IPageModel
        {
            TPageModel viewModel;

            var view = _viewFactory.Resolve<TPageModel>(out viewModel, setStateAction);
            viewModel.CreationAction = true;
            //viewModel.LoadAsync();
            //RootPage.Children.Add (new eMNavigationPage (view));


            ((TabbedPage)RootPage).Children.Add(view);
            //RootPage.CurrentPage = RootPage.Children.Last ();
            //RootPage.Children.Add (view);
            return viewModel;

        }





        public async Task<TPageModel> PushModalAsync<TPageModel>(string screen, Action<TPageModel> setStateAction = null)
            where TPageModel : class, IPageModel
        {
            TPageModel viewModel;

            var view = _viewFactory.Resolve<TPageModel>(out viewModel, setStateAction);
            viewModel.CreationAction = true;
            /* using (Insights.TrackTime("Loading " + screen, new Dictionary<string, string> { { "Screen", screen } }))
            {
                 await viewModel.LoadAsync();
            }*/
            // await Navigation.PushModalAsync(view);

            if (Navigation.ModalStack.Count > 0)
            {
                Navigation.PopModalAsync();
            }
            Navigation.PushModalAsync(view);
            return viewModel;
        }

        public async Task<TPageModel> PushModalAsync<TPageModel>(string screen, TPageModel viewModel)
            where TPageModel : class, IPageModel
        {
            /* using (Insights.TrackTime("Loading " + screen, new Dictionary<string, string> { { "Screen", screen } }))
            {
                  await viewModel.LoadAsync();
            }*/
            viewModel.CreationAction = true;
            var view = _viewFactory.Resolve(viewModel);
            //await Navigation.PushModalAsync(view);


            await RootPage.Navigation.PushModalAsync(view);
            return viewModel;
        }




        public void Start<TPageModel>(string screen, App app = null, Action<TPageModel> setStateAction = null)
             where TPageModel : class, IPageModel
        {
            if (app != null)
                _app = app;
            TPageModel model;
            if (setStateAction != null)
                _root = _viewFactory.Resolve<TPageModel>(out model, setStateAction) as Page;
            else
                _root = _viewFactory.Resolve<TPageModel>(out model) as Page;
            model.CreationAction = true;
            if (_root is CustomTabbedPage)
            {
                var task = model.LoadChildPages();
                task.Wait();
            }
            _app.MainPage = new eMNavigationPage(_root)
            {
                //BarBackgroundColor = Styles.BLUE_COLOR,
                //BarTextColor = Styles.WHITE_COLOR
            };



        }




    }
}
