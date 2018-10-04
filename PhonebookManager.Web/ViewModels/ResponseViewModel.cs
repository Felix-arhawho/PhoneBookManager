using PhonebookManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookManager.Web.ViewModels
{
    public class ResponseViewModel
    {
        public List<ContactInfo> ContactInfos { get; set; }
        public bool BeginningOfTheList { get; set; }
        public bool EndOfTheList { get; set; }
    }
}