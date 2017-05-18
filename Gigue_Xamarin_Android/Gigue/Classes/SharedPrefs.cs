using Android.App;
using Android.Content;
using Gigue.ViewModels;
using Newtonsoft.Json;

namespace Gigue.Classes
{
    public class SharedPrefs
    {
        public vmMusicianProfile mRegisteredUser;

        public void saveset(vmMusicianProfile user)
        {
            mRegisteredUser = user;
            string musicianProfile = JsonConvert.SerializeObject(mRegisteredUser);
            //store
            var prefs = Application.Context.GetSharedPreferences("GIGUE", FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString("profile", musicianProfile);
            prefEditor.Apply();

        }

        public vmMusicianProfile retrieveset()
        {
            string strMusicianProfile;
            vmMusicianProfile vmProf;
            //Retreive existing records
            var prefs = Application.Context.GetSharedPreferences("GIGUE", FileCreationMode.Private);
            strMusicianProfile = prefs.GetString("profile", null);
            //If email is null, return new vmMusicianProfile
            if (strMusicianProfile == null)
            {
                mRegisteredUser = new vmMusicianProfile();
                return mRegisteredUser;
            }
            else
            {
                vmProf = JsonConvert.DeserializeObject<vmMusicianProfile>(strMusicianProfile);
                if (vmProf == null)
                {
                    mRegisteredUser = new vmMusicianProfile();
                    return mRegisteredUser;
                }
                else
                {
                    mRegisteredUser = vmProf;
                    return mRegisteredUser;
                }
            }
        }
    }
}