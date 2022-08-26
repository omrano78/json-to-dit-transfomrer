using Dita.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Dynamic;

namespace Dita.Test
{
    [TestClass]
    public class TransformUnitTest
    {

        public string example => @"{
  ""data"": {
    ""articleDitaCollection"": {
      ""items"": [
        {         
          ""identifier"": ""contentEngineering"",
          ""title"": ""Content Engineering Article"",
          ""publishDate"": ""2022-04-04T00:00:00.000+03:00"",
          ""revisionDate"": ""2022-04-06T00:00:00.000+03:00"",
        }
      ]
    }
  }
}";
        public string expected = @"<?xml version=""1.0"" encoding=""UTF-8""?><!DOCTYPE map PUBLIC "" -//OASIS//DTD DITA Map//EN""  ""output.xml""><map id=""contentEngineering""><title >Content Engineering Article</title><created date=""2022-04-04 12:00:00 AM""></created><revised revised=""2022-04-06 12:00:00 AM""></revised></map>";
        [TestMethod]
        public void TestTransform()
        {
            var res = JsonToDitaHelper.TransformToDita(JsonConvert.DeserializeObject<ExpandoObject>(example));
            Assert.IsNotNull(res);
            Assert.AreEqual(expected.Replace(" ", ""), res.Replace("\n", "").Replace(" ", ""));
        }
    }
}
