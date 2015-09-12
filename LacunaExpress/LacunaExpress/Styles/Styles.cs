using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpress.Styles
{
    public class Styles
    {
        public enum StyleName
        {
            MainLayout,RegularButton, buttonStyle, buttonWhiteText, buttonBlackText, labelWhiteText, labelBlackText, backgroundStyle
        }
        public static ResourceDictionary StyleDictionary = new ResourceDictionary
        {
			{StyleName.MainLayout.ToString(), new Style(typeof(StackLayout))
				{ Setters ={
					new Setter
					{
						Property = StackLayout.BackgroundColorProperty,
						Value = Color.FromRgb (0, 0, 128)
					},
					new Setter
					{
						Property = StackLayout.PaddingProperty,
						Value = new Thickness(5)
					},
					
				}
			}
			},
			{StyleName.RegularButton.ToString(), new Style(typeof(Button))
                { Setters ={
                    new Setter
                    {
                        Property = Button.BackgroundColorProperty,
                        Value = Color.Blue
                    },
                    new Setter
                    {
                        Property = Button.TextColorProperty,
                        Value = Color.White
                    },
                    new Setter
                    {
                        Property = Button.BorderWidthProperty,
                        Value = 2
                    },
                    new Setter
                    {
                        Property = Button.BorderColorProperty,
                        Value = Color.White
                    },
                    new Setter
                    {
                        Property = Button.FontAttributesProperty,
                        Value = FontAttributes.Bold
                    },
                }
            }
            },
            {StyleName.buttonStyle.ToString(), new Style(typeof(Button))
                { Setters ={
                    new Setter
                    {

                        Property = Button.BackgroundColorProperty,
                        Value = Color.Transparent
                    },
                    new Setter
                    {
                        Property = Button.TextColorProperty,
                        Value = Color.FromHex("#ECC80F")
                    },
                }
            }
            },

            {StyleName.buttonWhiteText.ToString(), new Style(typeof(Button))
                { Setters ={
                    new Setter
                    {

                        Property = Button.BackgroundColorProperty,
                        Value = Color.Transparent
                    },
                    new Setter
                    {
                        Property = Button.TextColorProperty,
                        Value = Color.White
                    },
                }
            }
            },
			{StyleName.buttonBlackText.ToString(), new Style(typeof(Button))
				{ Setters ={
						new Setter
						{

							Property = Button.BackgroundColorProperty,
							Value = Color.Transparent
						},
						new Setter
						{
							Property = Button.TextColorProperty,
							Value = Color.Black
						},
					}
				}
			},

			{StyleName.labelWhiteText.ToString(), new Style(typeof(Label))
				{ Setters ={
						new Setter
						{

							Property = Button.BackgroundColorProperty,
							Value = Color.Transparent
						},
						new Setter
						{
							Property = Button.TextColorProperty,
							Value = Color.White
						},
					}
				}
			},

			{StyleName.labelBlackText.ToString(), new Style(typeof(Label))
				{ Setters ={
						new Setter
						{

							Property = Label.BackgroundColorProperty,
							Value = Color.Transparent
						},
						new Setter
						{
							Property = Label.TextColorProperty,
							Value = Color.Black
						},
					}
				}
			},

			{StyleName.backgroundStyle.ToString(), new Style(typeof(StackLayout))
				{ Setters ={
					new Setter
					{
						Property = Page.BackgroundColorProperty,
						Value = Color.FromHex("#000080")
					},
				}
			}
			}
        };
    }
}
