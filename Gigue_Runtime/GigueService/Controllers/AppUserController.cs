using GigueService.Models;
using GigueService.ViewModels;
using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server.Config;
//===========================================================



namespace GigueService.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 

    [MobileAppController]
    public class AppUserController : ApiController
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
        public AppUserController()
        {

        }
        //===========================================================================================
        [Route("api/AppUser/{id}")]
        [HttpGet]
        public vmAppUser Get(int id)
        {
            //===========================================================================================
            //get data test
            GigueContext db = new GigueContext();
            Repo repos = new Repo(db);
            var user = repos.Query<AppUser>().Where(a => a.AppUserId == id).FirstOrDefault();


            var au = new vmAppUser
            {
                AppUserId = user.AppUserId,
                UserName = user.UserName,
                LastName = user.LastName,
                FirstName = user.FirstName,
                City = user.City,
                State = user.State,
                PostalCode = user.PostalCode,
                Email = user.Email,
                ReceiveAdvertisements = user.ReceiveAdvertisements,
                IsMusicianForHire = user.IsMusicianForHire

            };
            return au;
        }


        // POST: api/AppUser
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppUser/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppUser/5
        public void Delete(int id)
        {
        }
    }
}
