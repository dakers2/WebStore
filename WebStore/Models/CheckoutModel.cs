using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class CheckoutModel
    {
        [DisplayName("First Name"), Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name"), Required]
        public string LastName { get; set; }

        [DisplayName("Billing Address"), Required]
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public short Zipcode { get; set; }

        [DisplayName("Shipping Method"), Required]
        public string ShippingMethod { get; set; }

        [DisplayName("Shipping Address"), Required]
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }

        [DisplayName("City"), Required]
        public string ShippingCity { get; set; }

        [DisplayName("State"), Required]
        public string ShippingState { get; set; }

        [DisplayName("Zipcode"), Required]
        public int ShippingZipcode { get; set; }

        [DisplayName("Credit Card Number"), Required, CreditCard]
        public int CreditCardNumber { get; set; }

        [DisplayName("Name On Card"), Required]
        public string CreditCardName { get; set; }

        [DisplayName("Expiration Month"), Required]
        public string ExpirationMonth { get; set; }

        [DisplayName("Expiration Year"), Required]
        public int ExpirationYear { get; set; }

        [DisplayName("V-code"), Required]
        public int VCode { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

    }
}