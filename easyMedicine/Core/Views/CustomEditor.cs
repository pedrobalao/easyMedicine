using System;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class CustomEditor : Editor
    {
        public static readonly BindableProperty PlaceholderProperty =
          BindableProperty.Create<CustomEditor, string>(view => view.Placeholder, String.Empty);

        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }
    }
}
