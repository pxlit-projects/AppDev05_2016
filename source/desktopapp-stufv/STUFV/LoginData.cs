using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace STUFV
{
    class LoginData
    {
        private static HttpClient client = new HttpClient();

        public static async Task<IEnumerable<Login>> GetLogins()
        {
            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Login> logins = null;
            var loginUrl = "/api/login";
            HttpResponseMessage response = await client.GetAsync(loginUrl);

            if (response.IsSuccessStatusCode)
            {
                logins = await response.Content.ReadAsAsync<IEnumerable<Login>>();
            }
            return logins;
        }

        public static async void InsertLogin(Login login)
        {
            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var loginUrl = "/api/login";
            HttpResponseMessage response = await client.PostAsJsonAsync(loginUrl, login);
        }
    }
}
