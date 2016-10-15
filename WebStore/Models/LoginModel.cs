using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(7)]
        public string Password { get; set; }
    }
}