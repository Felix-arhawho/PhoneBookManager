using Microsoft.AspNet.Identity.EntityFramework;
using PhonebookManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookManager.DataAccess.Context
{
    public class PhonebookManagerContext : IdentityDbContext<User>
    {
        public PhonebookManagerContext() : base("PhonebookManager")
        {
        }

        public virtual DbSet<ContactInfo> ContactInfos { get; set; }

        public static PhonebookManagerContext Create()
        {
            return new PhonebookManagerContext();
        }
    }
}
