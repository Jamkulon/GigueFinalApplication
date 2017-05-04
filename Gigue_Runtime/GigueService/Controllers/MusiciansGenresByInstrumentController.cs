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
    public class MusiciansGenresByInstrumentController : ApiController
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
        public MusiciansGenresByInstrumentController()
        {
            db = new GigueContext();
            repo = new Repo(db);
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
            
            AppUser AU = new AppUser();
            Musician Mus = new Musician();
            UserMusician UM = new UserMusician();
            MusicianInstrument MI = new MusicianInstrument();
            Instrument Inst = new Instrument();
            MusicianGenre MG = new MusicianGenre();
            Genre GG = new Genre();
            List<MusicianGenre> MGs = new List<MusicianGenre>();
            List<MusicianInstrument> MIs = new List<MusicianInstrument>();
            List<vmMusiciansGenresByInstrument> vmMGIs = new List<vmMusiciansGenresByInstrument>();

            if (Id != 0)
            {
                Inst = repo.Query<Instrument>().Where(a => a.InstrumentId == Id).FirstOrDefault();
                MIs = repo.Query<MusicianInstrument>().Where(a => a.InstrumentId == Id).ToList();
                foreach (MusicianInstrument mi in MIs)
                {
                    Mus = repo.Query<Musician>().Where(b => b.MusicianId == mi.MusicianId).FirstOrDefault();
                    UM = repo.Query<UserMusician>().Where(c => c.MusicianId == Mus.MusicianId).FirstOrDefault();
                    AU = repo.Query<AppUser>().Where(d => d.AppUserId == UM.AppUserId).FirstOrDefault();
                    MGs = repo.Query<MusicianGenre>().Where(e => e.MusicianId == Mus.MusicianId).ToList();
                    List<vmGenre> vmGGs = new List<vmGenre>();
                    foreach (MusicianGenre MGTemp in MGs)
                    {
                        GG = repo.Query<Genre>().Where(f => f.GenreId == MGTemp.GenreId).FirstOrDefault();
                        vmGenre vmGG = new vmGenre();
                        vmGG.GenreId = GG.GenreId;
                        vmGGs.Add(vmGG);
                    };

                    vmMusiciansGenresByInstrument vmMGI = new vmMusiciansGenresByInstrument
                    {
                        InstrumentId = Id,
                        InstrumentName = Inst.InstrumentName,
                        AppUserId = AU.AppUserId,
                        LastName = AU.LastName,
                        FirstName = AU.FirstName,
                        IsMusicianForHire = AU.IsMusicianForHire,
                        MusicianId = Mus.MusicianId,
                        StageName = Mus.StageName,
                        vmGenres = vmGGs
                    };
                    vmMGIs.Add(vmMGI);
                }
            }
            return vmMGIs;
        }
        //====================================================================================
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

