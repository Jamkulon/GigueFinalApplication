using GigueService.Models;
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
    public class MusiciansInstrumentsByGenreController : ApiController
    {
        //===========================================================================================
        //Fields.
        //===========================================================================================

        //===========================================================================================
        //Properties.
        public Repo repo;
        public GigueContext db;
        //===========================================================================================
        //Constructor().
        public MusiciansInstrumentsByGenreController()
        {
            db = new GigueContext();
            repo = new Repo(db);
        }

        //===========================================================================
        // GET: api/MusiciansInstrumentsByGenre/5
        [Route("api/MusiciansInstrumentsByGenre/{id}")]
        [HttpGet]
        public List<vmMusiciansInstrumentsByGenre> Get(int id)
        {
            if (id != 0)
            {
                Genre GG = new Genre();
                List<MusicianGenre> MGs = new List<MusicianGenre>();
                List<vmMusiciansInstrumentsByGenre> vmMIGs = new List<vmMusiciansInstrumentsByGenre>();

                GG = repo.Query<Genre>().Where(a => a.GenreId == id).FirstOrDefault();
                MGs = repo.Query<MusicianGenre>().Where(b => b.GenreId == id).ToList();
                foreach (MusicianGenre MG in MGs)
                {
                    List<Musician> MMs = new List<Musician>();
                    MMs = repo.Query<Musician>().Where(c => c.MusicianId == MG.MusicianId).ToList();
                    foreach (Musician MM in MMs)
                    {
                        UserMusician UM = new UserMusician();
                        UM = repo.Query<UserMusician>().Where(d => d.MusicianId == MM.MusicianId).FirstOrDefault();
                        AppUser AU = new AppUser();
                        AU = repo.Query<AppUser>().Where(e => e.AppUserId == UM.AppUserId).FirstOrDefault();


                        List<MusicianInstrument> MIs = new List<MusicianInstrument>();
                        MIs = repo.Query<MusicianInstrument>().Where(f => f.MusicianId == MM.MusicianId).ToList();
                        List<vmInstrument> vmInsts = new List<vmInstrument>();
                        foreach (MusicianInstrument MI in MIs)
                        {
                            Instrument Inst = new Instrument();
                            Inst = repo.Query<Instrument>().Where(g => g.InstrumentId == MI.InstrumentId).FirstOrDefault();
                            vmInstrument vmInst = new vmInstrument
                            {
                                InstrumentId = Inst.InstrumentId,
                                InstrumentName = Inst.InstrumentName
                            };
                            vmInsts.Add(vmInst);
                        };
                        vmMusiciansInstrumentsByGenre vmMIG = new vmMusiciansInstrumentsByGenre
                        {
                            GenreId = GG.GenreId,
                            GenreName = GG.GenreName,
                            AppUserId = AU.AppUserId,
                            LastName = AU.LastName,
                            FirstName = AU.FirstName,
                            IsMusician = AU.IsMusician,
                            MusicianId = MM.MusicianId,
                            StageName = MM.StageName,
                            IsMusicianForHire =MM.IsMusicianForHire,
                            vmInstruments = vmInsts
                        };
                        vmMIGs.Add(vmMIG);
                    };
                };
                return vmMIGs;
            }
            else
            {
                return null;
            }
        }
        //===========================================================================
        //// GET: api/MusiciansInstrumentsByGenre
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        ////===========================================================================
        //// POST: api/MusiciansInstrumentsByGenre
        //public void Post([FromBody]string value)
        //{
        //}
        ////===========================================================================
        //// PUT: api/MusiciansInstrumentsByGenre/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        ////===========================================================================
        //// DELETE: api/MusiciansInstrumentsByGenre/5
        //public void Delete(int id)
        //{
        //}
        ////===========================================================================
    }
}
