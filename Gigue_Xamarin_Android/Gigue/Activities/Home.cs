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
using Gigue.Activities;
using System.Threading.Tasks;
using Android.Preferences;

namespace Gigue
{
    [Activity(MainLauncher= true, WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@android:style/Theme.NoTitleBar"))]
    public class Home : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomePage);

        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() =>
            {
                Task.Delay(6000);
            });
            startupWork.ContinueWith(t =>
           {
               StartActivity(new Intent(Application.Context, typeof(Login)));
           }, TaskScheduler.FromCurrentSynchronizationContext());

           startupWork.Start();
        }

        //protected override void OnSleep()
        //{
            
        //}

        protected override void OnDestroy()
        {
            //ISharedPreferences GiguePrefs = PreferenceManager.GetDefaultSharedPreferences(this);
            //ISharedPreferencesEditor editor = GiguePrefs.Edit();
            //editor.Clear();
            //editor.Apply();

            base.OnDestroy();
        }
    }
}