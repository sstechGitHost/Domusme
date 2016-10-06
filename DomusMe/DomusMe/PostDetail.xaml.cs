using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe
{
    public partial class PostDetail : ContentPage
    {
        public PostDetail(object detail)
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
            if (detail is string)
            {
                lblName.Text = (string)detail;
                lblUrl.Text = (string)detail;
                image.Source = (string)detail;
                lblDescription.Text = (string)detail;
            }
            else if (detail is PostDetails)
            {
                lblName.Text = ((PostDetails)detail).Name;
                lblUrl.Text = ((PostDetails)detail).Url;
                image.Source = ((PostDetails)detail).Image;
                lblDescription.Text = ((PostDetails)detail).Description;
            }
        }
    }
}
