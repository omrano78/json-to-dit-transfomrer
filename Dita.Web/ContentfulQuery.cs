
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dita.Web
{
    public class ContentfulQuery
    {
        [JsonProperty("query")]
        public string Query { get; set; }
    }
    public class ContentfulPageObject
    {
        [JsonProperty("data")]
        public ContentfulPageObjectCollection Data { get; set; }
    }
    public class ContentfulPageObjectCollection
    {
        [JsonProperty("pageObjectCollection")]
        public PageObjectData PageObjectCollection { get; set; }
    }
    public class PageObjectData
    {
        [JsonProperty("items")]
        public List<PageObjectItem> Items { get; set; }
    }
    public class PageObjectItem
    {
        [JsonProperty("graphQl")]
        public string GraphQl { get; set; }
    }
}
