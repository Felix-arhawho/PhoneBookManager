using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookManager.Web.ViewModels
{
    public class ContactInfoViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string EmailAddress { get; set; }
    }
}