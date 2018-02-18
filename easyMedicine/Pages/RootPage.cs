using System;
//using Acr.UserDialogs;
using Xamarin.Forms;

namespace easyMedicine.Pages
{
    public class RootPage : CustomTabbedPage
    {
        public RootPage()
        {
            Title = "easyPed";
            //this.ba = Color.Red;
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
           {
               //UserDialogs.Instance.
               this.CurrentPage.DisplayAlert("ATENÇÃO", "A informação presente no easyPed pode conter erros. Não nos responsabilizamos por qualquer consequência do uso da mesma. Toda a informação deve ser validada pelo médico.", "Li e Concordo");
           });

        }


    }
}

