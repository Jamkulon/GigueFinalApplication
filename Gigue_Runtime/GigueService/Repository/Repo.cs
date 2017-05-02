using GigueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Controllers
{
    public class Repo
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
        /// <summary>
        /// Generic query method
        /// </summary>
        public void Add<T>(T entityToCreate) where T : class
        {
            _db.Set<T>().Add(entityToCreate);
            this.SaveChanges();
        }


        /// <summary>
        /// Update an existing entity
        /// </summary>
        //public void Update<T>(T entityToUpdate) where T : class
        //{
        //    _db.Set<T>().Update(entityToUpdate);
        //    this.SaveChanges();
        //}


        /// <summary>
        /// Delete an existing entity
        /// </summary>
        public void Delete<T>(T entityToDelete) where T : class
        {
            _db.Set<T>().Remove(entityToDelete);
            this.SaveChanges();
        }



        /// <summary>
        /// Save changes to the database
        /// </summary>
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}