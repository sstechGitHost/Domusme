using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DomusMe
{
    public partial class RentPayDetails : ContentPage
    {
        List<PayItems> mainPayItems = new List<PayItems>();
        ObservableCollection<PayItems> payItems = new ObservableCollection<PayItems>();
        GetRenterByRenterIdResponse renterDetail;
        PayablesResponse payableItems;
        Wallet_GetPaymentMethodsResponse walletItems;
        //Notes
        //2. If there are not wallet pay methods, user should be shown a message "No payment methods found" and presented two buttons to add
        // pay method a) add a new cc b) add a new bank account
        //3. if AllowPartialPayments is true then user should have ability to make partial payments
        //If current balance is 0 or < 0, dont make a payment
        public RentPayDetails()
        {
            InitializeComponent();
            
           // actIndicator.IsRunning = false;
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

            payCashBtn.Clicked += async (sender, e) => {
                await MakeCashPayment();
            };
        }

        private async Task MakeCashPayment()
        {
            List<PayableItem> payableList = (List<PayableItem>)listView.ItemsSource;

            if (payableList.Count > 0)
            {
                PayableItem selectedPayItem = (PayableItem)listView.SelectedItem;
                if (listView.SelectedItem != null)
                {
                    if (selectedPayItem.AcceptedPaymentTypeID == 1 || selectedPayItem.AcceptedPaymentTypeID == 3)
                    {
                        if (selectedPayItem.CurrentBalanceDue > 0)
                            await Navigation.PushAsync(new MakePayment(null, selectedPayItem));
                    }
                }
                else
                {
                    await DisplayAlert("Missing Data", "Please select a Payable Item.", "Ok");
                }
            }
        }

        private void CheckCurrentBalanceAmt(List<PayableItem> payableList)
        {
            if (payableList.Count > 0)
            {
                int currentBal = 0;
                string currBal = Const.SplitString(payableList[0].CurrentDueBal);
                if (int.TryParse(currBal, out currentBal))
                {
                    if (currentBal <= 0)
                    {
                        listView.IsEnabled = false;
                        paymentlistView.IsEnabled = false;
                    }
                }
                else
                {
                    listView.IsEnabled = false;
                    paymentlistView.IsEnabled = false;
                }
            }
        }

        void OnUseBtn(object sender,EventArgs e)
        {
            List<PayableItem> payableList = (List<PayableItem>)listView.ItemsSource;

            if (payableList.Count > 0)
            {
                paymentlistView.SelectedItem = walletItems.Wallet_PaymentMethods.Where(x => x.PayerWalletId.ToString() == ((Button)sender).ClassId).SingleOrDefault();

                Wallet_PaymentMethod selectedPayMethod = (Wallet_PaymentMethod)paymentlistView.SelectedItem;

                PayableItem selectedPayItem = (PayableItem)listView.SelectedItem;
                if (listView.SelectedItem != null)
                {
                    Navigation.PushAsync(new MakePayment(selectedPayMethod, selectedPayItem));
                    //for test only
                   // Wallet_PaymentMethod walletPayMethod = (Wallet_PaymentMethod)paymentlistView.SelectedItem;
                   // Navigation.PushAsync(new CreditCardForm(selectedPayItem, walletPayMethod));
                }
                else
                {
                    DisplayAlert("Missing Data", "Please select a Payable Item.", "Ok");
                }
            }

        }

        void OnFeeDetailsBtn(object sender,EventArgs e)
        {
            listView.SelectedItem = ((List<PayableItem>)listView.ItemsSource).Where(x => x.PayableItemId.ToString() == ((Button)sender).ClassId).SingleOrDefault();
            Navigation.PushAsync(new RentFeeList());
        }
        
        void OnEditBtn(object sender,EventArgs e)
        {
            try
            {
                PayableItem selectedPayItem = (PayableItem)listView.SelectedItem;
                //paymentlistView.SelectedItem = ((Wallet_PaymentMethod[])paymentlistView.ItemsSource).Where(x => x.PayerWalletId.ToString() == ((Button)sender).ClassId).SingleOrDefault();
                paymentlistView.SelectedItem = ((List<Wallet_PaymentMethod>)paymentlistView.ItemsSource).Where(x => x.PayerWalletId.ToString() == ((Button)sender).ClassId).SingleOrDefault();

                Wallet_PaymentMethod walletPayMethod = (Wallet_PaymentMethod)paymentlistView.SelectedItem;

                if (walletPayMethod.Editable)
                {
                    if (walletPayMethod.PaymentMethod)
                        Navigation.PushAsync(new CreditCardForm(selectedPayItem, walletPayMethod));
                    else
                        Navigation.PushAsync(new ECheckForm(selectedPayItem, walletPayMethod));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        void OnNewCCBtn(object sender, EventArgs e)
        {
            List<PayableItem> payItemList = (List<PayableItem>)listView.ItemsSource;
            if (payItemList.Count == 1 && payItemList[0].PayableItemId.ToString() == "0")
            {
                Navigation.PushAsync(new CreditCardForm(payItemList[0], null));
            }
            else
            {
                PayableItem selectedPayItem = (PayableItem)listView.SelectedItem;
                if (listView.SelectedItem != null)
                {
                    Navigation.PushAsync(new CreditCardForm(selectedPayItem, null));
                }
                else
                {
                    DisplayAlert("Missing Data", "Please select a Payable Item.", "Ok");
                }
            }
        }

        void OnNewACBtn(object sender, EventArgs e)
        {
            PayableItem selectedPayItem = (PayableItem)listView.SelectedItem;
            Navigation.PushAsync(new ECheckForm(selectedPayItem,null));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                actIndicator.IsRunning = true;
                renterDetail = await BLL.Instance.GetRenterDetails();
                if (renterDetail != null && !renterDetail.Result.ToLower().Contains("sessiontimeout"))
                {
                    payableItems = await BLL.Instance.GetPayableItems();
                    walletItems = await BLL.Instance.GetWalletItems();

                    this.RenterDetailsStack.BindingContext = renterDetail;
                    SetPaymentItemsDetails();
                    SetWalletPaymentMethodDetails();
                }
                actIndicator.IsRunning = false;

            }); 
        }

        private void SetPaymentItemsDetails()
        {
            List<PayableItem> payableList = new List<PayableItem>();

            //foreach (PayableItem payItem in this.payableItems.PayableItems.PayableItem)
            //{
            PayableItem payItem = this.payableItems.PayableItems.PayableItem;
            payableList.Add(payItem);

            if (payableList.Count > 0)
            {
                listView.ItemsSource = payableList;
                listView.SelectedItem = payableList.First();
                newAC.IsVisible = true;
                newCC.IsVisible = true;
                payCashBtn.IsVisible = true;
            }
            else
            {
                payItemsStack.IsVisible = false;
            }
        }

        private void SetWalletPaymentMethodDetails()
        {
            foreach (var item in walletItems.Wallet_PaymentMethods)
            {
                if (item.Description.ToLower().Contains("no payment methods found"))
                {
                    item.IsPayMethodsOptionsVisible = false;
                }
                else
                {
                    item.IsPayMethodsOptionsVisible = true;
                }
            }
            ObservableCollection<Wallet_PaymentMethod>  obsWalletItems = new ObservableCollection<Wallet_PaymentMethod>(walletItems.Wallet_PaymentMethods.ToList());
            paymentlistView.ItemsSource = obsWalletItems;
        }
    }
}
