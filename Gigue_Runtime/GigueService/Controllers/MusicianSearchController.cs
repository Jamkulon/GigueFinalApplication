using GigueService.Models;
using GigueService.Services;
using GigueService.ViewModels;
using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigueService.Controllers
{// Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 

    [MobileAppController]
    public class MusicianSearchController : ApiController
    {
        //===============================================================
        //Fields.
        //===============================================================
        public MusicianSearchService service;
        public Repo repo;
        public GigueContext db;
        //================================================================
        //Constructor().
        //================================================================
        public MusicianSearchController()
        {
            db = new GigueContext();
            repo = new Repo(db);
            service = new MusicianSearchService(repo, db);
        }
        //===============================================================
        //Methods().    
        //===============================================================    
        // GET: api/MusicianSearch
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //=================================================================
        // GET: api/MusicianSearch/5
        public string Get(int id)
        {
            return "value";
        }
        //=================================================================
        //Use the post method to view an object from the client side and to return either a single vmMusicianSearch if the Stage Name is described or a list of VMMusicianSearches if either the the city or prime instrument is described. 
        // POST: api/MusicianSearch
        public List<vmMusicianResult> Post([FromBody]vmMusicianSearch vmMS)
        {
            
            List<vmMusicianResult> vmMusicianResults = new List<vmMusicianResult>();
            if (ModelState.IsValid)
            {
                vmMusicianResults = service.GetMusicians(vmMS);
                return vmMusicianResults;
            }
            else
            {
                BadRequest("No data found to match the request.");
            }
            return null;
        }
        //=================================================================
        // PUT: api/MusicianSearch/5
        public void Put(int id, [FromBody]string value)
        {
        }
        //=================================================================
        // DELETE: api/MusicianSearch/5
        public void Delete(int id)
        {
        }
        //=================================================================
    }
}
