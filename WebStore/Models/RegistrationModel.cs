using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class RegistrationModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [DisplayName("First Name"), Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Billing Address"), Required]
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [MinLength(7), MaxLength(7), Required]
        public int Zipcode { get; set; }
    }
}