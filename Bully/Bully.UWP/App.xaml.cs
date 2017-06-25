﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.Networking.PushNotifications;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.Messaging;
using Windows.UI.Popups;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Plugin.Connectivity;
using System.Reflection;
using Syncfusion.SfPdfViewer.XForms.UWP;

namespace Bully.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                List<Assembly> assembliesToInclude = new List<Assembly>();

                //Now, add in all the assemblies your app uses  
                assembliesToInclude.Add(typeof(SfPdfDocumentViewRenderer).GetTypeInfo().Assembly);

                //Also do this for all your other 3rd party libraries  

                Xamarin.Forms.Forms.Init(e, assembliesToInclude);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
            //await InitNotificationsAsync();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private async Task InitNotificationsAsync()
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                return;
            }
            /*
            var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            // TODO add connection string here
            var hub = new NotificationHub("acceso_directo_push", "Endpoint=sb://accesodirecto.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=TRODUg/wbzfky0j3DVXPcbB6RUwwpy7Zokgq6L6FwoQ=");
            var result = await hub.RegisterNativeAsync(channel.Uri);

            // Displays the registration ID so you know it was successful
            if (result.RegistrationId != null)
            {
                //Settings.DeviceToken = result.RegistrationId;
            }
            */


            /*
             * parte 2 comentada
            var channel = await PushNotificationChannelManager
 .CreatePushNotificationChannelForApplicationAsync();
            const string templateBodyWNS =
            "<toast><visual><binding template=\"ToastText01\"><text id =\"1\">$(messageParam)</text></binding></visual></toast>";
            JObject headers = new JObject();
            headers["X-WNS-Type"] = "wns/toast";
            JObject templates = new JObject();
            templates["genericMessage"] = new JObject
 {
 {"body", templateBodyWNS},
 {"headers", headers} // Needed for WNS.
 };
            MobileServiceClient client = new MobileServiceClient(Constants.GlobalSettings.AzureUrl);
            await client.GetPush()
            .RegisterAsync(channel.Uri, templates);

    */


            var channel = await PushNotificationChannelManager
            .CreatePushNotificationChannelForApplicationAsync();

            const string templateBodyWNS =
            "<toast><visual><binding template=\"ToastText01\"><text id=\"1\">$(messageParam)</text></binding></visual></toast>";

            JObject headers = new JObject();
            headers["X-WNS-Type"] = "wns/toast";

            JObject templates = new JObject();
            templates["genericMessage"] = new JObject
            {
                { "body", templateBodyWNS},
                {"headers", headers}
            };

           // await MobileService.Instance.Client.GetPush()
            //.RegisterAsync(channel.Uri, templates);

            //MobileServiceClient client = new MobileServiceClient(Uri.EscapeUriString(Constants.GlobalSettings.AzureUrl));
            //await client.GetPush()
            //.RegisterAsync(Uri.EscapeUriString(channel.Uri), templates);
            
            //Uri.EscapeUriString(channel.Uri)
        }
    }
}
