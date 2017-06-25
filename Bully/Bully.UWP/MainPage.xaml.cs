using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NotificationsExtensions;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using NotificationsExtensions.Tiles;
using Windows.Data.Xml.Dom;
using Syncfusion.SfPdfViewer.XForms.UWP;

namespace Bully.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new Bully.App());
            new SfPdfDocumentViewRenderer();
            //this.TileAsync();
        }

        private async System.Threading.Tasks.Task TileAsync()
        {

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    Branding = TileBranding.Logo,
                    DisplayName = "Acceso directo",
                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                                  {
                                        new AdaptiveText() { Text = "Small" }
                                  }
                        }
                    },

                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText() { Text = "Medium" }
                }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText() { Text = "Wide" }
                }
                        }
                    },

                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText() { Text = "Large" }
                }
                        }
                    }
                }
            };

            SecondaryTile tile = new SecondaryTile("SecondaryTile", "Example", "args", new Uri("ms-appx:///Logo.png"), TileSize.Default);
            tile.VisualElements.ShowNameOnSquare150x150Logo = true;
            tile.VisualElements.ShowNameOnSquare310x310Logo = true;
            tile.VisualElements.ShowNameOnWide310x150Logo = true;
            tile.VisualElements.BackgroundColor = Colors.Transparent;
            await tile.RequestCreateAsync();


            TileUpdateManager.CreateTileUpdaterForApplication("Tile").Update(new TileNotification(content.GetXml()));

            //nuevo ejemplo




        }
    }
}
