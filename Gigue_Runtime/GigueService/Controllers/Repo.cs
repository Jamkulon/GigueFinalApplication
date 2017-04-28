using GigueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Controllers
{
    public class Repo : IRepo
    {
        private GigueContext _db;
        public Repo(GigueContext db)
        {
            _db = db;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }
    }
}