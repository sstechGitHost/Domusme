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
    public partial class MakePayment : ContentPage
    {
        decimal CurrentBalanceDue = 0;
        public MakePayment(Wallet_PaymentMethod selectedPayMethod, PayableItem selectedPayItem)
        {
            InitializeComponent();
            CurrentBalanceDue = selectedPayItem.CurrentBalanceDue;
            PaymentDetails paymentDetails = new PaymentDetails();
            paymentDetails.AmountToPay = selectedPayItem.CurrentBalanceDue.ToString();
            paymentDetails.PayableItemID = selectedPayItem.PayableItemId.ToString();
            if (selectedPayMethod != null)
            {
                paymentDetails.PaymentMethod = selectedPayMethod.PaymentMethod;
                paymentDetails.ProgramID = selectedPayMethod.ProgramId.ToString();
                paymentDetails.ProgramID = selectedPayMethod.ProgramId.ToString();
                paymentDetails.PayerWalletID = selectedPayMethod.PayerWalletId.ToString();
            }

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

            if (selectedPayMethod != null)
            {
                SetupCreditCard_CheckingAccountPayment(paymentDetails);
            }else{
                SetupCashPayment(selectedPayItem);
            }
        }

        private void SetupCashPayment(PayableItem selectedPayItem)
        {
            cashPayStack.IsVisible = true;
            ccAcPayStack.IsVisible = false;
            paymentTitleLbl.Text = "Submit a ticket to pay with Cash";
            cashPayDescription.Text = "Once the ticket is submitted you will receive an email with your confirmation and location where you can make payment";
            cashPayCurrentBalDueAmtlbl.Text = "$" + selectedPayItem.CurrentBalanceDue;
            btnCashPaySubmit.Text = "Submit Pay By Cash Ticket: " + cashPayCurrentBalDueAmtlbl.Text;
            btnCashPaySubmit.Clicked += async (sender, e) =>
            {
                Wallet_PayByCash payCashObj = await BLL.Instance.MakePaymentWithCash(selectedPayItem.CurrentBalanceDue.ToString());
                if (payCashObj != null && payCashObj.Result.ToLower() == "success")
                {
                    Device.OpenUri(new Uri(payCashObj.OrderUrl));
                }
                await Navigation.PopAsync();
            };
        }

        private void SetupCreditCard_CheckingAccountPayment(PaymentDetails paymentDetails)
        {
            ccAcPayStack.IsVisible = true;
            cashPayStack.IsVisible = false;

            string amtToPay = paymentDetails.AmountToPay;
            Device.BeginInvokeOnMainThread(async () =>
            {
                decimal conFee = await BLL.Instance.GetConvenienceFeeByRenterID(paymentDetails);
                lblConvFee.Text = "$" + conFee;
                lblTotalAmount.Text = "$" + Math.Round((Convert.ToDecimal(paymentDetails.AmountToPay) + conFee), 2);
                btnSubmitPayment.Text = "SUBMIT PAYMENT " + lblTotalAmount.Text;
            });
            

            if (paymentDetails.PaymentMethod)
            {
                csclayout.IsVisible = true;
            }

            //if (selectedPayItem.AllowPartialPayments)
            //{
            partialPayLayout.IsVisible = true;
            partialAmtPaid.Placeholder = "$" + paymentDetails.AmountToPay;
            btnUpdateTotalAmt.Clicked += async (sender, e) =>
            {
                if (partialAmtPaid.Text.Trim() != string.Empty)
                {
                    paymentDetails.AmountToPay = partialAmtPaid.Text;
                    decimal conFee = await BLL.Instance.GetConvenienceFeeByRenterID(paymentDetails);
                    lblConvFee.Text = "$" + conFee;
                    amtToPay = Math.Round((Convert.ToDecimal(partialAmtPaid.Text) + conFee), 2).ToString();
                    lblTotalAmount.Text = "$" + amtToPay;
                    btnSubmitPayment.Text = "SUBMIT PAYMENT " + lblTotalAmount.Text;
                }
            };
            //}

            lblBalance.Text = "$" + Math.Round(CurrentBalanceDue, 2);
            lblConvFee.Text = "$0";
            // lblTAmount.Text = //TO-DO: If Partial payment is allowed, then calculate the new total amt.


            btnSubmitPayment.Clicked += async (sender, e) =>
            {
                if (!String.IsNullOrEmpty(securitycode.Text))
                {
                    paymentDetails.CreditCardSecurityCode = securitycode.Text;
                }

                if (paymentDetails.PaymentMethod == true)
                {
                    if (!String.IsNullOrEmpty(securitycode.Text))
                    {
                        if(await BLL.Instance.DoCreditCardPayment(paymentDetails))
                            await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Invalid Data", "Please enter a valid Credit Security Code.", "Ok");
                    }
                }
                else
                {
                    if(await BLL.Instance.DoECheckPayment(paymentDetails))
                        await Navigation.PopAsync();
                }
            };
        }
    }
}
