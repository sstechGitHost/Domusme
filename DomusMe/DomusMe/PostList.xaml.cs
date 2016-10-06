using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe
{
    public partial class PostList : ContentPage
    {
        public ObservableCollection<PostDetails> posts { get; set; }
        public PostList()
        {
            posts = new ObservableCollection<PostDetails>();
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
            listView.ItemsSource = posts;
            posts.Add(new PostDetails { Name = "How to detect a credit card cloner at the gas pump", Url = "http://modo.ly/1pke2gk", Image = "logoicon.png", Description = "How to detect a credit card cloner at the gas pump" });
            posts.Add(new PostDetails { Name = "How to detect a credit card cloner at the gas pump", Url = "http://modo.ly/1pke2gk", Image = "logoicon.png", Description = "How to detect a credit card cloner at the gas pump" });

            listView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                listView.SelectedItem = null; // deselect row
                await Navigation.PushAsync(new PostDetail(e.SelectedItem));

            };

        }
    }
}
