using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Dita.Web.Services
{
    public class ContentfulService : IContentfulService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ContentfulService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<string> Fetch(string query)
        {
            var token = _configuration.GetSection("Contentful")["AccessToken"];
            var url = _configuration.GetSection("Contentful")["Url"];
            var spaceId = _configuration.GetSection("Contentful")["SpaceId"];
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url + spaceId),
                Method = HttpMethod.Post,
            };

            request.Headers.Add("Authorization", "Bearer " + token);
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(JsonConvert.SerializeObject(new ContentfulQuery() { Query = query }));
            request.Content.Headers.ContentType.MediaType = "application/json";
            var res = await client.SendAsync(request);
            var resString = await res.Content.ReadAsStringAsync();
            return resString;
        }
        public async Task<string> FetchQueryFromArticleDita()
        {
            string query = @"{
                pageObjectCollection(where:{ code: ""article-dita""}){
                    items{
                        graphQl
                    }
                }
            }";
            var resString = await Fetch(query);
            var res = JsonConvert.DeserializeObject<ContentfulPageObject>(resString);
            return res?.Data?.PageObjectCollection.Items?.First()?.GraphQl;
        }
    }
}
