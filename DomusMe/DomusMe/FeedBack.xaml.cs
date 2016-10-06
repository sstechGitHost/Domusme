using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe
{
    public partial class FeedBack : ContentPage
    {
        public FeedBack()
        {
            InitializeComponent();
            ToolbarItem logoutitem = new ToolbarItem { Name = "Log Out", Order = ToolbarItemOrder.Primary };
            logoutitem.Clicked += async (sender, e) =>
            {
                LogoutResponse obj = await BLL.Instance.Logout();
                if (obj != null && obj.Message.ToLower().Contains("success"))
                    await Navigation.PushAsync(new Login());
                else
                    await DisplayAlert("LogOut Failed", "The user was not logged out successfully", "Ok");
            };
            ToolbarItems.Add(logoutitem);
        }
    }
}
