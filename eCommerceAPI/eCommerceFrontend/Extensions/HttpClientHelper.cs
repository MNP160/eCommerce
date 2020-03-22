using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eCommerceFrontend.Utility
{
    public static class HttpClientHelper
    {
        public static HttpClient GetJwt(this HttpClient client, string token)
        {
            if (eCommerceFrontend.Utility.AppContext.Current.Session.Get<string>(token) != null)
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", eCommerceFrontend.Utility.AppContext.Current.Session.Get<string>(token));
            }
            return client;
        }

        public static bool IsLoggedIn(string token="token")
        {
            if (eCommerceFrontend.Utility.AppContext.Current.Session.Get<string>(token) != null)
            {
                return true;
            }

            return false;
        }

    }
  
}
