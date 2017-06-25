using Bully.Interfaces.Navigation;
using Bully.ViewModels.Base;
using Bully.Views.Main;
using Bully.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
namespace Bully
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainView());
            //MainPage = new NavigationPage(new LoginView());
        }

        protected override async void OnStart()
        {
            base.OnStart();
            MobileCenter.Start(
                Constants.GlobalSettings.MobileCenterUwp + 
                Constants.GlobalSettings.MobileCenterAndroid +
                Constants.GlobalSettings.MobileCenterIos,
                typeof(Analytics), typeof(Crashes));
            await InitNavigation();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
