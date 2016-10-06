using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DomusMe.Models
{
    
/* OLD PAYABLE ITEMS MODEL
    [XmlRoot(ElementName = "PayableItem", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    public class PayableItem
    {
        [XmlElement(ElementName = "AllowPartialPayments", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string AllowPartialPayments { get; set; }
        [XmlElement(ElementName = "Amount_PAY", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string Amount_PAY { get; set; }
        [XmlElement(ElementName = "AverageMonthlyRent", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string AverageMonthlyRent { get; set; }
        [XmlElement(ElementName = "CurrentBalanceDue", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string CurrentBalanceDue { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Editable", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string Editable { get; set; }
        [XmlElement(ElementName = "FeeTotal", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string FeeTotal { get; set; }
        [XmlElement(ElementName = "LeaseId", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string LeaseId { get; set; }
        [XmlElement(ElementName = "PayChoose", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string PayChoose { get; set; }
        [XmlElement(ElementName = "PayableDueDate", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string PayableDueDate { get; set; }
        [XmlElement(ElementName = "PayableItemId", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string PayableItemId { get; set; }
        [XmlElement(ElementName = "PropertyId", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string PropertyId { get; set; }
        [XmlElement(ElementName = "RentAmount", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string RentAmount { get; set; }
        [XmlElement(ElementName = "RenterId", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public string RenterId { get; set; }
        public bool IsVisibleItem { get; set; }
    }

    [XmlRoot(ElementName = "PayableItems", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    public class PayableItems
    {
        [XmlElement(ElementName = "PayableItem", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public List<PayableItem> PayableItem { get; set; }
        [XmlAttribute(AttributeName = "a", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string A { get; set; }
    }

    [XmlRoot(ElementName = "PayablesResponse", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    public class PayablesResponse
    {
        [XmlElement(ElementName = "Message", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        public string Message { get; set; }
        [XmlElement(ElementName = "PayableItems", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        public PayableItems PayableItems { get; set; }
        [XmlElement(ElementName = "Result", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        public string Result { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "i", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string I { get; set; }
    }
    */


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
    public partial class PayablesResponse
    {

        private string messageField;

        private PayablesResponsePayableItems payableItemsField;

        private string resultField;

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public PayablesResponsePayableItems PayableItems
        {
            get
            {
                return this.payableItemsField;
            }
            set
            {
                this.payableItemsField = value;
            }
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    public partial class PayablesResponsePayableItems
    {

        private PayableItem payableItemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
        public PayableItem PayableItem
        {
            get
            {
                return this.payableItemField;
            }
            set
            {
                this.payableItemField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework", IsNullable = false)]
    public partial class PayableItem
    {

        private byte acceptedPaymentTypeIDField;

        private bool allowPartialPaymentsField;

        private decimal averageMonthlyRentField;

        private decimal currentBalanceDueField;

        private string descriptionField;

        private bool editableField;

        private decimal feeTotalField;

        private string feeTotalDetails;

        private byte leaseIdField;

        private bool payChooseField;

        private decimal payLimitField;

        private string payMessageField;

        private System.DateTime payableDueDateField;

        private byte payableItemIdField;

        private byte propertyIdField;

        private decimal rentAmountField;

        private byte renterIdField;

        private string dueDate;
        public string DueDate { 
            get { return "Due Date: " + this.payableDueDateField.ToString("MM/dd/yyyy"); }
            set
            {
                this.dueDate = value; 
            }
        }

        private string rentAmt;
        public string RentAmt { 
            get { return "Amount: $" + Math.Round(this.rentAmountField, 2); }
            set { this.rentAmt = value; } 
        }

        private string currentDueBalance;
        public string CurrentDueBal { 
            get { return "Balance: $" + Math.Round(this.currentBalanceDueField, 2); }
            set { this.currentDueBalance = value; } 
        }
        /// <remarks/>
        /// 
        public string FeeTotalDetails {
            get { return  "Fee Total: $" + this.feeTotalField; }
            set
            {
                this.feeTotalDetails = value;
            }
        }
        public byte AcceptedPaymentTypeID
        {
            get
            {
                return this.acceptedPaymentTypeIDField;
            }
            set
            {
                this.acceptedPaymentTypeIDField = value;
            }
        }

        /// <remarks/>
        public bool AllowPartialPayments
        {
            get
            {
                return this.allowPartialPaymentsField;
            }
            set
            {
                this.allowPartialPaymentsField = value;
            }
        }

        /// <remarks/>
        public decimal AverageMonthlyRent
        {
            get
            {
                return this.averageMonthlyRentField;
            }
            set
            {
                this.averageMonthlyRentField = value;
            }
        }

        /// <remarks/>
        public decimal CurrentBalanceDue
        {
            get
            {
                return this.currentBalanceDueField;
            }
            set
            {
                this.currentBalanceDueField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return "Description: " + this.descriptionField.Substring(0, 13).Trim();
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public bool Editable
        {
            get
            {
                return this.editableField;
            }
            set
            {
                this.editableField = value;
            }
        }

        /// <remarks/>
        public decimal FeeTotal
        {
            get
            {
                return this.feeTotalField;
            }
            set
            {
                this.feeTotalField = value;
            }
        }

        /// <remarks/>
        public byte LeaseId
        {
            get
            {
                return this.leaseIdField;
            }
            set
            {
                this.leaseIdField = value;
            }
        }

        /// <remarks/>
        public bool PayChoose
        {
            get
            {
                return this.payChooseField;
            }
            set
            {
                this.payChooseField = value;
            }
        }

        /// <remarks/>
        public decimal PayLimit
        {
            get
            {
                return this.payLimitField;
            }
            set
            {
                this.payLimitField = value;
            }
        }

        /// <remarks/>
        public string PayMessage
        {
            get
            {
                return this.payMessageField;
            }
            set
            {
                this.payMessageField = value;
            }
        }

        /// <remarks/>
        public System.DateTime PayableDueDate
        {
            get
            {
                return this.payableDueDateField;
            }
            set
            {
                this.payableDueDateField = value;
            }
        }

        /// <remarks/>
        public byte PayableItemId
        {
            get
            {
                return this.payableItemIdField;
            }
            set
            {
                this.payableItemIdField = value;
            }
        }

        /// <remarks/>
        public byte PropertyId
        {
            get
            {
                return this.propertyIdField;
            }
            set
            {
                this.propertyIdField = value;
            }
        }

        /// <remarks/>
        public decimal RentAmount
        {
            get
            {
                return this.rentAmountField;
            }
            set
            {
                this.rentAmountField = value;
            }
        }

        /// <remarks/>
        public byte RenterId
        {
            get
            {
                return this.renterIdField;
            }
            set
            {
                this.renterIdField = value;
            }
        }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
    public class Wallet_PaySingleItemResponse
    {
        private string messageField;
        private string resultField;
        private string transactionIdField;

        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        public string Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        public string TransactionId
        {
            get
            {
                return this.transactionIdField;
            }
            set
            {
                this.transactionIdField = value;
            }
        }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
    public partial class Wallet_AddCCPaymentMethodResponse
    {

        private string messageField;

        private string resultField;

        private string wallet_PaymentMethodIdField;

        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        public string Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        public string Wallet_PaymentMethodId
        {
            get
            {
                return this.wallet_PaymentMethodIdField;
            }
            set
            {
                this.wallet_PaymentMethodIdField = value;
            }
        }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
    public partial class Wallet_AddACHPaymentMethodResponse
    {

        private string messageField;

        private string resultField;

        private string wallet_PaymentMethodIdField;

        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        public string Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        public string Wallet_PaymentMethodId
        {
            get
            {
                return this.wallet_PaymentMethodIdField;
            }
            set
            {
                this.wallet_PaymentMethodIdField = value;
            }
        }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
    public partial class GetPayableFeeDetailResponse
    {

        private string messageField;

        private PayableItem_FeeDetail[] payableItem_FeeDetailItemsField;

        private string resultField;

        /// <remarks/>
        public string Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PayableItem_FeeDetail", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework", IsNullable = false)]
        public PayableItem_FeeDetail[] PayableItem_FeeDetailItems
        {
            get
            {
                return this.payableItem_FeeDetailItemsField;
            }
            set
            {
                this.payableItem_FeeDetailItemsField = value;
            }
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework", IsNullable = false)]
    public partial class PayableItem_FeeDetail
    {

        private object chargeCodeField;

        private string feeAmountField;

        private string feeNameField;

        private byte monthlyFeeIdField;

        private ushort payableItemFeeIdField;

        private byte payableItemsIdField;

        /// <remarks/>
        public object ChargeCode
        {
            get
            {
                return this.chargeCodeField;
            }
            set
            {
                this.chargeCodeField = value;
            }
        }

        /// <remarks/>
        public string FeeAmount
        {
            get
            {
                return "$" + this.feeAmountField;
            }
            set
            {
                this.feeAmountField = value;
            }
        }

        /// <remarks/>
        public string FeeName
        {
            get
            {
                return this.feeNameField;
            }
            set
            {
                this.feeNameField = value;
            }
        }

        /// <remarks/>
        public byte MonthlyFeeId
        {
            get
            {
                return this.monthlyFeeIdField;
            }
            set
            {
                this.monthlyFeeIdField = value;
            }
        }

        /// <remarks/>
        public ushort PayableItemFeeId
        {
            get
            {
                return this.payableItemFeeIdField;
            }
            set
            {
                this.payableItemFeeIdField = value;
            }
        }

        /// <remarks/>
        public byte PayableItemsId
        {
            get
            {
                return this.payableItemsIdField;
            }
            set
            {
                this.payableItemsIdField = value;
            }
        }
    }


}
