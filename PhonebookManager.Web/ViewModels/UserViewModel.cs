using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookManager.Web.ViewModels
{
    public class UserViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}