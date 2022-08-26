using Dita.Services;
using Dita.Services.Helpers;
using Dita.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Dynamic;
using System.Threading.Tasks;

namespace Dita.Web.Controllers
{
    [ApiController]
    [Route("/transform")]
    public class TransformController : ControllerBase
    {
        private readonly ILogger<TransformController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IContentfulService _contentfulService;

        public TransformController(ILogger<TransformController> logger, IConfiguration configuration, IContentfulService contentfulService)
        {
            _logger = logger;
            _configuration = configuration;
            _contentfulService = contentfulService;
        }

        [HttpGet]
        [Route(nameof(Transform))]
        public async Task<string> Transform()
        {
            var query = await _contentfulService.FetchQueryFromArticleDita();
            if (!string.IsNullOrEmpty(query))
            {
                var inputData = await _contentfulService.Fetch(query);
                if (!string.IsNullOrEmpty(inputData))
                {
                    var res = JsonToDitaHelper.TransformToDita(JsonConvert.DeserializeObject<ExpandoObject>(inputData));

                    FileHelper.WriteToFile(res, AppConst.OUTPUT_DIR_NAME);
                }

            }

            var serverUrl = _configuration.GetSection("Hosting")["ServerUrl"];
            serverUrl = string.IsNullOrEmpty(serverUrl) ? "/" : serverUrl.EndsWith("/") ? serverUrl : serverUrl + "/";
            return serverUrl + AppConst.OUTPUT_DIR_NAME + "/" + AppConst.OUTPUT_FILE_NAME;
        }
    }
}
