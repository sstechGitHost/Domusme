using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomusMe.Models
{
    class CashPayMent
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
    public partial class Wallet_PayByCash
    {

        private string messageField;

        private string orderUrlField;

        private string resultField;

        private string statusField;

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
        public string OrderUrl
        {
            get
            {
                return this.orderUrlField;
            }
            set
            {
                this.orderUrlField = value;
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
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }


}
