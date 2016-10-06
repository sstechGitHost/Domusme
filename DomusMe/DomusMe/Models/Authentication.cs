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
        public class AuthenticationResponse
        {

            private AuthenticationResponseAuthenticatedRenter authenticatedRenterField;

            private KeyValueOfintstring[] charityListField;

            private AuthenticationResponseContact[] contactListField;

            private decimal creditCardFeeField;

            private decimal eCheckFeeField;

            private ulong expirationDateField;

            private string messageField;

            private AuthenticationResponsePaymentItem[] paymentItemsField;

            private string programField;

            private string resultField;

            private string sessionIdField;

            private bool showDetailPaymentItemsField;

            /// <remarks/>
            public AuthenticationResponseAuthenticatedRenter AuthenticatedRenter
            {
                get
                {
                    return this.authenticatedRenterField;
                }
                set
                {
                    this.authenticatedRenterField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("KeyValueOfintstring", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable = false)]
            public KeyValueOfintstring[] CharityList
            {
                get
                {
                    return this.charityListField;
                }
                set
                {
                    this.charityListField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Contact", IsNullable = false)]
            public AuthenticationResponseContact[] ContactList
            {
                get
                {
                    return this.contactListField;
                }
                set
                {
                    this.contactListField = value;
                }
            }

            /// <remarks/>
            public decimal CreditCardFee
            {
                get
                {
                    return this.creditCardFeeField;
                }
                set
                {
                    this.creditCardFeeField = value;
                }
            }

            /// <remarks/>
            public decimal ECheckFee
            {
                get
                {
                    return this.eCheckFeeField;
                }
                set
                {
                    this.eCheckFeeField = value;
                }
            }

            /// <remarks/>
            public ulong ExpirationDate
            {
                get
                {
                    return this.expirationDateField;
                }
                set
                {
                    this.expirationDateField = value;
                }
            }

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
            [System.Xml.Serialization.XmlArrayItemAttribute("PaymentItem", IsNullable = false)]
            public AuthenticationResponsePaymentItem[] PaymentItems
            {
                get
                {
                    return this.paymentItemsField;
                }
                set
                {
                    this.paymentItemsField = value;
                }
            }

            /// <remarks/>
            public string Program
            {
                get
                {
                    return this.programField;
                }
                set
                {
                    this.programField = value;
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
            public string SessionId
            {
                get
                {
                    return this.sessionIdField;
                }
                set
                {
                    this.sessionIdField = value;
                }
            }

            /// <remarks/>
            public bool ShowDetailPaymentItems
            {
                get
                {
                    return this.showDetailPaymentItemsField;
                }
                set
                {
                    this.showDetailPaymentItemsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        public class AuthenticationResponseAuthenticatedRenter
        {

            private ulong rentDueDateField;

            private byte renterIdField;

            /// <remarks/>
            public ulong RentDueDate
            {
                get
                {
                    return this.rentDueDateField;
                }
                set
                {
                    this.rentDueDateField = value;
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
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable = false)]
        public class KeyValueOfintstring
        {

            private byte keyField;

            private string valueField;

            /// <remarks/>
            public byte Key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        public class AuthenticationResponseContact
        {

            private string emailAddressField;

            private string nameField;

            private string phoneNumberField;

            /// <remarks/>
            public string EmailAddress
            {
                get
                {
                    return this.emailAddressField;
                }
                set
                {
                    this.emailAddressField = value;
                }
            }

            /// <remarks/>
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            public string PhoneNumber
            {
                get
                {
                    return this.phoneNumberField;
                }
                set
                {
                    this.phoneNumberField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        public class AuthenticationResponsePaymentItem
        {

            private decimal amountField;

            private string descriptionField;

            private bool isCharityPaymentField;

            /// <remarks/>
            public decimal Amount
            {
                get
                {
                    return this.amountField;
                }
                set
                {
                    this.amountField = value;
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

            /// <remarks/>
            public bool IsCharityPayment
            {
                get
                {
                    return this.isCharityPaymentField;
                }
                set
                {
                    this.isCharityPaymentField = value;
                }
            }
        }


        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
        public partial class LogoutResponse
        {

            private string messageField;

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
