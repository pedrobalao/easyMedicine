
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Xamarin.Forms;


	namespace easyMedicine
	{
		public class Styles
		{

			public static string Style_LabelSmallStyle = "LabelSmallStyle";

			//Preto esbatido
			public static Color BASE_COLOR = Color.FromHex("252628");
			//Cinzento
			public static Color LETTER_COLOR = Color.FromHex("666666");
			//Verde
			public static Color CONTRAST_LETTER_COLOR = Color.FromHex("698335");

			public static string Style_MenuCellLabelStyle = "MenuCellLabelStyle";

			public static string Style_LabelContrastStyle = "LabelContrastStyle";


			public static string Style_LabelSmallContrastStyleCenter = "LabelSmallContrastStyleCenter";
			public static string Style_LabelSmallBaseStyleCenter = "LabelSmallBaseStyleCenter";

			public static string Style_LabelMediumLargeContrastStyleRight = "LabelMediumLargeContrastStyleRight";
			public static string Style_LabelMediumLargeContrastStyleCenter = "LabelMediumLargeContrastStyleCenter";
			public static string Style_LabelMediumLargeContrastStyleLeft = "LabelMediumLargeContrastStyleLeft";

			public static string Style_LabelMediumContrastStyleRight = "LabelMediumContrastStyleRight";
			public static string Style_LabelMediumContrastStyleCenter = "LabelMediumContrastStyleCenter";
			public static string Style_LabelMediumContrastStyleLeft = "LabelMediumContrastStyleLeft";

			public static string Style_LabelMediumBaseStyleRight = "LabelMediumBaseStyleRight";
			public static string Style_LabelMediumBaseStyleCenter = "LabelMediumBaseStyleCenter";
			public static string Style_LabelMediumBaseStyleLeft = "LabelMediumBaseStyleLeft";

			
			public static string Style_LabelLargeBaseStyleLeft = "LabelLargeBaseStyleLeft";

			public static string Style_LabelLargeBaseStyleCenter = "LabelLargeBaseStyleCenter";

			public static string Style_BoxSplitLineStyle = "BoxSplitLineStyle";

			public static string Style_ButtonMediumStyle = "ButtonMediumStyle";

			public static string Style_ButtonSmallWhiteStyle = "ButtonSmallWhiteStyle";
			public static string Style_ButtonSmallWhiteTransparentStyle = "ButtonSmallWhiteTransparentStyle";

			public static string Style_FrameContrastColor = "FrameContrastColor";
			public static string Style_FrameLetterColor = "FrameLetterColor";




			public const int SmallFontSize = 14;
			public const int MediumFontSize = 18;
			public const int MediumLargeFontSize = 25;
			public const int LargeFontSize = 35;
			//@TODO Font Size
			//https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/Samples/XLabs.Sample/Pages/Services/FontManagerPage.cs
			//https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/src/Forms/XLabs.Forms.Droid/Services/FontManager.cs
			//https://forums.xamarin.com/discussion/24420/font-size-best-practices

			public static void LoadStyles()
			{
				Application.Current.Resources = new ResourceDictionary();
				
				var baseStyle = new Style(typeof(View))
				{
					Setters = {
						new Setter {
							Property = View.BackgroundColorProperty, Value = Color.Transparent
						}

					}
				};

				var labelContrastBaseStyle = new Style(typeof(Label))
				{
					BasedOn = baseStyle,
					Setters = {
					new Setter {
						Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Center
					},
					new Setter {
						Property = Label.FontFamilyProperty, Value = "Avenir-Book"
					},
					new Setter {
						Property = Label.TextColorProperty, Value = CONTRAST_LETTER_COLOR
					},
					new Setter {
						Property = Label.FontAttributesProperty, Value = FontAttributes.Bold
					}

				}
				};

			var labelSmallStyle = new Style(typeof(Label))
				{
					BasedOn = labelContrastBaseStyle,
					Setters = {
					new Setter {
						Property = Label.TextColorProperty, Value = LETTER_COLOR,
					},
					new Setter {
						Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Start
					},
					new Setter {
						Property = Label.FontSizeProperty, Value = SmallFontSize
					},
				}
				};

				

				var baseLayoutStyle = new Style(typeof(Layout))
				{
					Setters = {
					new Setter {
						Property = Layout.BackgroundColorProperty, Value = Color.White
					}

				}
				};

				

				var tableViewStyle = new Style(typeof(TableView))
				{
					BasedOn = baseStyle,
				};

				
				var searchBarStyle = new Style(typeof(SearchBar))
				{
					BasedOn = baseStyle,
					Setters = {
					new Setter {
						Property = SearchBar.PlaceholderColorProperty, Value = LETTER_COLOR// BASE_COLOR
					},
					new Setter {
						Property = SearchBar.FontAttributesProperty, Value = FontAttributes.None
					},
					new Setter {
						Property = SearchBar.FontFamilyProperty, Value = "Avenir-Book"
					},
					new Setter {
						Property = SearchBar.TextColorProperty, Value = CONTRAST_LETTER_COLOR
					},
					new Setter {
						Property = SearchBar.FontAttributesProperty, Value = FontAttributes.Bold
					},
					new Setter {
						Property = SearchBar.FontSizeProperty, Value = MediumFontSize
					}
				}
				};

				var navigationBarStyle = new Style(typeof(NavigationPage))
				{
					Setters = {
					new Setter {
						Property = NavigationPage.BarBackgroundColorProperty, Value = Color.Transparent// BASE_COLOR= BASE_COLOR,
					},
					new Setter {
						Property = NavigationPage.BarTextColorProperty, Value = CONTRAST_LETTER_COLOR,
					},

				}
				};

				var listViewStyle = new Style(typeof(ListView))
				{
					Setters = {
					new Setter {
						Property = ListView.BackgroundColorProperty, Value = Color.Transparent
					}
				}
				};

				


				/*Application.Current.Resources.Add (stackLayoutStyle);
				Application.Current.Resources.Add (relativeLayoutStyle);*/
				Application.Current.Resources.Add(baseStyle);
				Application.Current.Resources.Add(baseLayoutStyle);
				Application.Current.Resources.Add(navigationBarStyle);
				Application.Current.Resources.Add(listViewStyle);
				Application.Current.Resources.Add(searchBarStyle);
				Application.Current.Resources.Add(tableViewStyle);



				Application.Current.Resources.Add(labelSmallStyle);

				//Specific Styles
				
				Application.Current.Resources.Add(Style_LabelSmallStyle, labelSmallStyle);
				

				

			}
		}
	}


