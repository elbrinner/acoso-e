using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.Services.Auth
{
    public interface IAuthService
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider , IDictionary<string,string> paramenter = null);
    }
}
