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
using Android.Support.V7.App;
using System.Threading.Tasks;

namespace DomusMe.Droid.Activites
{
    [Activity(Label = "DomusMe", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            // Create your application here
        }
        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => {

                Task.Delay(10);  // Simulate a bit of startup work.

            });

            startupWork.ContinueWith(t => {
                //  ActionBar.SetDisplayShowHomeEnabled(false);
              
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}