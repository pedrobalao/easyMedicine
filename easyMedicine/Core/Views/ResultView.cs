using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{

    public class ResultView : Label
    {
        public ResultView() : base()
        {
            Title = "0";
        }




        public string Description
        {
            get { return (string)GetValue(DescriptionLabelTextProperty); }
            set { SetValue(DescriptionLabelTextProperty, value); }
        }



        public string Title
        {
            get { return (string)GetValue(TitleLabelTextProperty); }
            set { SetValue(TitleLabelTextProperty, value); }
        }

        public string Subtitle
        {
            get { return (string)GetValue(SubtitleLabelTextProperty); }
            set { SetValue(SubtitleLabelTextProperty, value); }
        }




        public static readonly BindableProperty DescriptionLabelTextProperty =
            BindableProperty.Create("Description", typeof(string), typeof(ResultView), String.Empty);


        public static readonly BindableProperty TitleLabelTextProperty =
            BindableProperty.Create("Title", typeof(string), typeof(ResultView), String.Empty);


        public static readonly BindableProperty SubtitleLabelTextProperty =
            BindableProperty.Create("Subtitle", typeof(string), typeof(ResultView), String.Empty);


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                BuildFormatedText();
            }
        }






        private void BuildFormatedText()
        {
            try
            {
                var fs = new FormattedString();
                if (!String.IsNullOrEmpty(Description))
                {
                    Span dsp = new Span { Text = Description + ": " };
                    fs.Spans.Add(dsp);
                }

                Span sp = new Span { Text = Title };
                fs.Spans.Add(sp);

                sp = new Span { Text = " " + Subtitle };
                fs.Spans.Add(sp);

                FormattedText = fs;
            }
            catch (Exception e1)
            {
                Debug.WriteLine("Deu Merda: " + e1.Message);
                throw e1;
            }
        }



    }
}
