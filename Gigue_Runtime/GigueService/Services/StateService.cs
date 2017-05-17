using GigueService.Controllers;
using GigueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Services
{
    public class StateService
    { //=================================================================
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
        public StateService(Repo repo, GigueContext db)
        {
            _repo = repo;
            _db = db;
        }
        //=================================================================
        //Methods().
        //=================================================================

        public List<string> GetStates()
        {
            List<AppUser> aus = _repo.Query<AppUser>().ToList();
            List<string> states = new List<string>();
            if (aus == null)
            {
                return null;
            }
            else
            {
                states.Add(aus[0].State);
                for (int i = 1; i < aus.Count; i++)
                {
                    bool addToStates = true;
                    string testState1 = aus[i].State;
                    for (int j = 0; j < states.Count; j++)
                    {
                        string testState2 = states[j];
                        if (testState1 == testState2)
                        {
                            addToStates = false;
                        }
                        else { }
                    }
                    if (addToStates == true && testState1 != "")
                    {
                       states.Add(testState1);
                    }
                }
                return states;
            }
        }
        //===========================================================================================
    }
}