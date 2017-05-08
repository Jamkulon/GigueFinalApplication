using GigueService.Controllers;
using GigueService.Models;
using GigueService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                PassWord = user.PassWord,
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
        public void AddUser(vmAppUser user)
        {
            var newUser = new AppUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                AppUserId = user.AppUserId,
                UserName = user.UserName
            };
            if (newUser.AppUserId == 0)
            {
                _repo.Add(newUser);
            }
            else
            {
                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            }
        }
        //=================================================================
        public void RemoveUser(int id)
        {
            var user = _repo.Query<AppUser>().Where(u => u.AppUserId == id);
            _repo.Delete(user);
        }
        //=================================================================
        //public void TestLog(vmAppUser user)
        //{
        //    try
        //    {
        //        var struser = Newtonsoft.Json.JsonConvert.SerializeObject(user);
        //        using (var sqlConnection = new SqlConnection("Data Source=tcp:gigue.database.windows.net,1433;Initial Catalog=gigueDb;User ID=gigueadmin@gigue;Password=#DotNetCoders"))
        //        {
        //            //using (var sqlCommand = new SqlCommand("INSERT INTO [dbo].[xxxx] ( [Id] ,[Stuff] ) VALUES ( @Id, convert(nvarchar(500), @stuff))", sqlConnection))
        //            using (var sqlCommand = new SqlCommand("  INSERT INTO [dbo].[TestLog] ([Description],[Log]) VALUES ('payload',@struser)", sqlConnection))
        //            {
        //                sqlCommand.CommandType = CommandType.Text;

        //                //sqlCommand.Parameters.AddWithValue_Nullable("@Id", id);
        //                sqlCommand.Parameters.AddWithValue("@struser", struser);

        //                sqlConnection.Open();
        //                sqlCommand.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}