using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using GigueService.Models;

namespace GigueService.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 

    [MobileAppController]
    public class ValuesController : ApiController
    {
        // GET api/values
        //
        public GigueContext _db;
        public ValuesController(GigueContext db)
        {
            _db = db;
        }
        [HttpGet, Route("api/test/hello")]
        public string Get()
        {
            MobileAppSettingsDictionary settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();

            string host = settings.HostName ?? "localhost";
            string greeting = "Hello from " + host;
            
            traceWriter.Info(greeting);
            return greeting;
        }

        // POST api/values
        [HttpPost, Route("api/Test/completeAll")]
        public string Post(string message)
        {
            string retVal = "Hello World! " + message;
            return retVal;
        }
    }
}
