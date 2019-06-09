using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using easyMedicine.Core.Factory;
using easyMedicine.Core.Services;
using easyMedicine.Services;


namespace easyMedicine.Core.Bootstrapping
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            // service registration
            builder.RegisterType<ViewFactory>()
                .As<IViewFactory>()
                .SingleInstance();

            builder.RegisterType<Navigator>()
                .As<INavigatorService>()
                .SingleInstance();





            // navigation registration
            builder.Register<INavigation>(context =>
               ((TabbedPage)App.Current.MainPage).Navigation

            ).SingleInstance();

            builder.RegisterType<DrugsDataService>()
                .As<IDrugsDataService>()
                .SingleInstance();

            builder.RegisterType<DatabaseService>()
                .As<IDatabaseService>()
                .SingleInstance();


        }
    }
}
