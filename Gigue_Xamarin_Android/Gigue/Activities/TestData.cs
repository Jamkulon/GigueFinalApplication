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

namespace Gigue.Activities
{
    [Activity(Label = "TestData")]
    public class TestData : Activity
    {
        //Originally written:  G. Burley, 24 April 2017.
        //Purpose:  Test data.  This clas creates a colleciton of general-purpose users. 
        //======================================================
        //Fields.
        //======================================================
        //======================================================
        //Properties.
        //======================================================
        AppUser[] AppUsersArray = new AppUser[] { };
        Musician[] MusiciansArray = new Musician[] { };
        //======================================================
        //Constructor().
        //======================================================
        public TestData() {
            for (int i = 1; i <= 30; i++)
            {
                AppUsersArray[i].AppUserId = i;
                AppUsersArray[i].UserName = "testUserName" + i;
                AppUsersArray[i].LastName = "testLastName" + i;
                AppUsersArray[i].FirstName = "testFirstName" + i;
                AppUsersArray[i].City = "testCity" + i;
                AppUsersArray[i].State = "testState" + i;
                AppUsersArray[i].PostalCode = "testPostalCode" + i;
                AppUsersArray[i].Email = "testEamil" + i;
                if (i < 15)
                {

                    AppUsersArray[i].ReceiveAdvertisements = true;
                    AppUsersArray[i].IsMusicianForHire = false;
                }
                else if (i < 20)
                {
                    AppUsersArray[i].ReceiveAdvertisements = true;
                    AppUsersArray[i].IsMusicianForHire = false;
                }
                else
                {
                    AppUsersArray[i].ReceiveAdvertisements = true;
                    AppUsersArray[i].IsMusicianForHire = true;
                }
            }
            for (int j = 1; j <= 30; j++) {
                MusiciansArray[j].MusicianId = j;
                MusiciansArray[j].StageName = "testStageName" + j;
                MusiciansArray[j].CellPhone = "testCellPhone" + j;

                MusiciansArray[j].Biography = "testBiography" + j;
                if (j < 10)
                {
                    MusiciansArray[j].Rate = 13;
                    MusiciansArray[j].Rating = 3;
                }
                else if (j < 20){
                    MusiciansArray[j].Rate = 26;
                    MusiciansArray[j].Rating = 5;
                }
                else {
                    MusiciansArray[j].Rate = 15;
                    MusiciansArray[j].Rating = 7;
                }


            }
        }


        //======================================================
        //Methods().
        //======================================================
        //======================================================

    

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
    public class AppUser
    {

        //Originally written:  G. Burley, 24 April 2017.
        //Purpose:  Test data.  The class creates a single general-purpose user.  
        //Fields.
        //=======================================================
        //Properties.
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool ReceiveAdvertisements { get; set; }
        public bool IsMusicianForHire { get; set; }

        //=======================================================

        //=======================================================
        //Constructor().
        //=======================================================
        
        
        
        //=======================================================
        //Methods().
        //=======================================================
     }
    public class Musician {
        //=======================================================
        //Fields.
        //=======================================================
        //=======================================================
        //Properties.
        //=======================================================
        public int MusicianId { get; set; }
        public string StageName { get; set; }
        public string CellPhone { get; set; }
        public string Biography { get; set; }
        public decimal Rate { get; set; }
        public int Rating { get; set; }
       
        //=======================================================
        //Constructor().
        //=======================================================
        //=======================================================
        //Methods().
        //=======================================================
        //=======================================================

    }



    //========================================================================================================    
}