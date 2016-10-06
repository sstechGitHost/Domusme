using DomusMe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net.Http;

namespace DomusMe
{
    public class BLL
    {
        private static readonly BLL bllClient = new BLL();
        private static readonly HttpClient httpClient = new HttpClient();

        public static BLL Instance
        {
            get { return bllClient; }
        }
        public static HttpClient HttpClientIstance
        {
            get { return httpClient; }
        }

        string _webMethodName = string.Empty;
        private string WebMethodName
        {
            get { return _webMethodName; }
            set {_webMethodName = value;}
        }
        
        string _url;
        private string Url
        {
            get {
                StringBuilder urlString = new StringBuilder(Const.BaseURL);
                return urlString.Append(WebMethodName).Append(Const.SessionID).Append("/").Append(Const.RenterID).ToString();
            }
            set { _url = value;}
        }

        public T GetSerialedObject<T>(string url)
        {
            T obj = default(T);

            if (url.Trim() != string.Empty)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StringReader rdr = new StringReader(url))
                {
                    obj = (T)serializer.Deserialize(rdr);
                }
            }
            return obj;
        }

        #region RENTER
        public async Task<GetRenterByRenterIdResponse> GetRenterDetails()
        {
            WebMethodName = "GetRenterByRenterId/";
            Task<string> getStringTask = HttpClientIstance.GetStringAsync(Url);
            string urlContents = await getStringTask;
            return GetSerialedObject<GetRenterByRenterIdResponse>(urlContents);
        }

        public async Task<GetPayableFeeDetailResponse> GetRentFeeDetails()
        {
            WebMethodName = "GetPayableFeeDetail/";
            Task<string> getStringTask = HttpClientIstance.GetStringAsync(Url);
            string urlContents = await getStringTask;
            return GetSerialedObject<GetPayableFeeDetailResponse>(urlContents);
        }


        #endregion

        #region PAY ITEMS
        public async Task<PayablesResponse> GetPayableItems()
        {
            WebMethodName = "GetPayableItemsForRenter/";
            Task<string> getStringTask = HttpClientIstance.GetStringAsync(Url);
            string urlContents = await getStringTask;
            return GetSerialedObject<PayablesResponse>(urlContents);
        }

        #endregion

        #region WALLET ITEMS

        public async Task<Wallet_GetPaymentMethodsResponse> GetWalletItems()
        {
            WebMethodName = "Wallet_GetPaymentMethodsForRenter/";
            Task<string> getStringTask = HttpClientIstance.GetStringAsync(Url);
            string urlContents = await getStringTask;
            return GetSerialedObject<Wallet_GetPaymentMethodsResponse>(urlContents);
        }

        #endregion

        #region LOGIN

        public async Task<AuthenticationResponse> Login(string userName, string passWord)
        {

            string url = Const.BaseURL + "Authenticate/" + userName + "/" + passWord;
            Task<string> getStringTask = HttpClientIstance.GetStringAsync(url);

            string urlContents = await getStringTask;

            if (!urlContents.Contains("The user failed to login"))
            {
                return GetSerialedObject<AuthenticationResponse>(urlContents);
            }

            return null;
        }

        public async Task<LogoutResponse> Logout()
        {
            string url = Const.BaseURL + "Logout/" + Const.SessionID;
            Task<string> getStringTask = HttpClientIstance.GetStringAsync(url);
            string urlContents = await getStringTask;
            return GetSerialedObject<LogoutResponse>(urlContents);
        }

        #endregion

        #region PAYMENT TRANSACTIONS
        //For CreditCard and check account, the amtToPay = RentBeingPaid and not
        //RentBeingPaid + ConvenienceFee. ConvenienceFee is only for display

        public async Task<GetConvFeeForPayment_Response> GetConvenienceFee(PaymentDetails paymentDetails)
        {
            string paymentMethod = string.Empty;
            if (paymentDetails.PaymentMethod)
                paymentMethod = "CC";
            else
                paymentMethod = "CK";

            string url = Const.BaseURL + "GetConvenienceFeeForPaymentByProgramID/" + paymentDetails.ProgramID + "/" + paymentMethod + "/" + paymentDetails.AmountToPay;

            Task<string> getStringTask = HttpClientIstance.GetStringAsync(url);
            string urlContents = await getStringTask;

            if (!urlContents.Contains("GeneralFailure"))
            {
                return GetSerialedObject<GetConvFeeForPayment_Response>(urlContents);
            }
            return null;
        }

        public async Task<decimal> GetConvenienceFeeByRenterID(PaymentDetails paymentDetails)
        {
            decimal retVal = 0;
            string paymentMethod = string.Empty;
            if (paymentDetails.PaymentMethod)
                paymentMethod = "true";
            else
                paymentMethod = "false";

            try
            {
                string url = Const.BaseURL + "GetConvenienceFeeForPaymentByRenterID/" + Const.RenterID + "/" + paymentMethod + "/" + paymentDetails.AmountToPay;

                Task<string> getStringTask = HttpClientIstance.GetStringAsync(url);

                string urlContents = await getStringTask;

                if (!urlContents.Contains("GeneralFailure"))
                {
                    GetConvFeeForPayment_Response obj = GetSerialedObject<GetConvFeeForPayment_Response>(urlContents);
                    if (!string.IsNullOrEmpty(obj.Result))
                        retVal = Math.Round(obj.ConvenienceFee, 2);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return retVal;
        }


        public async Task<Wallet_PayByCash> MakePaymentWithCash(string amtToPay)
        {
            //For test only
            amtToPay = "100";
            string url = Const.BaseURL + "Wallet_PayWithCash/" + Const.RenterID + "/" + amtToPay;

            Task<string> getStringTask = HttpClientIstance.GetStringAsync(url);
            string urlContents = await getStringTask;

            if (!urlContents.ToLower().Contains("generalfailure"))
            {
                return GetSerialedObject<Wallet_PayByCash>(urlContents);
            }

            return null;
        }

        public async Task<bool> DoCreditCardPayment(PaymentDetails paymentDetails)
        {
            try
            {
                WebMethodName = "Wallet_PaySingleItemForRenterWithCSC/";
                StringBuilder _webUrl = new StringBuilder(Url);
                _webUrl.Append("/").Append(paymentDetails.PayerWalletID).Append("/").Append(paymentDetails.PayableItemID).Append("/")
                    .Append(paymentDetails.AmountToPay).Append("/").Append(paymentDetails.CreditCardSecurityCode);


                Task<string> getStringTask = HttpClientIstance.GetStringAsync(_webUrl.ToString());
                string urlContents = await getStringTask;
                Wallet_PaySingleItemResponse retObj = GetSerialedObject<Wallet_PaySingleItemResponse>(urlContents);
                Debug.WriteLine("Wallet_PaySingleItemForRenterWithCSC: " + retObj.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return true;
        }

        public async Task<bool> DoECheckPayment(PaymentDetails paymentDetails)
        {
            try
            {
                WebMethodName = "Wallet_PaySingleItemForRenter/";
                StringBuilder _webUrl = new StringBuilder(Url);
                _webUrl.Append("/").Append(paymentDetails.PayerWalletID).Append("/").Append(paymentDetails.PayableItemID).Append("/").Append(paymentDetails.AmountToPay);

                Task<string> getStringTask = HttpClientIstance.GetStringAsync(_webUrl.ToString());
                string urlContents = await getStringTask;

                Wallet_PaySingleItemResponse retObj = GetSerialedObject<Wallet_PaySingleItemResponse>(urlContents);
                Debug.WriteLine("Wallet_PaySingleItemForRenter Check Account: " + retObj.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return true;
        }

        public async Task<bool> DoCreditCardPaymentWithNewCC(PaymentDetails paymentDetails)
        {
            ///Wallet_PaySingleItemForRenterWithNewCC/{SessionId}/{RenterId}/{PayableItemId}/{AmountToPay}/{CCHolderName}/{CCAccountNumber}/{CCExpMonth}/{CCExpYear}/{CardSecurity Code}
            ///
            try
            {
                WebMethodName = "Wallet_PaySingleItemForRenterWithNewCC/";
                StringBuilder _webUrl = new StringBuilder(Url);
                _webUrl.Append("/").Append(paymentDetails.PayableItemID).Append("/").Append(paymentDetails.AmountToPay).Append("/").Append(paymentDetails.CCHolderName)
                    .Append("/").Append(paymentDetails.AccountNumber).Append("/").Append(paymentDetails.CCExpMonth).Append("/").Append(paymentDetails.CCExpYear)
                    .Append("/").Append(paymentDetails.CreditCardSecurityCode);


                Task<string> getStringTask = HttpClientIstance.GetStringAsync(_webUrl.ToString());
                string urlContents = await getStringTask;

                Wallet_PaySingleItemResponse retObj = GetSerialedObject<Wallet_PaySingleItemResponse>(urlContents);
                Debug.WriteLine("DoCreditCardPaymentWithNewCC: " + retObj.Message);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return true;

        }

        public async Task<bool> DoECheckPaymentWithNewAch(PaymentDetails paymentDetails)
        {
            ///Wallet_PaySingleItemForRenterWithNewAch/{SessionId}/{RenterId}/{PayableItemId}/{AmountToPay}/{AccountTypeId}/{AccountNumber}/{RoutingNumber}
            ///
            try
            {
                WebMethodName = "Wallet_PaySingleItemForRenterWithNewAch/";
                StringBuilder _webUrl = new StringBuilder(Url);
                _webUrl.Append("/").Append(paymentDetails.PayableItemID).Append("/").Append(paymentDetails.AmountToPay).Append("/").Append(paymentDetails.AccountTypeID)
                    .Append("/").Append(paymentDetails.AccountNumber).Append("/").Append(paymentDetails.RoutingNumber);

                Task<string> getStringTask = HttpClientIstance.GetStringAsync(_webUrl.ToString());
                string urlContents = await getStringTask;

                Wallet_PaySingleItemResponse retObj = GetSerialedObject<Wallet_PaySingleItemResponse>(urlContents);
                Debug.WriteLine("DoECheckPaymentWithNewAch: " + retObj.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return true;
        }
        #endregion
    }
}
