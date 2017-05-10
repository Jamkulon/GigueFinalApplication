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
            if (user == null)
            {
                BadRequest("The index, AppUserID, does not exist in the AppUsers table.");
                return null;
            }
            else
            {
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
        }

        private void BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        //=================================================================

        //1.  Add a new user.  The AppUserId is zero by default.  
        //2.  Update an existing user.  The AppUserId is derived from the database 
        //    and is not changed either by the application user or anywhere within the code.
        //    However, if an invalid AppUserId is submitted the condition  is tested.  
        //
        public vmAppUser PostUser(vmAppUser vmAU)
        {
            AppUser testuser = _repo.Query<AppUser>().Where(a => a.AppUserId == vmAU.AppUserId).FirstOrDefault();
            if (testuser == null)
            {
                BadRequest("The index, AppUserId, does not exist in the AppUser database.");
                return null;
            }
            else
            {
                AppUser newUser = new AppUser
                {
                    AppUserId = vmAU.AppUserId,
                    UserName = vmAU.UserName,
                    PassWord = vmAU.PassWord,
                    LastName = vmAU.LastName,
                    FirstName = vmAU.FirstName,
                    City = vmAU.City,
                    State = vmAU.State,
                    PostalCode = vmAU.PostalCode,
                    Email = vmAU.Email,
                    IsMusician = vmAU.IsMusician,
                    ReceiveAdvertisements = vmAU.ReceiveAdvertisements
                };
                if (newUser.AppUserId == 0)
                {
                    _repo.Add(newUser);
                }
                else
                {
                    _repo.Update(newUser);
                }
                return vmAU;

            }
        }
        //=================================================================
        public void RemoveUser(int id)
        {
            var user = _repo.Query<AppUser>().Where(u => u.AppUserId == id);
            _repo.Delete(user);
        }
        //=================================================================
        public vmAppUser UpdateAppUser(vmAppUser vmAU)
        {
            AppUser AU = new AppUser
            {
                AppUserId = vmAU.AppUserId,
                PassWord = vmAU.PassWord,
                UserName = vmAU.UserName,
                LastName = vmAU.LastName,
                FirstName = vmAU.FirstName,
                City = vmAU.City,
                IsMusician = vmAU.IsMusician,
                State = vmAU.State,
                PostalCode = vmAU.PostalCode,
                Email = vmAU.Email,
                ReceiveAdvertisements = vmAU.ReceiveAdvertisements
            };
            _repo.Update(AU);
            return vmAU;
        }
        //=================================================================
        //This methods tests the AppUserId to ensure that it is either zero or 
        //exists in the AppUser table in the AppUserId column.    
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