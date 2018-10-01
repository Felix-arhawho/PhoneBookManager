using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhonebookManager.Web.Controllers.Mvc
{
    public class ContactInfoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListOfContactInfo()
        {
            return PartialView("_ListOfContactInfo");
        }

        public ActionResult ViewContactInfo()
        {
            return PartialView("_ViewContactInfo");
        }

        public ActionResult CreateContactInfo()
        {
            return PartialView("_CreateContactInfo");
        }

        public ActionResult EditContactInfo()
        {
            return PartialView("_EditContactInfo");
        }

        public ActionResult DeleteContactInfo()
        {
            return PartialView("_DeleteContactInfo");
        }
    }
}