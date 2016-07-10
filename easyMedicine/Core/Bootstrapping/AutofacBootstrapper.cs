using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using easyMedicine.Core.Factory;

namespace easyMedicine.Core.Bootstrapping
{
	public abstract class AutofacBootstrapper
	{
		protected IContainer _container;

    
		public void Setup ()
		{
			var builder = new ContainerBuilder ();

			ConfigureContainer (builder);
			_container = builder.Build ();
			var viewFactory = _container.Resolve<IViewFactory> ();

			RegisterViews (viewFactory);
         
		}

      

		protected virtual void ConfigureContainer (ContainerBuilder builder)
		{
			builder.RegisterModule<AutofacModule> ();
		}


       
		public void RegisterPlatformService<T> (T accountStore) where T: class
		{
			var builder = new ContainerBuilder ();
			builder.RegisterInstance<T> (accountStore);
			builder.Update (_container);
		}

     
		protected abstract void RegisterViews (IViewFactory viewFactory);

		/*public virtual Task<bool> Start()
        {
            
        }*/
    	

	}
}
