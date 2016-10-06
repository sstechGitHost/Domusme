using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DomusMe
{
    public class App : Application
    {
        public static App rootapp;

        public App()
        {
            try
            {
                var np = new NavigationPage(new Login());
                np.BarBackgroundColor = Color.FromRgb(102, 46, 107);
                rootapp = this;
                MainPage = np;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void SetMainPage()
        {
            var np = new NavigationPage(new Dashboard());
            np.BarBackgroundColor = Color.FromRgb(103, 46, 108);
            MainPage = np;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
