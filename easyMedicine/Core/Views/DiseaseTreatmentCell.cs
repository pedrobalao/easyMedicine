using System;
using easyMedicine.Core.Converters;
using Xamarin.Forms;

namespace easyMedicine.Core.Views
{
    public class DiseaseTreatmentCell : ViewCell
    {


        LabelValueNB lbtFirstLine, lbtSecondLine, lbtThirdLine;
        Label lbCondition;

        public static readonly BindableProperty FirstLineProperty =
            BindableProperty.Create("FirstLine", typeof(string), typeof(DiseaseTreatmentCell), "FirstLine");
        public static readonly BindableProperty SecondLineProperty =
            BindableProperty.Create("SecondLine", typeof(string), typeof(DiseaseTreatmentCell), "SecondLine");
        public static readonly BindableProperty ThirdLineProperty =
            BindableProperty.Create("ThirdLine", typeof(string), typeof(DiseaseTreatmentCell), "ThirdLine");
        public static readonly BindableProperty ConditionProperty =
            BindableProperty.Create("Condition", typeof(string), typeof(DiseaseTreatmentCell), "Condition");


        public string FirstLine
        {
            get { return (string)GetValue(FirstLineProperty); }
            set { SetValue(FirstLineProperty, value); }
        }
        public string SecondLine
        {
            get { return (string)GetValue(SecondLineProperty); }
            set { SetValue(SecondLineProperty, value); }
        }
        public string ThirdLine
        {
            get { return (string)GetValue(ThirdLineProperty); }
            set { SetValue(ThirdLineProperty, value); }
        }
        public string Condition
        {
            get { return (string)GetValue(ConditionProperty); }
            set { SetValue(ConditionProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                lbtFirstLine.Description.Text = FirstLine;
                if (string.IsNullOrWhiteSpace(SecondLine))
                {
                    lbtSecondLine.Title.IsVisible = false;
                    lbtSecondLine.Description.IsVisible = false;
                }
                else
                {
                    lbtSecondLine.Title.IsVisible = true;
                    lbtSecondLine.Description.IsVisible = true;
                }
                lbtSecondLine.Description.Text = SecondLine;

                if (string.IsNullOrWhiteSpace(ThirdLine))
                {
                    lbtThirdLine.Title.IsVisible = false;
                    lbtThirdLine.Description.IsVisible = false;
                }
                else
                {
                    lbtThirdLine.Title.IsVisible = true;
                    lbtThirdLine.Description.IsVisible = true;
                }
                lbtThirdLine.Description.Text = ThirdLine;
                lbCondition.Text = Condition;
            }
        }
        public DiseaseTreatmentCell()
        {

            var layout = new StackLayout()
            {
                Padding = new Thickness(5),
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            lbCondition = new Label()
            {
                Style = (Style)Application.Current.Resources[Styles.Style_LabelHashlStyle],
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Styles.BLUE_COLOR
            };
            //lbtSecondLine.SetBinding(Label.TextProperty, "Condition");
            //lbtFirstLine.BindingContext = this;

            layout.Children.Add(lbCondition);

            lbtFirstLine = new LabelValueNB();
            lbtFirstLine.Title.Text = "1ª Linha";
            //lbtFirstLine.BindingContext = this;
            layout.Children.Add(lbtFirstLine);

            lbtSecondLine = new LabelValueNB();
            lbtSecondLine.Title.Text = "2ª Linha";
            //lbtSecondLine.BindingContext = this;
            //lbtSecondLine.SetBinding(LabelValue.IsVisibleProperty, "SecondLine", BindingMode.OneWay, new StringToBoolConverter());
            layout.Children.Add(lbtSecondLine);


            lbtThirdLine = new LabelValueNB();
            lbtThirdLine.Title.Text = "3ª Linha";
            //lbtThirdLine.BindingContext = this;
            //lbtSecondLine.SetBinding(LabelValue.IsVisibleProperty, "ThirdLine", BindingMode.OneWay, new StringToBoolConverter());
            layout.Children.Add(lbtThirdLine);


            View = layout;
        }
    }
}
