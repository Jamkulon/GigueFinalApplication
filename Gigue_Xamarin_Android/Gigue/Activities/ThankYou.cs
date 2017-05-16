using System;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using Gigue.ViewModels;

namespace Gigue.Activities
{
    [Activity(Theme = ("@android:style/Theme.NoTitleBar"))]
    public class ThankYou : RegistrationActivity
    {
        TextView mThanksUser;
        Button mThankYou;
        vmMusicianProfile mRegisteredUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.thanks);

            //Get PutExtra data
            mRegisteredUser = JsonConvert.DeserializeObject<vmMusicianProfile>(Intent.GetStringExtra("User"));

            //Update the form dynamically
            RunOnUiThread(() => UpdateUserInfo());

            //The button to nowhere ;-)
            mThankYou = FindViewById<Button>(Resource.Id.btnThanksSearch);
            mThankYou.Click += mThankYou_Click;


        }

        private void UpdateUserInfo()
        {
            mThanksUser = FindViewById<TextView>(Resource.Id.txtThanksUser);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("You are registered as:");
            sb.AppendFormat("{0} {1}{2}", mRegisteredUser.FirstName, mRegisteredUser.LastName, System.Environment.NewLine);
            sb.AppendLine("Please enjoy our application");
            mThanksUser.Text = sb.ToString();
        }

        void mThankYou_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Search));
            this.StartActivity(intent);

        }
    }
}