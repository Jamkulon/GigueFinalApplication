using System;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using Gigue.ViewModels;
using Gigue.Activities;
using Android.Views;


namespace Gigue
{
    [Activity(Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class ThankYou : RegistrationActivity
    {
        TextView mThanksUser;
        Button mThankYou;
        vmMusicianProfile mRegisteredUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.thanks);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

            //Get PutExtra data
            mRegisteredUser = JsonConvert.DeserializeObject<vmMusicianProfile>(Intent.GetStringExtra("User"));

            //Update the form dynamically
            RunOnUiThread(() => UpdateUserInfo());

            //The button to nowhere ;-)
            mThankYou = FindViewById<Button>(Resource.Id.btnThanksSearch);
            mThankYou.Click += mThankYou_Click;


        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.activity_main, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.tool_profile)
            {
                StartActivity(typeof(MusicianProfile));
                return true;
            }
            else if (id == Resource.Id.tool_search)
            {
                mRegisteredUser = retrieveset();
                Intent intent = new Intent(this, typeof(Search));
                intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));
                StartActivity(intent);
                return true;
            }
            else if (id == Resource.Id.tool_Login)
            {
                StartActivity(typeof(Login));
                return true;
            }
            else if (id == Resource.Id.tool_infoPage)
            {
                Toast.MakeText(this, "InfoPage clicked", ToastLength.Short).Show();
                StartActivity(typeof(InformationPage));
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        private void UpdateUserInfo()
        {
            mThanksUser = FindViewById<TextView>(Resource.Id.txtThanksUser);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("You are registered as:");
            sb.AppendFormat("{0} {1}{2}", mRegisteredUser.FirstName, mRegisteredUser.LastName, System.Environment.NewLine);
            sb.AppendFormat("{0}{1}", mRegisteredUser.Email, System.Environment.NewLine);
            sb.AppendLine("Please enjoy our application");
            mThanksUser.Text = sb.ToString();
        }

        void mThankYou_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Search));
            intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));
            this.StartActivity(intent);

        }
    }
}