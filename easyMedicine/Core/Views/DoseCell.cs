using System;
using Xamarin.Forms;

namespace easyMedicine
{
	public class DoseCell : ViewCell
	{


		Label viaLabel, pedDoseLabel, adultDoseLabel, takesPerDayLabel, maxDosePerDayLabel, obsLabel;

		public static readonly BindableProperty ViaProperty =
			BindableProperty.Create("Via", typeof(string), typeof(CustomCell), String.Empty);

		public static readonly BindableProperty PedDoseProperty =
			BindableProperty.Create("PedDose", typeof(string), typeof(CustomCell), String.Empty);

		public static readonly BindableProperty PedDoseUnityProperty =
			BindableProperty.Create("PedDoseUnity", typeof(string), typeof(CustomCell), String.Empty);



		public static readonly BindableProperty AdultDoseProperty =
			BindableProperty.Create("AdultDose", typeof(string), typeof(CustomCell), String.Empty);

		public static readonly BindableProperty AdultDoseUnityProperty =
			BindableProperty.Create("AdultDoseUnity", typeof(string), typeof(CustomCell), String.Empty);

		public static readonly BindableProperty TakesPerDayProperty =
			BindableProperty.Create("TakesPerDay", typeof(string), typeof(CustomCell), String.Empty);

		public static readonly BindableProperty ObsProperty =
			BindableProperty.Create("Obs", typeof(string), typeof(CustomCell), String.Empty);

		public static readonly BindableProperty MaxDosePerDayProperty =
			BindableProperty.Create("MaxDosePerDay", typeof(string), typeof(CustomCell), String.Empty);

		public static readonly BindableProperty MaxDosePerDayUnityProperty =
			BindableProperty.Create("MaxDosePerDayUnity", typeof(string), typeof(CustomCell), String.Empty);






		public string Via
		{
			get { return (string)GetValue(ViaProperty); }
			set { SetValue(ViaProperty, value); }
		}

		public string AdultDose
		{
			get { return (string)GetValue(AdultDoseProperty); }
			set { SetValue(AdultDoseProperty, value); }
		}



		public string MaxDosePerDay
		{
			get { return (string)GetValue(MaxDosePerDayProperty); }
			set { SetValue(MaxDosePerDayProperty, value); }
		}

		public string MaxDosePerDayUnity
		{
			get { return (string)GetValue(MaxDosePerDayUnityProperty); }
			set { SetValue(MaxDosePerDayUnityProperty, value); }
		}

		public string Obs
		{
			get { return (string)GetValue(ObsProperty); }
			set { SetValue(ObsProperty, value); }
		}

		public string AdultDoseUnity
		{
			get { return (string)GetValue(AdultDoseUnityProperty); }
			set { SetValue(AdultDoseUnityProperty, value); }
		}

		public string TakesPerDay
		{
			get { return (string)GetValue(TakesPerDayProperty); }
			set { SetValue(TakesPerDayProperty, value); }
		}

		public string PedDose
		{
			get { return (string)GetValue(PedDoseProperty); }
			set { SetValue(PedDoseProperty, value); }
		}

		public string PedDoseUnity
		{
			get { return (string)GetValue(PedDoseUnityProperty); }
			set { SetValue(PedDoseUnityProperty, value); }
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				viaLabel.Text = Via;
				pedDoseLabel.Text = PedDose+" "+PedDoseUnity;
				adultDoseLabel.Text = AdultDose + " " + AdultDoseUnity;
				takesPerDayLabel.Text = TakesPerDay;
				maxDosePerDayLabel.Text = MaxDosePerDay + " " + MaxDosePerDayUnity;
				obsLabel.Text = Obs;
			}
		}
		public DoseCell()
		{

			viaLabel = new Label() { }; 
			pedDoseLabel= new Label() { };

			adultDoseLabel= new Label() { }; 
			takesPerDayLabel = new Label() { }; 
			maxDosePerDayLabel = new Label() { }; 
			obsLabel= new Label() { };

			Grid grid = new Grid()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			grid.ColumnDefinitions.Add(new ColumnDefinition()
			{
				Width = new GridLength(1, GridUnitType.Star)
			});
			grid.ColumnDefinitions.Add(new ColumnDefinition()
			{
				Width = new GridLength(3, GridUnitType.Star)
			});

			var descriptionRowDefinition = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };

			grid.RowDefinitions.Add(descriptionRowDefinition);
			grid.RowDefinitions.Add(descriptionRowDefinition);


			grid.Children.Add(viaLabel, 0, 0);

			var pedDoseTitle = new Label() { Text = "Dose Pediátrica"};
			grid.Children.Add(pedDoseTitle, 0, 1);
			grid.Children.Add(pedDoseLabel, 1, 1);

			var adultDoseTitle = new Label() { Text = "Dose Adulto" };
			grid.Children.Add(adultDoseTitle, 0, 2);
			grid.Children.Add(adultDoseLabel, 1, 2);

			var takesTitle = new Label() { Text = "Tomas" };
			grid.Children.Add(takesTitle, 0, 3);
			grid.Children.Add(takesPerDayLabel, 1, 3);

			var maxDoseTitle = new Label() { Text = "Dose Máxima p/Dia" };
			grid.Children.Add(maxDoseTitle, 0, 4);
			grid.Children.Add(maxDosePerDayLabel, 1, 4);

			var obsTitle = new Label() { Text = "Observações" };
			grid.Children.Add(obsTitle, 0, 5);
			grid.Children.Add(obsLabel, 1, 5);

			View = grid;
		}
	}
}

