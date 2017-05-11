using GigueService.Controllers;
using GigueService.Models;
using GigueService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Services
{
    public class MusicianGenresByInstrumentService
    {
        //=====================================================================
        //Fields.
        //=====================================================================
        private Repo _repo;
        private GigueContext _db;
        //=====================================================================
        //Properties.
        //=====================================================================

        //=====================================================================
        //Constructor().
        //=====================================================================
        public MusicianGenresByInstrumentService(Repo repo, GigueContext db)
        {
            _repo = repo;
            _db = db;
        }
        //=====================================================================
        //Methods().
        //=====================================================================
        public List<vmMusiciansGenresByInstrument> GetMusiciansGenresByInstrument (int Id)
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
                Inst = _repo.Query<Instrument>().Where(a => a.InstrumentId == Id).FirstOrDefault();
                MIs = _repo.Query<MusicianInstrument>().Where(a => a.InstrumentId == Id).ToList();
                foreach (MusicianInstrument mi in MIs)
                {
                    Mus = _repo.Query<Musician>().Where(b => b.MusicianId == mi.MusicianId).FirstOrDefault();
                    UM = _repo.Query<UserMusician>().Where(c => c.MusicianId == Mus.MusicianId).FirstOrDefault();
                    AU = _repo.Query<AppUser>().Where(d => d.AppUserId == UM.AppUserId).FirstOrDefault();
                    MGs = _repo.Query<MusicianGenre>().Where(e => e.MusicianId == Mus.MusicianId).ToList();
                    List<vmGenre> vmGGs = new List<vmGenre>();
                    foreach (MusicianGenre MGTemp in MGs)
                    {
                        GG = _repo.Query<Genre>().Where(f => f.GenreId == MGTemp.GenreId).FirstOrDefault();
                        vmGenre vmGG = new vmGenre();
                        vmGG.GenreId = GG.GenreId;
                        vmGG.GenreName = GG.GenreName;
                        vmGGs.Add(vmGG);
                    };

                    vmMusiciansGenresByInstrument vmMGI = new vmMusiciansGenresByInstrument
                    {
                        InstrumentId = Id,
                        InstrumentName = Inst.InstrumentName,
                        AppUserId = AU.AppUserId,
                        LastName = AU.LastName,
                        FirstName = AU.FirstName,
                        IsMusician = AU.IsMusician,
                        MusicianId = Mus.MusicianId,
                        StageName = Mus.StageName,
                        vmGenres = vmGGs
                    };
                    vmMGIs.Add(vmMGI);
                }
            }
            return vmMGIs;
        }
        //=====================================================================
    }
}