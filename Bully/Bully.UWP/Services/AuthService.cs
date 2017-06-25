using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Bully.Services;
using Xamarin.Forms;
using Bully.UWP.Services;
using Bully.Services.Auth;
using System;
using System.Collections.Generic;
using Bully.Helpers;

[assembly: Dependency(typeof(AuthService))]
namespace Bully.UWP.Services
{
    public class AuthService : IAuthService
    {

        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> paramenter = null)
        {
            try
            {
                var user = await client.LoginAsync(provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }

    }
}