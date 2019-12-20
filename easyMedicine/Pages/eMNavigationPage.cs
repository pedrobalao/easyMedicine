using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class eMNavigationPage : NavigationPage
    {
        public eMNavigationPage(Page page) : base(page)
        {
            Console.WriteLine("Debug eMNavigationPage");
            this.Title = page.Title;
            this.Icon = page.Icon;
            NavigationPage.SetBackButtonTitle(page, "");
        }
    }
}

