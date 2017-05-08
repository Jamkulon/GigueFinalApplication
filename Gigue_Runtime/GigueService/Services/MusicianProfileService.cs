using GigueService.Controllers;
using GigueService.Models;
using GigueService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Services
{
    public class MusicianProfileService
    {
        //=================================================================
        //Fields.
        //=================================================================
        private Repo _repo;
        private GigueContext _db;
     


        //=================================================================
        //Properties.
        //=================================================================
        //=================================================================
        //Constructor().
        //=================================================================
        public MusicianProfileService(Repo repo, GigueContext db)
        {
            _repo = repo;
            _db = db;
        }
        
        //=================================================================
        //Methods().
        //=================================================================
        public vmMusicianProfile GetUserById(int id)
        {

           
            //Use the variable, id, to find the Application User's row (AppUser) in the AppUser table ( collection
            // of AppUser's. 
            
            var user = _repo.Query<AppUser>().Where(a => a.AppUserId == id).FirstOrDefault();

            //Use the AppUseId found within that row to find the row containing that number in the 
            //UserMusician join table. 
            UserMusician um = new UserMusician();
            if (user != null)
            {
                um = _repo.Query<UserMusician>().Where(b => b.AppUserId == user.AppUserId).FirstOrDefault();
            }
            //Use the MusicianId from that row to find the musician in the Musician table. 
            Musician mus = new Musician();
            if (user != null)
            {
                mus = _repo.Query<Musician>().Where(c => c.MusicianId == um.MusicianId).FirstOrDefault();
            }
            //=============================================================================================
            //Similarly, use the MusicianId from that row to find the list of MusicianInstruments from
            //the MusicianInstrument table. 
            List<MusicianInstrument> ms = new List<MusicianInstrument>();
            if (mus != null)
            {
                ms = _repo.Query<MusicianInstrument>().Where(d => d.MusicianId == mus.MusicianId).ToList();
            }
            //Build the collection of instruments from the join table.
            //Using the InstrumentId found in each row of the resulting list build a list of instruments 
            //that the musician plays.  

            List<vmInstrument> tempIs = new List<vmInstrument>();

            if (ms != null)
            {
                foreach (MusicianInstrument musI in ms)
                {
                    Instrument inst = _repo.Query<Instrument>().Where(g => g.InstrumentId == musI.InstrumentId).FirstOrDefault();
                    vmInstrument vmInst = new vmInstrument
                {
                    InstrumentId = inst.InstrumentId,
                    InstrumentName = inst.InstrumentName
                };
                tempIs.Add(vmInst);
            };
            //====================================================================================
            //Similarly, use the MusicianId from that row to find the list of genres that the 
            //musician plays from the MusicianGenre table.   
            var mg = _repo.Query<MusicianGenre>().Where(h => h.MusicianId == mus.MusicianId).ToList();

            List<vmGenre> tempGs = new List<vmGenre>();
            foreach (MusicianGenre musG in mg)
            {
                Genre gen = _repo.Query<Genre>().Where(j => j.GenreId == musG.GenreId).FirstOrDefault();
                vmGenre vmGen = new ViewModels.vmGenre
                {
                    GenreId = gen.GenreId,
                    GenreName = gen.GenreName
                };
                tempGs.Add(vmGen);
            };
            //====================================================================================
            //Similarly, use the MusicianId from that row to find the list of languages that the 
            //musician speaks from the MusicianLanguage table.   
            var mL = _repo.Query<MusicianLanguage>().Where(k => k.MusicianId == mus.MusicianId).ToList();

            List<vmSpokenLanguage> tempLs = new List<vmSpokenLanguage>();
            foreach (MusicianLanguage musL in mL)
            {
                SpokenLanguage Lan = _repo.Query<SpokenLanguage>().Where(q => q.SpokenLanguageId == musL.SpokenLanguageId).FirstOrDefault();
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

            var mP = _repo.Query<MusicianPhotograph>().Where(r => r.MusicianId == mus.MusicianId).ToList();

            List<vmPhotograph> tempPs = new List<vmPhotograph>();
            foreach (MusicianPhotograph musP in mP)
            {
                Photograph Ph = _repo.Query<Photograph>().Where(q => q.PhotographId == musP.PhotographId).FirstOrDefault();
                vmPhotograph vmPh = new ViewModels.vmPhotograph
                {
                    PhotographId = Ph.PhotographId,
                    PhotographURL = Ph.PhotographURL
                };
                tempPs.Add(vmPh);
            };
                //====================================================================================
                var mp = new vmMusicianProfile
                {
                    AppUserId = user.AppUserId,
                    UserName = user.UserName,
                    PassWord = user.PassWord,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    City = user.City,
                    State = user.State,
                    PostalCode = user.PostalCode,
                    Email = user.Email,
                    ReceiveAdvertisements = user.ReceiveAdvertisements,
                    IsMusician = user.IsMusician,
                    MusicianId = mus.MusicianId,
                    StageName = mus.StageName,
                    CellPhone = mus.CellPhone,
                    Biography = mus.Biography,
                    IsMusicianForHire = mus.IsMusicianForHire,
                    Rate = mus.Rate,
                    Rating = mus.Rating,
                    Instruments = tempIs,
                    Genres = tempGs,
                    Languages = tempLs,
                    Photographs = tempPs

                };

                return mp;
            }
            else
            {
                return null;
            }
        }
        //====================================================================================
        //=================================================================
    }
}