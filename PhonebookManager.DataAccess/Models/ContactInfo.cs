using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookManager.DataAccess.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string EmailAddress { get; set; }
    }
}
