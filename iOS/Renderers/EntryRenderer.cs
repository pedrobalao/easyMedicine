using System;
using easyMedicine.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace easyMedicine.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null) return;

            //this.Control.BorderStyle = UITextBorderStyle.Line;
            this.Control.Layer.BorderWidth = 1;
            this.Control.Layer.BorderColor = ExtensionMethods.ToUIColor(Styles.BLUE_COLOR_HEX).CGColor;
            //this.Control.TintColor = UIColor.Black;
        }
    }
}
