using GigueService.Controllers;
using GigueService.Models;
using GigueService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Services
{
    public class AppUserService
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
        public AppUserService(Repo repo, GigueContext db)
        {
            _repo = repo;
            _db = db;

        }
        //=================================================================
        //Methods().
        //=================================================================
        public List<AppUser> GetUsers()
        {
            var users = _repo.Query<AppUser>().ToList();
            return users;
        }
        //=================================================================
        public vmAppUser GetUserById(int id)
        {
            var user = _repo.Query<AppUser>().Where(a => a.AppUserId == id).FirstOrDefault();

            var au = new vmAppUser
            {
                AppUserId = user.AppUserId,
                UserName = user.UserName,
                LastName = user.LastName,
                FirstName = user.FirstName,
                City = user.City,
                State = user.State,
                PostalCode = user.PostalCode,
                Email = user.Email,
                ReceiveAdvertisements = user.ReceiveAdvertisements,
                IsMusician = user.IsMusician
            };
            return au;
        }
        //=================================================================
        public void AddUser(AppUser user)
        {
            if (user.AppUserId == 0)
            {
                _repo.Add(user);
            }
            else
            {
                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            }
        }
        //=================================================================
        public void RemoveUSer(int id)
        {
            var user = _repo.Query<AppUser>().Where(u => u.AppUserId == id);
            _repo.Delete(user);
        }
        //=================================================================
    }
}