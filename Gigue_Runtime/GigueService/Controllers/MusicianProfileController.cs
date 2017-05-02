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
    public class MusicianProfileController : ApiController
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
        public MusicianProfileController()
        {
            db = new GigueContext();
            repo = new Repo(db);
        }
        //===========================================================================================
        [Route("api/MusicianProfile/{id}")]
        [HttpGet]
        public vmMusicianProfile Get(int id)
        {
            //===========================================================================================
                     
            //Use the variable, id, to find the Application User;s row (AppUser) in the AppUser table ( collection
            // of AppUser's. 
            var user = repo.Query<AppUser>().Where(a => a.AppUserId == id).FirstOrDefault();

            //Use the AppUseId found within that row to find the row containing that number in the 
            //UserMusician join table.  
            var um = repo.Query<UserMusician>().Where(b => b.AppUserId == user.AppUserId).FirstOrDefault();

            //Use the MusicianId from that row to find the musician in the Musician table. 
            var mus = repo.Query<Musician>().Where(c => c.MusicianId == um.MusicianId).FirstOrDefault();
            //=============================================================================================
            //Similarly, use the MusicianId from that row to find the list of MusicianInstruments from
            //the MusicianInstrument table.   
            var ms = repo.Query<MusicianInstrument>().Where(d => d.MusicianId == mus.MusicianId).ToList();

            //Build the collection of instruments from the join table.
            //Using the InstrumentId found in each row of the resulting list build a list of instruments 
            //that the musician plays.  

            List<vmInstrument> tempIs = new List<vmInstrument>();
            foreach (MusicianInstrument musI in ms) {
                Instrument inst = repo.Query<Instrument>().Where(g => g.InstrumentId  == musI.InstrumentId).FirstOrDefault();
                vmInstrument vmInst = new vmInstrument {
                    InstrumentId = inst.InstrumentId,
                    InstrumentName = inst.InstrumentName
                };
               
                tempIs.Add(vmInst);
                
            };
            //====================================================================================
            //Similarly, use the MusicianId from that row to find the list of genres that the 
            //musician plays from the MusicianGenre table.   
            var mg = repo.Query<MusicianGenre>().Where(h => h.MusicianId == mus.MusicianId).ToList();

            List<vmGenre> tempGs = new List<vmGenre>();
            foreach (MusicianGenre musG in mg) {
                Genre gen = repo.Query<Genre>().Where(j => j.GenreId == musG.GenreId).FirstOrDefault();
                vmGenre vmGen = new ViewModels.vmGenre {
                    GenreId = gen.GenreId,
                    GenreName = gen.GenreName
                };
                tempGs.Add(vmGen);
            };
            //====================================================================================
            //Similarly, use the MusicianId from that row to find the list of languages that the 
            //musician speaks from the MusicianLanguage table.   
            var mL = repo.Query<MusicianLanguage>().Where(k => k.MusicianId == mus.MusicianId).ToList();

            List<vmSpokenLanguage> tempLs = new List<vmSpokenLanguage>();
            foreach (MusicianLanguage musL in mL)
            {
                SpokenLanguage Lan = repo.Query<SpokenLanguage>().Where(q => q.SpokenLanguageId == musL.SpokenLanguageId).FirstOrDefault();
                vmSpokenLanguage vmLan = new ViewModels.vmSpokenLanguage
                {
                    SpokenLanguageId = Lan.SpokenLanguageId,
                    Language = Lan.Language
                };
                tempLs.Add(vmLan);
            };
            //====================================================================================
            //Similarly, use the MusicianId from that row to find the list of photographs of the  
            //musician from the MusicianPhotograph table.   

            var mP = repo.Query<MusicianPhotograph>().Where(r => r.MusicianId == mus.MusicianId).ToList();

            List<vmPhotograph> tempPs = new List<vmPhotograph>();
            foreach (MusicianPhotograph musP in mP)
            {
                Photograph Ph = repo.Query<Photograph>().Where(q => q.PhotographId == musP.PhotographId).FirstOrDefault();
                vmPhotograph vmPh = new ViewModels.vmPhotograph
                {
                    PhotographId = Ph.PhotographId,
                    PhotographURL = Ph.PhotographURL
                };
                tempPs.Add(vmPh);
            };
            //====================================================================================
            var mp  = new vmMusicianProfile
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
                IsMusicianForHire = user.IsMusicianForHire,
                MusicianId = mus.MusicianId,
                StageName =  mus.StageName,
                CellPhone = mus.CellPhone,
                Biography= mus.Biography,
                Rate = mus.Rate,
                Rating = mus.Rating,
                Instruments = tempIs,                       
                Genres = tempGs,
                Languages = tempLs,
                Photographs = tempPs
                      
            };
            return mp;
        }
        //====================================================================================
        // GET: api/MusicianProfile
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //====================================================================================
        // POST: api/MusicianProfile
        public void Post([FromBody]vmMusicianProfile vmM)
        {
            
            AppUser AppUserToAdd = new AppUser
            {
                UserName = vmM.UserName,
                LastName = vmM.LastName,
                FirstName = vmM.FirstName,
                City = vmM.City,
                State = vmM.State,
                PostalCode = vmM.PostalCode,
                Email = vmM.PostalCode,
                ReceiveAdvertisements = vmM.ReceiveAdvertisements,
                IsMusicianForHire = vmM.IsMusicianForHire
            };
            Musician MusicianToAdd = new Musician
            {
                StageName = vmM.StageName,
                CellPhone = vmM.CellPhone,
                Biography = vmM.Biography,
                Rate = vmM.Rate,
                Rating = vmM.Rating,
            };
            if (AppUserToAdd != null)
            {
                db.AppUsers.Add(AppUserToAdd);
                db.SaveChanges();

            }    
            if (MusicianToAdd != null)
            {
                db.Musicians.Add(MusicianToAdd);
                db.SaveChanges();
            }
           
            AppUser tempAppUser = repo.Query<AppUser>().Where(r => r.LastName == AppUserToAdd.LastName).FirstOrDefault();
            Musician tempMusician = repo.Query<Musician>().Where(s => s.StageName == MusicianToAdd.StageName).FirstOrDefault();
            if (tempAppUser != null && tempMusician != null)
            {
                UserMusician newUM = new UserMusician
                {
                    AppUser = tempAppUser,
                    AppUserId = tempAppUser.AppUserId,
                    Musician = tempMusician,
                    MusicianId = tempMusician.MusicianId
                };
            
                db.UserMusicians.Add(newUM);
                db.SaveChanges();

                //====================================================================
                foreach (vmInstrument i in vmM.Instruments) {
                    Instrument newI = repo.Query<Instrument>().Where(t => t.InstrumentId == i.InstrumentId).FirstOrDefault();
                    MusicianInstrument newMI = new MusicianInstrument
                    {
                        Instrument = newI,
                        InstrumentId = newI.InstrumentId,
                        Musician = tempMusician,
                        MusicianId = tempMusician.MusicianId
                    };
                    db.MusicianInstruments.Add(newMI);
                    db.SaveChanges();

                }
                //====================================================================
                foreach (vmGenre g in vmM.Genres)
                {
                    Genre newG = repo.Query<Genre>().Where(u => u.GenreId == g.GenreId).FirstOrDefault();
                    MusicianGenre newMG = new MusicianGenre
                    {
                        Genre = newG,
                        GenreId = newG.GenreId,
                        Musician = tempMusician,
                        MusicianId = tempMusician.MusicianId
                    };
                    db.MusicianGenres.Add(newMG);
                    db.SaveChanges();

                }
                //====================================================================
                foreach (vmSpokenLanguage s in vmM.Languages)
                {
                    SpokenLanguage newS = repo.Query<SpokenLanguage>().Where(v => v.SpokenLanguageId == s.SpokenLanguageId).FirstOrDefault();
                    MusicianLanguage newML = new MusicianLanguage
                    {
                        SpokenLanguage = newS,
                        SpokenLanguageId = newS.SpokenLanguageId,
                        Musician = tempMusician,
                        MusicianId = tempMusician.MusicianId
                    };
                    db.MusicianLanguages.Add(newML);
                    db.SaveChanges();

                }
                //====================================================================
                foreach (vmPhotograph p in vmM.Photographs)
                {
                    Photograph newP = repo.Query<Photograph>().Where(w => w.PhotographId == p.PhotographId).FirstOrDefault();
                    MusicianPhotograph newMP = new MusicianPhotograph
                    {
                        Photograph = newP,
                        PhotographId = newP.PhotographId,
                        Musician = tempMusician,
                        MusicianId = tempMusician.MusicianId
                    };
                    db.MusicianPhotographs.Add(newMP);
                    db.SaveChanges();

                }
            };

        }
        //====================================================================================
        //// PUT: api/MusicianProfile/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        //====================================================================================
        //// DELETE: api/MusicianProfile/5
        //public void Delete(int id)
        //{
        //}
        //====================================================================================
    }
}
