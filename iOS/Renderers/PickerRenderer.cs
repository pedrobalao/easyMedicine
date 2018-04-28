using System;
using easyMedicine.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace easyMedicine.iOS.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var picker = (UIPickerView)this.Control.InputView;
                //picker.BackgroundColor = UIColor.White;


                Control.Font = UIFont.FromName("Avenir-Book", 17f);
                Control.TextAlignment = UITextAlignment.Right;

                this.Control.Layer.BorderWidth = 1;
                this.Control.Layer.BorderColor = ExtensionMethods.ToUIColor(Styles.BLUE_COLOR_HEX).CGColor;
                //Control.BorderStyle = UITextBorderStyle.None;
                //Control.TextColor = UIColor.Purple;
            }
        }


    }
}
