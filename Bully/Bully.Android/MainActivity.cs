using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using System.Threading.Tasks;

namespace Bully.Droid
{
    [Activity(Label = "Acceso directo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string TAG = "MainActivity";

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new Bully.App());
           // this.IsPlayServicesAvailable();

			

		}

        //public bool IsPlayServicesAvailable()
        //{
            
        //    int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            
        //    if (resultCode != ConnectionResult.Success)
        //    {
        //        if (!GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
        //        {
        //            Finish();
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
                
        //}

    }
}

