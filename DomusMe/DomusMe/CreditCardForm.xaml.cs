using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe
{
    public partial class CreditCardForm : ContentPage
    {
        string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        string[] years = new string[] { "2016", "2017", "2018", "2019", "2020", "2012" };
        decimal CurrentBalanceDue = 0;

        //TO-DO : While creating a new CC, is Wallet_PaymentMethod walletPayMethod object required here. It will always be null then why?
        //Answer: In future if editing an exisitng CC is required then it can be useful
        public CreditCardForm(PayableItem selectedPayItem, Wallet_PaymentMethod walletPayMethod)
        {
            InitializeComponent();
#if DEBUG
            month.Text = "Apr";
            cardExpYear.Text = "2019";

            cardACNo.Text = "4111111111111111";

#endif
            CurrentBalanceDue = selectedPayItem.CurrentBalanceDue;
            PaymentDetails paymentDetails = new PaymentDetails();
            paymentDetails.AmountToPay = selectedPayItem.CurrentBalanceDue.ToString();
            paymentDetails.PayableItemID = selectedPayItem.PayableItemId.ToString();

            //Nahid - Sep22: Since we are creating a new CC, Paymethod should default to true.
            paymentDetails.PaymentMethod = true;


            if (!String.IsNullOrEmpty(paymentDetails.PayableItemID))
            {
                lblBalanceDue.Text = "$" + CurrentBalanceDue;
                partialPayAmt.Text = lblBalanceDue.Text;

                Device.BeginInvokeOnMainThread(async () => {
                    decimal conFee = await BLL.Instance.GetConvenienceFeeByRenterID(paymentDetails);
                    lblConvFee.Text = "$" + conFee;
                    lblTotalAmount.Text = "$" + Math.Round((CurrentBalanceDue + conFee), 2);
                    //updBtn.Text = "Add and Pay " + lblTotalAmount.Text;
                });
                PayItemDetailsStack.IsVisible = true;
            }
            else
            {
                //to-do: for test commented below statement
                //PayItemDetailsStack.IsVisible = false;
                //updBtn.Text = "Add and Pay";
            }

            foreach (string item in months)
            {
                pickerMonthPicker.Items.Add(item);
            }
            foreach (string item in years)
            {
                pickerYearPicker.Items.Add(item);
            }

            updBtn.Clicked += async (sender, e) =>
            {
                await AddUpdateAndPay(paymentDetails);
            };

            cancelBtn.Clicked += (sender, e) => { Navigation.PopAsync(); };

            partPayBtn.Clicked += async (sender, e) =>
            {
                if (partialPayAmt.Text.Trim() != string.Empty)
                {
                    paymentDetails.AmountToPay = partialPayAmt.Text;
                    decimal conFee = await BLL.Instance.GetConvenienceFeeByRenterID(paymentDetails);
                    lblConvFee.Text = "$" + conFee;
                    lblTotalAmount.Text = "$" + (CurrentBalanceDue - Convert.ToDecimal(partialPayAmt.Text.Trim())).ToString();
                    //updBtn.Text = "Add And Pay $" + Math.Round((Convert.ToDecimal(partialPayAmt.Text) + conFee), 2).ToString();
                }

            };
        }

        private async Task AddUpdateAndPay(PaymentDetails paymentDetails)
        {
            int expMth = Array.IndexOf(months, month.Text) + 1;
            if (Validations())
            {
                paymentDetails.CCHolderName = cardHolderName.Text.Trim();
                paymentDetails.AccountNumber = cardACNo.Text.Trim();
                paymentDetails.CCExpMonth = expMth.ToString();
                paymentDetails.CCExpYear = cardExpYear.Text.ToString();
                paymentDetails.CreditCardSecurityCode = cardSecurityCode.Text;
                if(await BLL.Instance.DoCreditCardPaymentWithNewCC(paymentDetails))
                    await Navigation.PopAsync();
            }
        }

        private bool Validations()
        {
            if (String.IsNullOrEmpty(cardHolderName.Text))
            {
                DisplayAlert("Invalid Data", "Please enter a valid Card Holder Name.", "Ok");
                return false;
            }
            if (String.IsNullOrEmpty(cardACNo.Text))
            {
                DisplayAlert("Invalid Data", "Please enter a valid Account Number.", "Ok");
                return false;
            }

            if (Array.IndexOf(months, month.Text) == -1)
            {
                DisplayAlert("Invalid Data", "Please enter a valid Card Expire Month.", "Ok");
                return false;
            }

#if RELEASE
            if (pickerYearPicker.SelectedIndex == -1)
            {
                DisplayAlert("Invalid Data", "Please enter a valid Card Expire Year.", "Ok");
                return false;
            }
#endif

            if (String.IsNullOrEmpty(cardSecurityCode.Text))
            {
                DisplayAlert("Invalid Data", "Please enter a valid Card Security Code.", "Ok");
                return false;
            }

            return true;
        }

        async void OnMonthButtonClicked(object sender, EventArgs e)
        {
            pickerMonthPicker.Focus();
        }
        async void OnYearButtonClicked(object sender, EventArgs e)
        {
            pickerYearPicker.Focus();
        }
        void TapMontPicker_Tapped(object sender, EventArgs args)
        {
            pickerMonthPicker.Focus();
        }
        void pickerMonthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string monthName = pickerMonthPicker.Items[pickerMonthPicker.SelectedIndex];
           // this.Color = colorDict[colorName];
            month.Text = monthName;
        }
        void pickerYearPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yearName = pickerYearPicker.Items[pickerYearPicker.SelectedIndex];
            // this.Color = colorDict[colorName];
            cardExpYear.Text = yearName;
        }
    }

}
