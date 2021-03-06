﻿using GigueService.Models;
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
    public class MusicianProfileController : ApiController
    {
        //===========================================================================================
        //Fields.
        //===========================================================================================
        public MusicianProfileService MPservice;
        public Repo repo;
        public GigueContext db;
        //===========================================================================================
        //Properties.


        //===========================================================================================
        //Constructor().
        public MusicianProfileController()
        {
            db = new GigueContext();
            repo = new Repo(db);
            MPservice = new MusicianProfileService(repo, db);
        }
        //====================================================================================
        //Methods()
        //====================================================================================
        [Route("api/MusicianProfile/{id}")]
        [HttpGet]
        public vmMusicianProfile Get(int id)
        {
            try
            {
                var vmM = MPservice.GetUserById(id);
                return vmM;
            }
            catch
            {
                BadRequest("No data found to match the request.");
                return null;
            }
        }
        //====================================================================================
        // GET: api/MusicianProfile
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //====================================================================================
        // POST: api/MusicianProfile
        public vmMusicianProfile Post([FromBody]vmMusicianProfile vmMP)
        {
            vmMusicianProfile vmMPnew = new vmMusicianProfile();
            if (ModelState.IsValid)
            {
                vmMPnew = MPservice.PostAddMusicianProfile(vmMP);
                if (vmMPnew == null)
                {
                    BadRequest("AppUserId is not zero and it does not exist in the database.");
                    return null;
                }
                else
                {
                    return vmMP;
                }
            }
            else
            {
                BadRequest("This data is not valid.");
                return null;
            }

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
