using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe
{
    public partial class RentFeeList : ContentPage
    {
        public RentFeeList()
        {
            InitializeComponent();
            Device.BeginInvokeOnMainThread(async () =>
            {
                GetPayableFeeDetailResponse feesList = await BLL.Instance.GetRentFeeDetails();
                rentFeesListView.ItemsSource = feesList.PayableItem_FeeDetailItems;
            });
        }
    }
}
