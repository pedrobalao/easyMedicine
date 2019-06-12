using System;
using easyMedicine.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Linq;
using UIKit;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace easyMedicine.iOS
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            Control.SearchBarStyle = UIKit.UISearchBarStyle.Minimal;

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                this.Control.TextChanged += (s, ea) =>
                {
                    //if (ea.SearchText == "")
                    this.Control.ShowsCancelButton = true;
                };

                this.Control.OnEditingStarted += (s, ea) => //when control receives focus
                {
                    this.Control.ShowsCancelButton = true;
                };

                this.Control.OnEditingStopped += (s, ea) => //when control looses focus 
                {
                    this.Control.ShowsCancelButton = false;
                };
                try
                {
                    Control.Subviews[0].TintColor = Styles.LETTER_COLOR_HEX.ToUIColor();
                }
                catch { }

            }
        }
    }
}

