using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SharedPreferences
{
    public class User
    {

        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }


        public override string ToString()
        {
            return UserName;
        }


        //public int UserID { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }

    }
}