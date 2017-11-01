using System;
using System.ComponentModel;
using Android.App;
using Android.Views;
using easymedicine.Droid.Renderers;
using easyMedicine;
using easyMedicine.Core.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace easymedicine.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var element = e.NewElement as CustomEditor;
                this.Control.Hint = element.Placeholder;
                this.Control.SetHintTextColor(Android.Graphics.Color.ParseColor("#e6e6e6"));
                this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                this.Control.SetCursorVisible(true);
                this.Control.SetTextColor(Android.Graphics.Color.ParseColor("#505050"));
                this.Control.Background = this.Resources.GetDrawable(Resource.Drawable.withBorderEditor);
            }
            Control.FocusChange += Control_FocusChange;
        }

        void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                if (Xamarin.Forms.Application.Current.Properties.ContainsKey("count"))
                {
                    int ct = Convert.ToInt32(App.Current.Properties["count"]);
                    if (ct > 1)
                    {
                        (Forms.Context as Activity).Window.SetSoftInputMode(SoftInput.AdjustPan);
                    }
                    else
                    {
                        (Forms.Context as Activity).Window.SetSoftInputMode(SoftInput.AdjustResize);
                    }
                }

            }
            else
            {
                (Forms.Context as Activity).Window.SetSoftInputMode(SoftInput.AdjustNothing);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomEditor.PlaceholderProperty.PropertyName)
            {
                var element = this.Element as CustomEditor;
                this.Control.Hint = element.Placeholder;
                this.Control.SetHintTextColor(Android.Graphics.Color.ParseColor("#e5e5e5"));
                this.Control.SetTextColor(Android.Graphics.Color.ParseColor("#505050"));
            }
        }
    }
}
