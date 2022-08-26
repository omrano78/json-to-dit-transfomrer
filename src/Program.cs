// See https://aka.ms/new-console-template for more information
using Dita.Services.Helpers;
using Newtonsoft.Json;
using System.Dynamic;

var example = @"{
  ""data"": {
    ""articleDitaCollection"": {
      ""items"": [
        {
          ""editorsNote"": null,
          ""profile"": {
            ""role"": ""Author"",
            ""expertiseArea"": ""Content Writer"",
            ""firstName"": ""Omran"",
            ""lastName"": ""Omran"",
            ""positionField"": ""Developer""
          },
          ""identifier"": ""contentEngineering"",
          ""title"": ""Content Engineering Article"",
          ""image"": {
            ""imageType"": ""png"",
            ""url"": ""https://images.ctfassets.net/wp8xllxttby8/617qDs1u983leRNfv31tQu/5d34239ef1690f894c1deaba6a0ea6d6/contentful-logo.png"",
            ""altText"": ""contentful"",
            ""caption"": null
          },
          ""publishDate"": ""2022-04-04T00:00:00.000+03:00"",
          ""revisionDate"": ""2022-04-06T00:00:00.000+03:00"",
          ""searchPriority"": null,
          ""sectionCollection"": {
            ""items"": [
              {
                ""highlightText"": ""New paragrpah"",
                ""publishDate"": ""2022-04-04T01:00:00.000+03:00"",
                ""revisionDate"": ""2022-04-08T02:00:00.000+03:00""
              }
            ]
          }
        }
      ]
    }
  }
}";
var res = JsonToDitaHelper.TransformToDita(JsonConvert.DeserializeObject<ExpandoObject>(example));
FileHelper.WriteToFile(res);
