using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigueService.Controllers;
using GigueService.Models;

namespace GigueService.Services
{
    public class CityService
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
        public CityService(Repo repo, GigueContext db)
        {
            _repo = repo;
            _db = db;
        }
        //=================================================================
        //Methods().
        //=================================================================

        public List<string> GetCities()
        {
            List<AppUser> aus = _repo.Query<AppUser>().ToList();
            List<string> cities = new List<string>();
            if (aus == null)
            {
                return null;
            }
            else
            {
                cities.Add(aus[0].City);
                for (int i = 1; i < aus.Count; i++)
                {
                    bool addToCities = true;
                    string testCity1 = aus[i].City;
                    for (int j = 0; j < cities.Count; j++)
                    {
                        string testCity2 = cities[j];
                        if (testCity1 == testCity2)
                        {
                            addToCities = false;
                        }
                        else { }
                    }
                    if (addToCities == true && testCity1 != "")
                    {
                        cities.Add(testCity1);
                    }

                }
                return cities;
            }
        }
    }
}