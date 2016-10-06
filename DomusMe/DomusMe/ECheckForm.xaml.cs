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
    public partial class ECheckForm : ContentPage
    {
        //"Checking Account" = 1, "Savings Account" = 2
        string[] types = new string[] { "Checking Account", "Savings Account" };
        
        string accountTypeID = "1";
        decimal CurrentBalanceDue = 0;
        public ECheckForm(PayableItem selectedPayItem, Wallet_PaymentMethod walletPayMethod)
        {
            InitializeComponent();
            CurrentBalanceDue = selectedPayItem.CurrentBalanceDue;
            PaymentDetails paymentDetails = new PaymentDetails();
            paymentDetails.AmountToPay = selectedPayItem.CurrentBalanceDue.ToString();
            if (walletPayMethod != null)
            {
                paymentDetails.PaymentMethod = walletPayMethod.PaymentMethod;
                paymentDetails.ProgramID = walletPayMethod.ProgramId.ToString();
            }
            paymentDetails.PayableItemID = selectedPayItem.PayableItemId.ToString();
            paymentDetails.AccountTypeID = accountTypeID;
            paymentDetails.RoutingNumber = routingNumber.Text;
            paymentDetails.AccountNumber = accountNumber.Text;
            if (!String.IsNullOrEmpty(amtToPay.Text))
                paymentDetails.AmountToPay = amtToPay.Text.Replace("$", "");

            lblBalanceDue.Text = "$" + selectedPayItem.CurrentBalanceDue;
            amtToPay.Text = lblBalanceDue.Text;
            decimal conFee = 0;
            Device.BeginInvokeOnMainThread(async () =>
            {
                conFee = await BLL.Instance.GetConvenienceFeeByRenterID(paymentDetails);
                lblConvFee.Text = "$" + conFee.ToString();
                lblTotalAmt.Text = "$" + Math.Round((CurrentBalanceDue + conFee), 2);
            });
            //updBtn.Text = "Update And Pay $" + Math.Round((CurrentBalanceDue + conFee), 2).ToString();

            amtPayBtn.Clicked += async (sender, e) =>
            {
                try
                {
                    if (amtToPay.Text.Trim() != string.Empty)
                    {
                        paymentDetails.AmountToPay = amtToPay.Text.Replace("$", "");
                        decimal convFee = await BLL.Instance.GetConvenienceFeeByRenterID(paymentDetails);
                        lblConvFee.Text = "$" + convFee.ToString();
                        lblTotalAmt.Text = "$" + (CurrentBalanceDue - Convert.ToDecimal(amtToPay.Text)).ToString();
                        //updBtn.Text = "Update And Pay $" + Math.Round((Convert.ToDecimal(amtToPay.Text) + convFee), 2).ToString();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

            };

            cancelBtn.Clicked += (sender, e) =>
            {
                Navigation.PopAsync();
            };

            updBtn.Clicked += async  (sender, e) => {
                try
                {
                    if (Validations())
                    {
                        paymentDetails.AccountNumber = accountNumber.Text;
                        paymentDetails.AmountToPay = amtToPay.Text.Replace("$", "");
                        if(await BLL.Instance.DoECheckPaymentWithNewAch(paymentDetails))
                            await Navigation.PopAsync();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            };

            foreach (string item in types)
            {
                accountTypePicker.Items.Add(item);
            }
            accountTypePicker.SelectedIndex = 0;
            //Sep 19,2016 - as per Chris, the accoutn should be default to Checking and user
            //should not be allowed to select savings account as of now.
            accountTypePicker.IsEnabled = false;
            accountTypeID = "1";

        }

        void accountTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountTypePicker.Items[accountTypePicker.SelectedIndex] == "Checking Account")
                accountTypeID = "1";
            else
                accountTypeID = "2";
        }

        private bool Validations()
        {
            if (String.IsNullOrEmpty(routingNumber.Text))
            {
                DisplayAlert("Invalid Data", "Please enter a valid Routing Number.", "Ok");
                return false;
            }
            if (String.IsNullOrEmpty(accountNumber.Text))
            {
                DisplayAlert("Invalid Data", "Please enter a valid Account Number.", "Ok");
                return false;
            }

            return true;
        }
    }
}
