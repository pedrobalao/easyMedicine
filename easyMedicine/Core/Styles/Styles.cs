
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using easyMedicine.Pages;
using Xamarin.Forms;


namespace easyMedicine
{
    public class Styles
    {

        public static string Style_LabelSmallStyle = "LabelSmallStyle";
        public static string Style_LabelMediumStyle = "LabelMediumStyle";
        public static string Style_LabelSmallStyleNormal = "LabelSmallStyleNormal";

        //Preto esbatido
        public static string BASE_COLOR_HEX = "252628";
        public static Color BASE_COLOR = Color.FromHex(BASE_COLOR_HEX);
        //Cinzento
        public static Color LETTER_COLOR = Color.FromHex("666666");
        //Verde
        public static Color CONTRAST_LETTER_COLOR = Color.FromHex("698335");

        //Cinzento
        public static string PLACEHOLDER_COLOR_HEX = "CAC6BE";
        public static Color PLACEHOLDER_COLOR = Color.FromHex(PLACEHOLDER_COLOR_HEX);



        public static Color BLUE_COLOR = Color.FromHex("0078D7");
        public static Color LIGHT_BLUE_COLOR = Color.FromHex("3393DE");
        public static Color WHITE_COLOR = Color.White;
        public static Color GRAY_COLOR = Color.FromHex("666666");

        public static Color NEGATIVE_COLOR = Color.FromHex("651F06");



        public static string Style_MenuCellLabelStyle = "MenuCellLabelStyle";

        public static string Style_LabelContrastStyle = "LabelContrastStyle";

        public static string Style_LabelMediumBackgroundStyle = "LabelMediumBackgroundStyle";

        public static string Style_LabelIndincTitleStyle = "LabelIndincTitleStyle";
        public static string Style_LabelIndincValueStyle = "LabelIndincValueStyle";

        public static string Style_ButtonMediumNegStyle = "ButtonMediumNegStyle";

        public static string Style_VariablesEntryStyle = "VariablesEntryStyle";




#if __ANDROID__
        public const int SmallFontSize = 10;
#else 
        public const int SmallFontSize = 12;
#endif

        public const int SmallMediumFontSize = 14;
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
                        Property = Label.TextColorProperty, Value = LIGHT_BLUE_COLOR,
                    },
                    new Setter {
                        Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Start
                    },
                    new Setter {
                        Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.End
                    },
                    new Setter {
                        Property = Label.FontSizeProperty, Value = SmallFontSize
                    },
                }
            };

            var labelSmallStyleNormal = new Style(typeof(Label))
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
                        Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.End
                    },
                    new Setter {
                        Property = Label.FontSizeProperty, Value = SmallFontSize
                    },
                }
            };

            var labelMediumStyle = new Style(typeof(Label))
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
                        Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Start
                    },
                    new Setter {
                        Property = Label.FontSizeProperty, Value = MediumFontSize
                    },
                }
            };

            var labelIndincTitleStyle = new Style(typeof(Label))
            {
                BasedOn = labelContrastBaseStyle,
                Setters = {
                    new Setter {
                        Property = Label.TextColorProperty, Value = BLUE_COLOR,
                    },
                    new Setter {
                        Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Start
                    },
                    new Setter {
                        Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Start
                    },
                    new Setter {
                        Property = Label.FontSizeProperty, Value = SmallMediumFontSize
                    },
                }
            };

            var labelIndincValueStyle = new Style(typeof(Label))
            {
                BasedOn = labelContrastBaseStyle,
                Setters = {
                    new Setter {
                        Property = Label.TextColorProperty, Value = GRAY_COLOR,
                    },
                    new Setter {
                        Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Start
                    },
                    new Setter {
                        Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Start
                    },
                    new Setter {
                        Property = Label.FontSizeProperty, Value = SmallMediumFontSize
                    },
                }
            };


            var labelMediumBackgroundStyle = new Style(typeof(Label))
            {
                BasedOn = labelContrastBaseStyle,
                Setters = {
                    new Setter {
                        Property = Label.TextColorProperty, Value = WHITE_COLOR,
                    },
                    new Setter {
                        Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Start
                    },
                    new Setter {
                        Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Center
                    },
                    new Setter {
                        Property = Label.BackgroundColorProperty, Value = BLUE_COLOR,
                    },
                    new Setter {
                        Property = Label.FontSizeProperty, Value = SmallMediumFontSize
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
                        Property = SearchBar.PlaceholderColorProperty, Value =  BASE_COLOR
                    },
                    new Setter {
                        Property = SearchBar.FontAttributesProperty, Value = FontAttributes.None
                    },
                    new Setter {
                        Property = SearchBar.FontFamilyProperty, Value = "Avenir-Book"
                    },
                    new Setter {
                        Property = SearchBar.TextColorProperty, Value = WHITE_COLOR
                    },
                    new Setter {
                        Property = SearchBar.FontAttributesProperty, Value = FontAttributes.Bold
                    },
                    new Setter {
                        Property = SearchBar.FontSizeProperty, Value = SmallMediumFontSize
                    },
                    new Setter {
                        Property = SearchBar.BackgroundColorProperty, Value = BLUE_COLOR,
                    },
                    new Setter {
                        Property = SearchBar.CancelButtonColorProperty, Value = WHITE_COLOR,
                    },

                }
            };


            var navigationBarStyle = new Style(typeof(eMNavigationPage))
            {
                Setters = {
                    new Setter {
                        Property = NavigationPage.BarTextColorProperty, Value = WHITE_COLOR,
                    },
                    new Setter {
                        Property = NavigationPage.BarBackgroundColorProperty, Value = BLUE_COLOR,
                    },
                    new Setter {
                        Property = NavigationPage.BackButtonTitleProperty, Value = "",
                    },

                }
            };

            var buttonMediumLargeStyle = new Style(typeof(Button))
            {
                BasedOn = baseStyle,
                Setters = {
                    new Setter {
                        Property = Button.TextColorProperty, Value =Color.White
                    },

                    new Setter {
                        Property = Button.FontSizeProperty, Value = MediumFontSize
                    },
                    new Setter {
                        Property = Button.BackgroundColorProperty, Value =  CONTRAST_LETTER_COLOR//Color.White
                    },
                    //new Setter {
                    //    Property = Button.FontFamilyProperty, Value = "Bebas Neue"
                    //},
                    new Setter {
                        Property = Button.BorderWidthProperty, Value = 1
                    },
                    new Setter {
                        Property = Button.BorderColorProperty, Value = CONTRAST_LETTER_COLOR
                    },
                    new Setter {
                        Property = Button.BorderRadiusProperty, Value = /*(Device.OS == TargetPlatform.iOS) ?*/ 0// : 45
                    },

                }
            };

            var buttonMediumLargeNegStyle = new Style(typeof(Button))
            {
                BasedOn = buttonMediumLargeStyle,
                Setters = {
                    new Setter {
                        Property = Button.BackgroundColorProperty, Value =  NEGATIVE_COLOR//Color.White
                    },
                    new Setter {
                        Property = Button.BorderColorProperty, Value = NEGATIVE_COLOR
                    },
                }
            };


            /*
			var tabbedPageStyle = new Style(typeof(TabbedPage))
			{
				Setters = {
					new Setter {
						Property = TabbedPage.BackgroundImageProperty, Value = BLUE_COLOR// BASE_COLOR= BASE_COLOR,
					},

				}
			};*/


            var listViewStyle = new Style(typeof(ListView))
            {
                Setters = {
                    new Setter {
                        Property = ListView.BackgroundColorProperty, Value = Color.Transparent
                    }
                }
            };


            var entryStyle = new Style(typeof(Entry))
            {
                Setters = {
                    new Setter {
                        Property = Entry.FontFamilyProperty, Value = "Avenir-Book"
                    },
                    new Setter {
                        Property = Entry.PlaceholderColorProperty, Value = PLACEHOLDER_COLOR
                    },
                }
            };
            Application.Current.Resources.Add(entryStyle);

            var variablesEntryStyle = new Style(typeof(Entry))
            {
                BasedOn = entryStyle,
                Setters = {
                    new Setter {
                        Property = Button.BackgroundColorProperty, Value =  BLUE_COLOR//Color.White
                    },
                    new Setter {
                        Property = Button.TextColorProperty, Value = WHITE_COLOR
                    },
                }
            };
            Application.Current.Resources.Add(Style_VariablesEntryStyle, variablesEntryStyle);

            /*Application.Current.Resources.Add (stackLayoutStyle);
            Application.Current.Resources.Add (relativeLayoutStyle);*/
            Application.Current.Resources.Add(baseStyle);
            Application.Current.Resources.Add(baseLayoutStyle);
            Application.Current.Resources.Add(navigationBarStyle);
            Application.Current.Resources.Add(listViewStyle);
            Application.Current.Resources.Add(searchBarStyle);
            Application.Current.Resources.Add(tableViewStyle);

            //Application.Current.Resources.Add(tabbedPageStyle);




            Application.Current.Resources.Add(labelSmallStyle);

            //Specific Styles

            Application.Current.Resources.Add(Style_LabelSmallStyle, labelSmallStyle);
            Application.Current.Resources.Add(Style_LabelSmallStyleNormal, labelSmallStyleNormal);
            Application.Current.Resources.Add(Style_LabelMediumStyle, labelMediumStyle);
            Application.Current.Resources.Add(Style_LabelMediumBackgroundStyle, labelMediumBackgroundStyle);
            Application.Current.Resources.Add(Style_LabelIndincTitleStyle, labelIndincTitleStyle);
            Application.Current.Resources.Add(Style_LabelIndincValueStyle, labelIndincValueStyle);
            Application.Current.Resources.Add(Style_ButtonMediumNegStyle, buttonMediumLargeNegStyle);









        }
    }
}


