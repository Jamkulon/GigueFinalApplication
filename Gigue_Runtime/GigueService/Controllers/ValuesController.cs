using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using GigueService.Models;
using System.Linq;
using System.Collections.Generic;

namespace GigueService.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 

    [MobileAppController]
    public class ValuesController : ApiController
    {
        // GET api/values
        //
        public Repo _repo;

        public ValuesController()
        {
            
        }
        [Route("api/values/1")]
        [HttpGet]
        public UserMusicianRating Get()
        {
            MobileAppSettingsDictionary settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();

            string host = settings.HostName ?? "localhost";
            string greeting = "Hello from " + host;
            
            traceWriter.Info(greeting);
            //get data test
            GigueContext db = new GigueContext();
            Repo repos = new Repo(db);
            var users = repos.Query<AppUser>().Where(a => a.AppUserId == 21).FirstOrDefault();
            var usermusic = repos.Query<UserMusicianRating>().Where(um => um.AppUserId == 21 && um.MusicianId == 5).FirstOrDefault();

            var umr = new UserMusicianRating
            {
                AppUserId = usermusic.AppUserId,
                MusicianId = usermusic.MusicianId,
                MusicianRating = usermusic.MusicianRating,
                DateTimeOfRating = usermusic.DateTimeOfRating
            };
             
            
            return umr;
        }

        // POST api/values
        [HttpPost]
        public string Post(string message)
        {
            string retVal = "Hello World! " + message;
            return retVal;
        }
    }
}
