using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace STUFV
{
    class ReviewData
    {
        private static HttpClient client = new HttpClient();

        public static async Task<IEnumerable<Review>> GetReviews()
        {
            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Review> reviews = null;
            var reviewUrl = "/api/reviews";
            HttpResponseMessage response = await client.GetAsync(reviewUrl);

            if (response.IsSuccessStatusCode)
            {
                reviews = await response.Content.ReadAsAsync<IEnumerable<Review>>();
            }

            return reviews;
        }
    }
}
