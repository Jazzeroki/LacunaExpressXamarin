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
        public static ResourceDictionary StyleDictionary = new ResourceDictionary
        {
            {"buttonStyle", new Style(typeof(Button))
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

            {"buttonWhiteText", new Style(typeof(Button))
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
            {"buttonOrangeText", new Style(typeof(Button))
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

            {"labelWhiteText", new Style(typeof(Label))
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

            {"labelOrangeText", new Style(typeof(Label))
                { Setters ={
                    new Setter
                    {

                        Property = Label.BackgroundColorProperty,
                        Value = Color.Transparent
                    },
                    new Setter
                    {
                        Property = Label.TextColorProperty,
                        Value = Color.FromHex("#ECC80F")
                    },
                }
            }
            },

			{"labelBlackText", new Style(typeof(Label))
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

			{"backgroundStyle", new Style(typeof(Page))
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
