using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DomusMe.Models
{
    public class ResidentDetail
    {
        public string FirstName;
        public string LastName;
        public string RenterID;
        public string city;
        public string postalCode;
        public string stateprov;
        public string streetaddress;
    }

    public class PayItems
    {
        public int PayableItemID { get; set; }
        public string PaymentDueDate { get; set; }
        public string PayDescription{ get; set; }
        public string Amount_Pay{ get; set; }
        public string CurrentBalanceDue{ get; set; }

    }


    public class ResidentPayItems
    {
        public int PayableItemID;
        public int RenterID;
        public int LeaseID;
        public int PropertyID;
        public DateTime PaymentDueDate;
        public string PayDescription;
        public decimal Amount_Pay;
        public bool editable;
        public bool Paychoose;
        public decimal AverageMonthlyRent;
        public decimal CurrentBalanceDue;

    }


    //[XmlRoot(ElementName = "PayableItem", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //public class PayableItem
    //{
    //    [XmlElement(ElementName = "Amount_PAY", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string Amount_PAY { get; set; }
    //    [XmlElement(ElementName = "AverageMonthlyRent", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string AverageMonthlyRent { get; set; }
    //    [XmlElement(ElementName = "CurrentBalanceDue", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string CurrentBalanceDue { get; set; }
    //    [XmlElement(ElementName = "Description", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string Description { get; set; }
    //    [XmlElement(ElementName = "Editable", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string Editable { get; set; }
    //    [XmlElement(ElementName = "LeaseId", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string LeaseId { get; set; }
    //    [XmlElement(ElementName = "PayChoose", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string PayChoose { get; set; }
    //    [XmlElement(ElementName = "PayableDueDate", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string PayableDueDate { get; set; }
    //    [XmlElement(ElementName = "PayableItemId", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string PayableItemId { get; set; }
    //    [XmlElement(ElementName = "PropertyId", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string PropertyId { get; set; }
    //    [XmlElement(ElementName = "RenterId", Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework")]
    //    public string RenterId { get; set; }
    //    [XmlAttribute(AttributeName = "a", Namespace = "http://www.w3.org/2000/xmlns/")]
    //    public string A { get; set; }
    //}




        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile", IsNullable = false)]
        public partial class GetRenterByRenterIdResponse
        {

            private string messageField;

            private GetRenterByRenterIdResponseRenter renterField;

            private string resultField;

            private bool showDetailPaymentItemsField;

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
            public GetRenterByRenterIdResponseRenter Renter
            {
                get
                {
                    return this.renterField;
                }
                set
                {
                    this.renterField = value;
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
        public partial class GetRenterByRenterIdResponseRenter
        {

            private ulong rentDueDateField;

            private byte renterIdField;

            private GetRenterByRenterIdResponseRenterAddress addressField;

            private string emailAddressField;

            private string firstNameField;

            private bool isRentLateField;

            private string lastNameField;

            private GetRenterByRenterIdResponseRenterPaymentItem[] paymentItemsField;

            private ulong phoneNumberField;

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

            /// <remarks/>
            public GetRenterByRenterIdResponseRenterAddress Address
            {
                get
                {
                    return this.addressField;
                }
                set
                {
                    this.addressField = value;
                }
            }

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

            public string FullName
            {
                get { return (this.firstNameField + " " + this.lastNameField).ToUpper(); }    
            }

            public string FullAddress
            {
                get { return (this.Address.City + ", " + this.Address.StateProvince + " " + this.Address.PostalCode).ToUpper(); }
            }
            /// <remarks/>
            public string FirstName
            {
                get
                {
                    return this.firstNameField;
                }
                set
                {
                    this.firstNameField = value;
                }
            }

            /// <remarks/>
            public bool IsRentLate
            {
                get
                {
                    return this.isRentLateField;
                }
                set
                {
                    this.isRentLateField = value;
                }
            }

            /// <remarks/>
            public string LastName
            {
                get
                {
                    return this.lastNameField;
                }
                set
                {
                    this.lastNameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("PaymentItem", IsNullable = false)]
            public GetRenterByRenterIdResponseRenterPaymentItem[] PaymentItems
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
            public ulong PhoneNumber
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
        public partial class GetRenterByRenterIdResponseRenterAddress
        {

            private string cityField;

            private ushort postalCodeField;

            private string stateProvinceField;

            private string streetAddressField;

            private object unitField;

            /// <remarks/>
            public string City
            {
                get
                {
                    return this.cityField;
                }
                set
                {
                    this.cityField = value;
                }
            }

            /// <remarks/>
            public ushort PostalCode
            {
                get
                {
                    return this.postalCodeField;
                }
                set
                {
                    this.postalCodeField = value;
                }
            }

            /// <remarks/>
            public string StateProvince
            {
                get
                {
                    return this.stateProvinceField;
                }
                set
                {
                    this.stateProvinceField = value;
                }
            }

            /// <remarks/>
            public string StreetAddress
            {
                get
                {
                    return this.streetAddressField.ToUpper();
                }
                set
                {
                    this.streetAddressField = value;
                }
            }

            /// <remarks/>
            public object Unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/EfxFramework.Mobile")]
        public partial class GetRenterByRenterIdResponseRenterPaymentItem
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


}
