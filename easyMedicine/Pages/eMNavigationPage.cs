using System;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
	public class eMNavigationPage : NavigationPage
	{
		public eMNavigationPage (Page page) : base (page)
		{
			this.Title = page.Title;
			this.Icon = page.Icon;
		}
	}
}

