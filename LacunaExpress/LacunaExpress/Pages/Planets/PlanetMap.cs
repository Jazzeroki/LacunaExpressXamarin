using LacunaExpanseAPIWrapper;
using LacunaExpanseAPIWrapper.ParamsModels;
using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages.Planets
{
    public class PlanetMap : ContentPage
    {
        Grid grid = new Grid
        {
			BackgroundColor = Color.FromRgb (0, 0, 128),
            VerticalOptions = LayoutOptions.FillAndExpand,
            RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                },
            ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                }
        };

        string planetID;
        Label planetlbl = new Label { XAlign = TextAlignment.Center };
        Label tempPlanetBuildingName = new Label();
        Label tempPlanetBuildingLevel = new Label();
        Image tempBuildingImage = new Image();
        StackLayout OuterBuilding = new StackLayout { Orientation = StackOrientation.Horizontal };
        StackLayout InnerBuilding = new StackLayout { Orientation = StackOrientation.Vertical };
        //List<BuildingArrangementModel> BuildingArrangements = new List<BuildingArrangementModel>();
        BuildingImage selectedBuilding = new BuildingImage();
        BuildingImage tempHolding = new BuildingImage();

        Image selectedBuildingImage = new Image();
        Label selectedBuildingName = new Label();
        List<BuildingImage> buildingImages = new List<BuildingImage>();

        Button submitArrangement = new Button{
            Text = "Submit",
			Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()]
        };
        public PlanetMap(AccountModel account, string planetName)
        {
            OuterBuilding.Children.Add(tempBuildingImage);
            OuterBuilding.Children.Add(InnerBuilding);
            InnerBuilding.Children.Add(tempPlanetBuildingName);
            InnerBuilding.Children.Add(tempPlanetBuildingLevel);
            OuterBuilding.Children.Add(submitArrangement);

            planetlbl.Text = planetName;
            ScrollView scrollMap = new ScrollView
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Horizontal,

                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                                     grid
                                },                    
                }
            };
            int left = 0;
            int top = 1;
            int xcounter = -5;
            int ycounter = 5;
            for (int i = 0; i <= 120; i++)
            {
                var b = new BuildingImage { PLOTNUMBER = i, x = Convert.ToString(xcounter), y = Convert.ToString(ycounter), Source = ImageSource.FromResource("LacunaExpress.Images.Demolish.png") };
                xcounter++;
                if(xcounter > 5)
                {
                    xcounter = -5;
                    ycounter--;
                }
                //b.buildingImage.Source = ImageSource.FromResource("LacunaExpress.Images.Demolish.png");
                b.GestureRecognizers.Add((new TapGestureRecognizer
                {
                    Command = new Command(o =>
                    {
                        
                        var index = b.PLOTNUMBER;
                        if(index != 60) //that's the center building of the map and it's not allowed to move
                        {
                            if (selectedBuilding.name.Length > 0)
                            {
                                tempHolding.id = selectedBuilding.id;
                                tempHolding.imageString = selectedBuilding.imageString;
                                tempHolding.level = selectedBuilding.level;
                                tempHolding.name = selectedBuilding.name;

                                selectedBuilding.id = "";
                                selectedBuilding.imageString = "";
                                selectedBuilding.level = "";
                                selectedBuilding.name = "";

                                tempPlanetBuildingName.Text = "No Building Selected";
                                tempPlanetBuildingLevel.Text = "0";
                                tempBuildingImage.Source = null;
                                tempBuildingImage.Source = ImageSource.FromResource("LacunaExpress.Images.Demolish.png");
                            }
                            if (buildingImages[index].name.Length > 0)
                            {
                                selectedBuilding.id = buildingImages[index].id;
                                selectedBuilding.imageString = buildingImages[index].imageString;
                                selectedBuilding.level = buildingImages[index].level;
                                selectedBuilding.name = buildingImages[index].name;

                                buildingImages[index].Source = null;
                                buildingImages[index].Source = ImageSource.FromResource("LacunaExpress.Images.Demolish.png");
                                buildingImages[index].name = "";
                                buildingImages[index].level = "";
                                buildingImages[index].imageString = "";
                                buildingImages[index].id = "";

                                tempPlanetBuildingName.Text = selectedBuilding.name;
                                tempPlanetBuildingLevel.Text = selectedBuilding.level;
                                tempBuildingImage.Source = ImageSource.FromResource(selectedBuilding.imageString);
                            }

                            if (tempHolding.name.Length > 0)
                            {
                                buildingImages[index].level = tempHolding.level;
                                buildingImages[index].name = tempHolding.name;
                                buildingImages[index].id = tempHolding.id;
                                buildingImages[index].imageString = tempHolding.imageString;
                                buildingImages[index].Source = ImageSource.FromResource(tempHolding.imageString);

                                tempHolding.id = "";
                                tempHolding.imageString = "";
                                tempHolding.level = "";
                                tempHolding.x = "";
                                tempHolding.y = "";
                                tempHolding.name = "";
                            }
                        }
                        //SwapBuildings(b.PLOTNUMBER);
                        

                    })
                }));
                buildingImages.Add(b);
                grid.Children.Add(b, left, top);
                left++;
                
                if (left == 11)
                {
                    left = 0;
                    top++;
                }
            }

			var mainLayout = new StackLayout
            {
                Children = {
                    planetlbl,
                    scrollMap,
                    OuterBuilding
                }

            };

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}

            this.Appearing += (sender, e) =>
            {

                planetID = (from b in account.Colonies
                            where b.Value.Equals(planetName)
                            select b.Key).First();
                LoadBuildingsAsync(account, planetID);
            };
            submitArrangement.Clicked += async (sender, e) =>
            {
                List<BuildingArrangement> movedBuildings = new List<BuildingArrangement>();
                foreach(var b in buildingImages)
                {
                    if(b.name.Length > 0)
                    {
                        movedBuildings.Add(new BuildingArrangement(b.x, b.y, b.id));
                        
                    }
                }
                string json = Body.RearrangeBuildings(1, account.SessionID, planetID, movedBuildings);
                var server = new Data.Server();
                string response = await server.GetHttpResultStringAsyncAsString(account.Server, Body.url, json);
                string s = response;
            };

        }

        async void LoadBuildingsAsync(AccountModel account, string bodyID)
        {
            var json = Body.GetBuildings(1, account.SessionID, bodyID);
            var s = new LacunaExpress.Data.Server();
            var response = await s.GetHttpResultAsync(account.Server, Body.url, json);
            if (response.result != null)
            {
                


                foreach (var bd in response.result.buildings.OrderBy(x => x.Value.name))
                {
                    //var imageUri = new Uri(("https://raw.githubusercontent.com/plainblack/Lacuna-Assets/master/planet_side/100/"+bd.Value.image+".png"));
                    var imageUri = "LacunaExpress.Images.100." + bd.Value.image + ".png";
                    int index = 11 * (5 - Convert.ToInt16(bd.Value.y)) + Convert.ToInt16(bd.Value.x) + 5;
                    buildingImages[index].Source = ImageSource.FromResource("LacunaExpress.Images.SizeTwo." + bd.Value.image + ".png");
                    buildingImages[index].imageString = "LacunaExpress.Images.SizeTwo." + bd.Value.image + ".png";
                    //buildingImages[index].x = bd.Value.x;
                   // buildingImages[index].y = bd.Value.y;
                    buildingImages[index].name = bd.Value.name;
                    buildingImages[index].level = bd.Value.level;
                    buildingImages[index].id = bd.Key;
                    //var imgIndex = (from bi in buildingImages
                    //                    where bi.PLOTNUMBER == index
                    //                    select bi).First();
                    //    imgIndex.buildingImage.Source = ImageSource.FromResource("LacunaExpress.Images.SizeTwo." + bd.Value.image + ".png");

                    //var x = Convert.ToInt16(bd.Value.x) + 5;
                   // var y = (Convert.ToInt16(bd.Value.y) + -6) * -1;
                    //var img = new Image();
                    //img.Source = ImageSource.FromResource("LacunaExpress.Images.SizeTwo." + bd.Value.image + ".png");
                    //grid.Children.Add(img, x, y);
                    //BuildingArrangements.Add(new BuildingArrangementModel
                    //{
                    //    BuildingID = bd.Key,
                    //    BuildingName = bd.Value.name,
                    //    BuildingLevel = bd.Value.name,
                    //    BuildingImageString = imageUri,
                    //    X = bd.Value.x,
                    //    Y = bd.Value.y,
                    //    GridLeft = x,
                    //    GridTop = y
                    //});
                }

            }
        }
        void SwapBuildings(int index)
        {
            
            if (selectedBuilding.name.Length > 0)
            {
                tempHolding = selectedBuilding;
                selectedBuilding = null;
                tempPlanetBuildingName.Text = "";
                tempPlanetBuildingLevel.Text = "";
                tempBuildingImage.Source = null;
            }
            if (buildingImages[index].name.Length > 0)
            {
                selectedBuilding = buildingImages[index];
                buildingImages[index].Source = null;
                tempPlanetBuildingName.Text = selectedBuilding.name;
                tempPlanetBuildingLevel.Text = selectedBuilding.level;
                tempBuildingImage.Source = ImageSource.FromResource(selectedBuilding.imageString);
            }
            
            if(tempHolding.name.Length > 0)
            {
                buildingImages[index].level = tempHolding.level;
                buildingImages[index].x = tempHolding.x;
                buildingImages[index].y = tempHolding.y;
                buildingImages[index].name = tempHolding.name;
                buildingImages[index].id = tempHolding.id;
                buildingImages[index].imageString = tempHolding.imageString;
                buildingImages[index].Source = ImageSource.FromResource(tempHolding.imageString);

                tempHolding = null;
            }                    
        }
    }
    public class BuildingImage : Image
    {
        public BuildingImage()
        {
            PLOTNUMBER = 0;
            x = "";
            y = "";
            imageString = "";
            level = "";
            id = "";
            name = "";
        }
        public int PLOTNUMBER { get; set; }
        public string x, y, imageString, level, id, name;
    }

    

}



//public class BuildingArrangementModel
//{
//    public string BuildingID { get; set; }
//    public string BuildingName { get; set; }
//    public string BuildingLevel { get; set; }
//    public string BuildingUrl { get; set; }
//    public string BuildingImageString { get; set; }
//    public string X { get; set; }
//    public string Y { get; set; }
//    public string Index { get; set; }
//    public int GridLeft { get; set; }
//    public int GridTop { get; set; }
//}
/*
 * .GestureRecognizers.Add((new TapGestureRecognizer
        {
            Command = new Command(o =>
            {
                Device.OpenUri(new Uri("http://www.mindfiretechnology.com"));
            })
        }));
 */

