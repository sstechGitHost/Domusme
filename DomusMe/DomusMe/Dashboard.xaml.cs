using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        void OnPayRent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RentPayDetails());

        }

        private void item_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CustomerSupport());
        }

        void OnPost(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PostList());
        }

        void OnCallUs(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CustomerSupport());
        }

        void OnFeedBack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedBack());
        }

    }
}
