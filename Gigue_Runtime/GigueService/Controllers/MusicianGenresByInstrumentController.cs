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

    [MobileAppController]
    public class MusicianGenresByInstrumentController : ApiController
    {
        //===========================================================================================
        //Fields.
        //===========================================================================================

        //===========================================================================================
        //Properties
        public MusicianGenresByInstrumentService service;
        public Repo repo;
        public GigueContext db;
        //===========================================================================================
        //Constructor().
        public MusicianGenresByInstrumentController()
        {
            db = new GigueContext();
            repo = new Repo(db);
            service = new MusicianGenresByInstrumentService(repo, db);
        }
        //====================================================================================
        // GET: api/MusiciansGenresByInstrument
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //====================================================================================
        // GET: api/MusiciansGenresByInstrument/5
        //Using the instrument Id get all the musicians that play that instrument.
        [Route("api/MusiciansGenresByInstrument/{id}")]
        [HttpGet]
        public List<vmMusiciansGenresByInstrument> Get(int Id)
        {
            if (ModelState.IsValid)
            {
                List<vmMusiciansGenresByInstrument> vmMGIs = service.GetMusiciansGenresByInstrument(Id);
                if (vmMGIs == null)
                {
                    BadRequest("No musician exits inthe data base with the index of id.");
                    return null;
                }
                else
                {
                    return vmMGIs;
                }
            }
            else
            {
                BadRequest("This data is not valid.");
                return null;
            }
        }
        //==================================================================================
        // POST: api/MusiciansGenresByInstrument
        //public void Post([FromBody]string value)
        //{
        //}
        //====================================================================================
        // PUT: api/MusiciansGenresByInstrument/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        //====================================================================================
        // DELETE: api/MusiciansGenresByInstrument/5
        //public void Delete(int id)
        //{
        //}
    }
}

