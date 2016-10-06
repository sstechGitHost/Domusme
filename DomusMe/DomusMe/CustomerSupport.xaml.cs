using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe
{
    public partial class CustomerSupport : ContentPage
    {
        public CustomerSupport()
        {
            InitializeComponent();
            ToolbarItem logoutitem = new ToolbarItem { Text = "Log Out", Order = ToolbarItemOrder.Primary };
            logoutitem.Clicked += async (sender, e) =>
            {
                LogoutResponse obj = await BLL.Instance.Logout();
                if (obj != null && obj.Message.ToLower().Contains("success"))
                    await Navigation.PushAsync(new Login());
                else
                    await DisplayAlert("LogOut Failed", "The user was not logged out successfully", "Ok");
            };
            ToolbarItems.Add(logoutitem);

            btnCall.Clicked += (sender, e) =>
            {
                string cNummer = "tel:1.888.894.4088";
                Device.OpenUri(new Uri(cNummer));
            };
            btnEmail.Clicked += (sender, e) =>
            {
                Device.OpenUri(new Uri("mailto:chrisakel@razordigital.com"));
            };
            btnLink.Clicked += (sender, e) =>
            {
                Device.OpenUri(new Uri("http://www.efxfinancialservices.com/"));
            };
        }
    }
}
