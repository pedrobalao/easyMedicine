using System;
using Android.Content;
using easymedicine.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(LabelcRenderer))]
namespace easymedicine.Droid.Renderers
{
    public class LabelcRenderer : LabelRenderer
    {
        public LabelcRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
        }
    }
}
