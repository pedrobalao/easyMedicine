using System;

using Xamarin.Forms;

namespace easyMedicine
{


	public class App : Application
	{
		public Bootstrapper BootStrapper;

		public App ()
		{
			//GmsDirection.Init ("AIzaSyAzlgYgYEQFVR-j2t6auJuXUoF3Y6s1Efk");
			Styles.LoadStyles ();
			this.BootStrapper = new Bootstrapper (this);


			//System.AppDomain.UnhandledException+=
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

