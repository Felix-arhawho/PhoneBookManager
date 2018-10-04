using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookManager.Web.ViewModels
{
    public class PaginationViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}