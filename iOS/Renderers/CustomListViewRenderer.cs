using System;
using easyMedicine.Core.Views;
using easyMedicine.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListView), typeof(IosListViewRenderer))]
[assembly: ExportRenderer(typeof(UnselectListView), typeof(IosListViewRenderer))]
namespace easyMedicine.iOS
{
    public class IosListViewRenderer : ListViewRenderer
    {

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.TableFooterView = new UIKit.UIView();

            }

        }



    }
}

