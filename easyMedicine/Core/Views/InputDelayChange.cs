using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class InputDelayChange : Entry
    {
        public event EventHandler<TextChangedEventArgs> DelayedTextChanged;

        private string _lastText = String.Empty;
        public InputDelayChange()
        {
            this.TextChanged += async (object sender, TextChangedEventArgs e) =>
            {
                var currentText = e.NewTextValue;
                await Task.Delay(500);
                if (currentText == this.Text)
                {
                    if (DelayedTextChanged != null)
                    {
                        DelayedTextChanged.Invoke(sender, e);
                    }
                }
            };
        }


    }
}
