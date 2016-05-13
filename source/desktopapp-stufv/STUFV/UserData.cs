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
    class UserData
    {
        private static HttpClient client = new HttpClient();

        public static async Task<IEnumerable<User>> GetUsers()
        {
            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<User> users = null;

            try
            {
                var userUrl = "/api/user";
                HttpResponseMessage response = await client.GetAsync(userUrl);

                if (response.IsSuccessStatusCode)
                {
                    users = await response.Content.ReadAsAsync<IEnumerable<User>>();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return users;
        }
    }
}
