using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class AccountDetailsModel
    {
        //properties that the user can edit in their account profile
        [DisplayName("First Name"), Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name"), Required]
        public string LastName { get; set; }
    }
}