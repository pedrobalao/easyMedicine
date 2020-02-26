//using System;
//using easyMedicine.iOS.Renderers;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
//namespace easyMedicine.iOS.Renderers
//{

//    public class CustomWebViewRenderer : WkWebViewRenderer
//    {
//        protected override void OnElementChanged(VisualElementChangedEventArgs e)
//        {
//            base.OnElementChanged(e);

//            var view = Element as WebView;
//            if (view == null || NativeView == null)
//            {
//                return;
//            }
//            this.ShowsLargeContentViewer = true;
//        }

//    }
//}
