using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomusMe.Models
{
    public class PaymentDetails
    {
        public string ProgramID { get; set; }
        public bool PaymentMethod { get; set; }
        public string PayerWalletID { get; set; }
        public string PayableItemID { get; set; }
        public string AmountToPay{ get; set; }
        
        public string AccountTypeID { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }

        public string CCHolderName { get; set; }
        public string CCExpMonth { get; set; }
        public string CCExpYear { get; set; }
        public string CreditCardSecurityCode { get; set; }
    }
}
