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
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 
    //===============================================================================

    [MobileAppController]
    public class MusicianController : ApiController
    {
        //=================================================================================
        //Fields.
        //=================================================================================
        public MusicianService service;
        public Repo repo;
        public GigueContext db;
        //=================================================================================
        //Properties.
        //=================================================================================
        //=================================================================================
        //Constructor().
        //=================================================================================
        public MusicianController()
        {
            db = new GigueContext();
            repo = new Repo(db);
            service = new MusicianService(repo, db);
        }
        //=================================================================================
        //Methods()
        //=================================================================================
        // GET: api/Musician
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //==========================================================================
        // GET: api/Musician/5
        public vmMusician Get(int id)
        {
            if (ModelState.IsValid)
            {
                vmMusician vmM = service.GetMusicianById(id);
                if (vmM == null)
                {
                    BadRequest("No musician exits inthe data base with the index of id.");
                    return null;
                }
                else
                {
                    return vmM;
                }
            }
            else
            {
                BadRequest("This data is not valid.");
                return null;
            }
        }
        //==========================================================================
        // POST: api/Musician
        public vmMusician Post([FromBody]vmMusician vmM)
        {
            vmMusician vmMus = new vmMusician();
            if (ModelState.IsValid)
            {
                vmMus = service.PostMusician(vmM);
                if (vmMus == null)
                {
                    BadRequest("AppUserId is not zero and it does not exist in the database.");
                    return null;
                }
                else
                {
                    return vmM;
                }
            }
            else
            {
                BadRequest("This data is not valid.");
                return null;
            }
        }
        //=========================================================================

        // PUT: api/Musician/5
        public void Put(int id, [FromBody]string value)
        {
        }
        //=========================================================================
        // DELETE: api/Musician/5
        public void Delete(int id)
        {
        }
        //=========================================================================
    }
}
