using DomusMe.Interfaces;
using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe
{
    public partial class Login : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);
        }

        public Login()
        {
            InitializeComponent();
            NavigationPage.SetTitleIcon(this, "logolg");
            actIndicator.IsRunning = false;

            userNameText.Text = "";
            passWordText.Text = "";

            //if (Application.Current.Properties.ContainsKey("loginID"))
            //{
            //    string lastLoginId = Application.Current.Properties["loginID"] as string;
            //    if (!string.IsNullOrEmpty(lastLoginId))
            //        userNameText.Text = lastLoginId;

            //    DisplayAlert("Hey", userNameText.Text, "Ok");
            //}
            userNameText.Text = DependencyService.Get<ISettingService>().GetSetting<string>("userName", "");

#if DEBUG
            //userNameText.Text = "chrisakel@razordigital.net";
            //passWordText.Text = "password1";
            userNameText.Text = "sconnors@test.com";
            passWordText.Text = "password1";

#endif
            loginBtn.Clicked += async (sender, e) =>
            {
                actIndicator.IsRunning = true;
                await AuthenticateUser();
                actIndicator.IsRunning = false;
            };

        }

        private async Task AuthenticateUser()
        {
            if ((userNameText.Text.Length > 0) && (passWordText.Text.Length > 0))
            {
                AuthenticationResponse obj = await BLL.Instance.Login(userNameText.Text, passWordText.Text);

                if (obj.SessionId != null)
                {
                    Const.SessionID = obj.SessionId;
                    Const.RenterID = obj.AuthenticatedRenter.RenterId.ToString();
                    //Application.Current.Properties["loginID"] = userNameText.Text;
                    DependencyService.Get<ISettingService>().AddOrUpdateSetting<string>("userName", userNameText.Text);
                    App.rootapp.SetMainPage();
                }
                else
                    await DisplayAlert("Authentication Failed", "User Name or Password is Incorect.", "Ok");
            }
            else
            {
                await DisplayAlert("Authentication Failed", "Please enter valid login credentials.", "Ok");
            }
        }


        void OnForgotPwd(object send, EventArgs e)
        {
        }

    }
}
