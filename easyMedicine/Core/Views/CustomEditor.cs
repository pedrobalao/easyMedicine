using System;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class CustomEditor : Editor
    {

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(CustomEditor), String.Empty);


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
