using GigueService.Models;
using GigueService.ViewModels;
using Microsoft.Azure.Mobile.Server;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server.Config;
using GigueService.Services;
//===========================================================

namespace GigueService.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 

    [MobileAppController]
    public class AppUserController : ApiController
    {
        //=================================================================================
        //Fields.
        //=================================================================================
        public AppUserService service;
        public Repo repo;
        public GigueContext db;
        //=================================================================================
        //Properties.
        //=================================================================================
        //=================================================================================
        //Constructor().
        //=================================================================================
        public AppUserController()
        {
            db = new GigueContext();
            repo = new Repo(db);
            service = new AppUserService(repo, db);

        }
        //=================================================================================
        //Methods()
        //=================================================================================
        [HttpGet]
        public List<AppUser> Get()
        {
            try
            {
                var users = service.GetUsers();
                return users;
            }
            catch
            {
                BadRequest("No data found to match request");
            }
            return null;
        }
        //=================================================================================
        [Route("api/appuser/{id}")]
        [HttpGet]
        public vmAppUser Get(int id)
        {
            try
            {
                var user = service.GetUserById(id);
                return user;
            }
            catch
            {
                BadRequest("No data found to match request");
            }
            return null;

        }
        //=================================================================================
        // POST: api/AppUser
        public void Post([FromBody]vmAppUser user)
        {
            //service.TestLog(user);

            if (ModelState.IsValid)
            {
                service.AddUser(user);
            }
            else
            {
                BadRequest();
            }
        }
        // PUT: api/AppUser/5
        public void Put(int id, [FromBody]string value)
        {
        }
        //=================================================================================
        // DELETE: api/AppUser/5
        public void Delete(int id)
        {
            try
            {
                service.RemoveUser(id);
            }
            catch
            {
                BadRequest("No data found to match request");
            }
        }
        //=================================================================================

    }
}
