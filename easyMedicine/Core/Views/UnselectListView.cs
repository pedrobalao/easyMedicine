using System;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class UnselectListView : ListView
    {
        public UnselectListView() : base()
        {
            this.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                // don't do anything if we just de-selected the row     
                if (e.Item == null) return;
                // do something with e.SelectedItem     
                ((ListView)sender).SelectedItem = null;
                // de-select the row after ripple effect 
            };
        }
    }
}
