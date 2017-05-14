using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using GigueService.Models;
using System.Linq;
using System.Collections.Generic;
using GigueService.ViewModels;

namespace GigueService.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 

    [MobileAppController]
    public class ValuesController : ApiController
    {
        //===========================================================================================
        //Fields.
        //===========================================================================================

        // GET api/values
        //
        //===========================================================================================
        //Properties.
        public Repo _repo;
        //===========================================================================================
        //Constructor().
        public ValuesController()
        {

        }
        //===========================================================================================
        //[Route("api/values/{id}")]
        //[HttpGet]
        //public vmAppUser Get(int id)
        //{
        //    MobileAppSettingsDictionary settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
        //    ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();

        //    string host = settings.HostName ?? "localhost";
        //    string greeting = "Hello from " + host;

        //    traceWriter.Info(greeting);
        //    //get data test
        //    GigueContext db = new GigueContext();
        //    Repo repos = new Repo(db);
        //    var user = repos.Query<AppUser>().Where(a => a.AppUserId == id).FirstOrDefault();
        //    //  var usermusic = repos.Query<UserMusicianRating>().Where(um => um.AppUserId == 21 && um.MusicianId == 5).FirstOrDefault();

        //    var au = new vmAppUser
        //    {
        //        AppUserId = user.AppUserId,
        //        LastName = user.LastName,
        //        FirstName = user.FirstName,
        //        City = user.City,
        //        State = user.State,
        //        PostalCode = user.PostalCode,
        //        Email = user.Email,
        //        ReceiveAdvertisements = user.ReceiveAdvertisements,
        //        IsMusicianForHire = user.IsMusicianForHire

        //    };
        //    return au;
        //}
    
        //===========================================================================================
            // POST api/values
            [HttpPost]
        public string Post(string message)
        {
            string retVal = "Hello World! " + message;
            return retVal;
        }
        //===========================================================================================
    }


}

