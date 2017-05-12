using GigueService.Controllers;
using GigueService.Models;
using GigueService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Services
{
    public class MusicianSearchService
    {
        //=========================================================
        //Fields.
        //=========================================================
        private Repo _repo;
        private GigueContext _db;
        //=========================================================
        //Properties.
        //=========================================================

        //=========================================================
        //Constructor().
        //=========================================================
        public MusicianSearchService(Repo repo, GigueContext db)
        {
            _repo = repo;
            _db = db;
        }
        //=========================================================
        //Methods().
        //=========================================================
        //If the StageName is provided query the data base by StageName.
        public List<vmMusicianResult> GetMusicians(vmMusicianSearch vmMS) {

            List<vmMusicianResult> vmMRs = new List<vmMusicianResult>();
            //LastName is provided.
            if (vmMS.LastName != null)
            {
                vmMRs = GetMusicianByLastName(vmMS);
            }
            else
            {
                //1.  Last name is null.  City is described.
                //2.  Last name is null.  City is null.  Prime instrument is described.
                //3.  Last name is null.  City and prime instrument are described. 

                if (vmMS.City != null && vmMS.PrimeInstrument != null)
                {
                    vmMRs = GetMusiciansByCityInstrument(vmMS);
                }
                else if (vmMS.City != null)
                {
                    vmMRs = GetMusicianInstrumentsByCity(vmMS);
                }
                else if (vmMS.PrimeInstrument != null)
                {
                    vmMRs = GetMusicianCitiesByInstrument(vmMS);
                }
               
            }
            return vmMRs;
        }
        //================================================================================
        public List<vmMusicianResult> GetMusiciansByCityInstrument(vmMusicianSearch vmMS)
        {
            List<vmMusicianResult> vmMRs = new List<vmMusicianResult>();
            List<AppUser> aus = _repo.Query<AppUser>().Where(t => t.City == vmMS.City).ToList();

            foreach (AppUser au in aus)
            {
                UserMusician um = _repo.Query<UserMusician>().Where(s => s.AppUserId == au.AppUserId).FirstOrDefault();
                Musician mus = _repo.Query<Musician>().Where(r => r.MusicianId == um.MusicianId).FirstOrDefault();
                MusicianInstrument mi = _repo.Query<MusicianInstrument>().Where(q => q.MusicianId == mus.MusicianId && q.IsPrimary == true).FirstOrDefault();
                Instrument inst = _repo.Query<Instrument>().Where(n => n.InstrumentId ==
                                       mi.InstrumentId).FirstOrDefault();
                Instrument i = _repo.Query<Instrument>().Where(n => n.InstrumentName ==
                                       vmMS.PrimeInstrument).FirstOrDefault();
                if (inst.InstrumentId == i.InstrumentId)
                {
                    vmMusicianResult vmMRtemp = new vmMusicianResult
                    {
                        AppUserId = au.AppUserId,
                        FirstName = au.FirstName,
                        LastName = au.LastName,
                        City = au.City,
                        PrimeInstrument = i.InstrumentName
                    };
                    vmMRs.Add(vmMRtemp);
                }
            }
            return vmMRs;
        }
        //================================================================================
        public List<vmMusicianResult> GetMusicianInstrumentsByCity(vmMusicianSearch vmMS)
        {
            List<vmMusicianResult> vmMRs = new List<vmMusicianResult>();
            List<AppUser> aus = _repo.Query<AppUser>().Where(g => g.City == vmMS.City).ToList();

            foreach (AppUser au in aus)
            {
                UserMusician um = _repo.Query<UserMusician>().Where(h => h.AppUserId == au.AppUserId).FirstOrDefault();
                Musician m = _repo.Query<Musician>().Where(j => j.MusicianId == um.MusicianId).FirstOrDefault();
                MusicianInstrument mi = _repo.Query<MusicianInstrument>().Where(k => k.MusicianId == m.MusicianId && k.IsPrimary == true).FirstOrDefault();
                Instrument i = _repo.Query<Instrument>().Where(mm => mm.InstrumentId == mi.InstrumentId).FirstOrDefault();

                vmMusicianResult vmMRtemp = new vmMusicianResult
                {
                    AppUserId = au.AppUserId,
                    LastName = au.LastName,
                    FirstName = au.FirstName,
                    City = au.City,
                    PrimeInstrument = i.InstrumentName
                };
                vmMRs.Add(vmMRtemp);
            }
            return vmMRs;
        }
        //================================================================================
        public List<vmMusicianResult> GetMusicianCitiesByInstrument(vmMusicianSearch vmMS)
        {
            List<vmMusicianResult> vmMRs = new List<vmMusicianResult>();
            Instrument i = _repo.Query<Instrument>().Where(n => n.InstrumentName == vmMS.PrimeInstrument).FirstOrDefault();
            List<MusicianInstrument> mis = _repo.Query<MusicianInstrument>().Where(q => q.InstrumentId == i.InstrumentId && q.IsPrimary == true).ToList();

            foreach (MusicianInstrument mitemp in mis)
            {
                
                Musician mus = _repo.Query<Musician>().Where(r => r.MusicianId == mitemp.MusicianId).FirstOrDefault();
                UserMusician um = _repo.Query<UserMusician>().Where(s => s.MusicianId == mus.MusicianId).FirstOrDefault();
                AppUser au = _repo.Query<AppUser>().Where(t => t.AppUserId == um.AppUserId).FirstOrDefault();
                vmMusicianResult vmMRtemp = new vmMusicianResult
                {
                    AppUserId = au.AppUserId,
                    FirstName = au.FirstName,
                    LastName = au.LastName,
                    City = au.City,
                    PrimeInstrument = i.InstrumentName
                };
                vmMRs.Add(vmMRtemp);
            }
            return vmMRs;
        }
        //================================================================================
        public List<vmMusicianResult> GetMusicianByLastName(vmMusicianSearch vmMS)
        {
            List<vmMusicianResult> vmMRs = new List<vmMusicianResult>();

           
            AppUser au = _repo.Query<AppUser>().Where(b => b.LastName == vmMS.LastName).FirstOrDefault();
            UserMusician um = _repo.Query<UserMusician>().Where(c => c.AppUserId == au.AppUserId).FirstOrDefault();
            Musician m = _repo.Query<Musician>().Where(d => d.MusicianId == um.MusicianId).FirstOrDefault();
            MusicianInstrument mi = _repo.Query<MusicianInstrument>().Where(e => e.MusicianId == m.MusicianId && e.IsPrimary == true).FirstOrDefault();
            Instrument i = _repo.Query<Instrument>().Where(f => f.InstrumentId == mi.InstrumentId).FirstOrDefault();
            vmMusicianResult vmMRtemp = new vmMusicianResult
            {
                AppUserId = au.AppUserId,
                FirstName = au.FirstName,
                LastName = au.LastName,
                City = au.City,
                PrimeInstrument = i.InstrumentName
            };
            vmMRs.Add(vmMRtemp);
            return vmMRs;
        }
        //================================================================================
    }
}