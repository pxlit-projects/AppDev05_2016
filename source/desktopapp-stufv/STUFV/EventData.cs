using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace STUFV
{
    class EventData
    {
        private static HttpClient client = new HttpClient();

        public static async Task<IEnumerable<Event>> GetEvents()
        {
            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Event> events = null;
            var eventUrl = "/api/event";
            HttpResponseMessage response = await client.GetAsync(eventUrl);

            if (response.IsSuccessStatusCode)
            {
                events = await response.Content.ReadAsAsync<IEnumerable<Event>>();
            }
            return events;
        }
    }
}
