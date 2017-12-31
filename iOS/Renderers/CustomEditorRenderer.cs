using System;
using easyMedicine.Core.Views;
using easyMedicine.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace easyMedicine.iOS.Renderers
{

    public class CustomEditorRenderer : EditorRenderer
    {
        private string Placeholder { get; set; }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var element = this.Element as CustomEditor;

            if (Control != null && element != null)
            {
                Placeholder = element.Placeholder;
                Control.TextColor = ExtensionMethods.ToUIColor(Styles.PLACEHOLDER_COLOR_HEX);
                if (Control.Text == "")
                {
                    Control.Text = Placeholder;
                }
                Control.ShouldBeginEditing += (UITextView textView) =>
                {
                    if (textView.Text == Placeholder)
                    {
                        textView.Text = "";
                        textView.TextColor = ExtensionMethods.ToUIColor(Styles.BASE_COLOR_HEX); // Text Color
                    }

                    return true;
                };

                Control.ShouldEndEditing += (UITextView textView) =>
                {
                    if (textView.Text == "")
                    {
                        textView.Text = Placeholder;
                        textView.TextColor = ExtensionMethods.ToUIColor(Styles.PLACEHOLDER_COLOR_HEX); // Placeholder Color
                    }

                    return true;
                };

                Control.Layer.BorderColor = Color.FromHex("#FFFFFF").ToCGColor(); //Color.FromHex("#e5e5e5").ToCGColor();
                Control.Layer.MasksToBounds = true;
                Control.Layer.CornerRadius = 1;
                Control.Layer.BorderWidth = 1f;
                Control.Layer.BorderColor = Color.FromHex("#FFFFFF").ToCGColor();//Color.FromHex("#999999").ToCGColor();
                Control.Layer.BackgroundColor = Color.Transparent.ToCGColor();
                Control.SpellCheckingType = UITextSpellCheckingType.No;             // No Spellchecking
                Control.AutocorrectionType = UITextAutocorrectionType.No;           // No Autocorrection
                Control.AutocapitalizationType = UITextAutocapitalizationType.None; // No Autocapitalization
                if (Control.InputAccessoryView != null)
                    Control.InputAccessoryView.Hidden = true;//For Removing Done button from editor keyboard.
                Control.KeyboardType = UIKeyboardType.ASCIICapable;//For Removing Emoticons from keyboard.
            }
        }
    }
}

