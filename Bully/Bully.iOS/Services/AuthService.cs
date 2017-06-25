using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using UIKit;
using Bully.Services;
using Xamarin.Forms;
using Bully.Services.Auth;
using Bully.iOS.Services;
using Bully.Helpers;
using System;
using System.Collections.Generic;

[assembly: Dependency(typeof(AuthService))]
namespace Bully.iOS.Services
{
    public class AuthService : IAuthService
    {


        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> paramenter = null)
        {
            try
            {
                var current = GetController();
                var user = await client.LoginAsync(current, provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private UIKit.UIViewController GetController()
        {
            var windows = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = windows.RootViewController;

            if (root == null) return null;

            var current = root;
            while (current.PresentedViewController != null)
            {
                current = current.PresentedViewController;
            }

            return current;

        }
    }
}