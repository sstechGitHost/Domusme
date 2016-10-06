using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomusMe.Models
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
    public partial class Wallet_GetPaymentMethodsResponse
    {

        private string messageField;

        private string resultField;

        private Wallet_PaymentMethod[] wallet_PaymentMethodsField;

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

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Wallet_PaymentMethod", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework", IsNullable = false)]
        public Wallet_PaymentMethod[] Wallet_PaymentMethods
        {
            get
            {
                return this.wallet_PaymentMethodsField;
            }
            set
            {
                this.wallet_PaymentMethodsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework", IsNullable = false)]
    public partial class Wallet_PaymentMethod
    {

        private bool autoSetField;

        private string descriptionField;

        private string eXP_DateField;

        private bool editableField;

        private bool isPrimaryField;

        private bool payChooseField;

        private byte payerIdField;

        private ushort payerMethodIdField;

        private ushort payerWalletIdField;

        private bool paymentMethodField;

        private byte programIdField;

        private bool requestSecurityCodeField;

        private bool usedLastTimeField;

        private string paymentMethodNameField;

        private bool isPayMethodsOptionsVisible;


        /// <remarks/>
        public bool AutoSet
        {
            get
            {
                return this.autoSetField;
            }
            set
            {
                this.autoSetField = value;
            }
        }


        public bool IsPayMethodsOptionsVisible
        {
            get
            {
                return this.isPayMethodsOptionsVisible;
            }
            set
            {
                this.isPayMethodsOptionsVisible = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        public string PayMethodName
        {
            get
            {
                if (this.paymentMethodField)
                    this.paymentMethodNameField = "Credit Card";
                else
                    this.paymentMethodNameField = "E-Check";

                return this.paymentMethodNameField;
            }
            set
            {
                this.paymentMethodNameField = value;
            }
        }

        /// <remarks/>
        
        public string EXP_Date
        {
            get
            {
                return this.eXP_DateField;
            }
            set
            {
                this.eXP_DateField = value;
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
        public bool IsPrimary
        {
            get
            {
                return this.isPrimaryField;
            }
            set
            {
                this.isPrimaryField = value;
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
        public byte PayerId
        {
            get
            {
                return this.payerIdField;
            }
            set
            {
                this.payerIdField = value;
            }
        }

        /// <remarks/>
        public ushort PayerMethodId
        {
            get
            {
                return this.payerMethodIdField;
            }
            set
            {
                this.payerMethodIdField = value;
            }
        }

        /// <remarks/>
        public ushort PayerWalletId
        {
            get
            {
                return this.payerWalletIdField;
            }
            set
            {
                this.payerWalletIdField = value;
            }
        }

        /// <remarks/>
        public bool PaymentMethod
        {
            get
            {
                return this.paymentMethodField;
            }
            set
            {
                this.paymentMethodField = value;
            }
        }

        /// <remarks/>
        public byte ProgramId
        {
            get
            {
                return this.programIdField;
            }
            set
            {
                this.programIdField = value;
            }
        }

        /// <remarks/>
        public bool RequestSecurityCode
        {
            get
            {
                return this.requestSecurityCodeField;
            }
            set
            {
                this.requestSecurityCodeField = value;
            }
        }

        /// <remarks/>
        public bool UsedLastTime
        {
            get
            {
                return this.usedLastTimeField;
            }
            set
            {
                this.usedLastTimeField = value;
            }
        }
    }




    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
    public partial class GetConvFeeForPayment_Response
    {

        private decimal convenienceFeeField;

        private object messageField;

        private string resultField;

        /// <remarks/>
        public decimal ConvenienceFee
        {
            get
            {
                return this.convenienceFeeField;
            }
            set
            {
                this.convenienceFeeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object Message
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

   


}
