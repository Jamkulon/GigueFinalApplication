using GigueService.Models;
using GigueService.Services;
using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigueService.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 

    [MobileAppController]
    public class CityController : ApiController
    {
        //=================================================================================
        //Fields.
        //=================================================================================
        public CityService service;
        public Repo repo;
        public GigueContext db;
        //=================================================================================
        //Properties.
        //=================================================================================
        //=================================================================================
        //Constructor().
        //=================================================================================
        public CityController()
        {
            db = new GigueContext();
            repo = new Repo(db);
            service = new CityService(repo, db);

        }
        //=================================================================================
        //Methods()
        //=================================================================================
        [HttpGet]
        // GET: api/City
        //This method gets a list of unique city names that can be used in a drop down menu on the application.   
        public List<string> Get()
        {
            try
            {
                List<string> cities = service.GetCities();
                return cities;
            }
            catch
            {
                BadRequest("No data found to match request");
            }
            return null;
        }
        //===============================================================================================
        // GET: api/City/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/City
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/City/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
        }
    }
}
