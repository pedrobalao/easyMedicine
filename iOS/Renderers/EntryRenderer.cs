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

            this.Control.BorderStyle = UITextBorderStyle.None;
            this.Control.TintColor = UIColor.Black;
        }
    }
}
