using Bully.Constants;
using Bully.Helpers;
using Bully.Services.Auth;
using Bully.Services.Facade;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]
namespace Bully.Services.Facade
{
    public class AzureService
    {
        public MobileServiceClient Client { get; set; } = null;

        public static bool UserAuth  { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(GlobalSettings.AzureUrl);
            
            if(!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthService>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if(user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error","Login falla", "Ok");
                });

                return false;
            }
            else
            {
                Settings.AuthToken = user?.MobileServiceAuthenticationToken;
                Settings.UserId = user?.UserId;
            }

            return true;

        }
    }
}
