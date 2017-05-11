using GigueService.Controllers;
using GigueService.Models;
using GigueService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Services
{
    public class MusicianService
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
        public MusicianService(Repo repo, GigueContext db)
        {
            _repo = repo;
            _db = db;
        }
        //=================================================================
        //Methods().
        //=================================================================
        //1.  Add a new musician to the Musicians table.  MusicianId = 0.
        //2.  Update an exsiting musician.  MusicianId != 0.
        public vmMusician PostMusician(vmMusician vmM)
        {
            Musician mus = new Musician
            {
                MusicianId = vmM.MusicianId,
                StageName = vmM.StageName,
                CellPhone = vmM.CellPhone,
                Biography = vmM.Biography,
                Rate = vmM.Rate,
                Rating = vmM.Rating,
                IsMusicianForHire = vmM.IsMusicianForHire
            };
            if (mus.MusicianId == 0)
            {
                _repo.Add(mus);
            }
            else
            {
                _repo.Update(mus);
            }
            return vmM;
        }
        //==========================================================================
        //Get a single musician by querying the database with MusicianId.
        public vmMusician GetMusicianById(int id)
        {
            Musician Mus = _repo.Query<Musician>().Where(a => a.MusicianId == id).FirstOrDefault();
            if (Mus == null)
            {
                return null;
            }
            else
            {
                var vmMus = new vmMusician
                {
                    MusicianId = Mus.MusicianId,
                    StageName = Mus.StageName,
                    CellPhone = Mus.CellPhone,
                    Biography = Mus.Biography,
                    Rate = Mus.Rate,
                    Rating = Mus.Rating,
                    IsMusicianForHire = Mus.IsMusicianForHire
                };
                return vmMus;
            }
        }
        //===========================================================================
    }
}