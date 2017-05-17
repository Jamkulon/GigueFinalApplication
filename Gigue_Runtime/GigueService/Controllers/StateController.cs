﻿using GigueService.Models;
using GigueService.Services;
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

    public class StateController : ApiController
    {

        //=================================================================================
        //Fields.
        //=================================================================================
        public StateService service;
        public Repo repo;
        public GigueContext db;
        //=================================================================================
        //Properties.
        //=================================================================================
        //=================================================================================
        //Constructor().
        //=================================================================================
        public StateController()
        {
            db = new GigueContext();
            repo = new Repo(db);
            service = new StateService(repo, db);

        }
        //=================================================================================
        //Methods()
        //=================================================================================
        //This methods get a list of states that can be used in a drop down menu.
        // GET: api/State
        public List<string> Get()
        {
            try
            {
                List<string> states = service.GetStates();
                return states;
            }
            catch
            {
                BadRequest("No data found to match request");
            }
            return null;
        }
        //==================================================================================
        // GET: api/State/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/State
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/State/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/State/5
        public void Delete(int id)
        {
        }
    }
}
