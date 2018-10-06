using PhonebookManager.DataAccess.Context;
using PhonebookManager.DataAccess.Models;
using PhonebookManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhonebookManager.Web.Controllers.Api
{
    [Authorize, RoutePrefix("api/ContactInfo")]
    public class ContactInfoController : ApiController
    {
        //Used db context in controller due to size of project.
        private PhonebookManagerContext _context;
        private HttpResponseMessage message;
        private ResponseViewModel responseViewModel;
        public ContactInfoController()
        {
            _context = new PhonebookManagerContext();
        }

        [Route("GetAllContactInfo"), HttpPost]
        public HttpResponseMessage GetAllContactInfo(ContactInfoViewModel contactInfoViewModel)
        {
            responseViewModel = new ResponseViewModel();
            var searchResult = new List<ContactInfo>();

            try
            {
                if (contactInfoViewModel.SearchViewModel != null)
                {
                    switch (contactInfoViewModel.SearchViewModel.SearchBy)
                    {
                        case "Name":
                            searchResult = _context.ContactInfos.Where(n => n.FullName
                                                .Contains(contactInfoViewModel.SearchViewModel.SearchContent)).ToList();
                            break;
                        case "Email":
                            searchResult = _context.ContactInfos.Where(e => e.EmailAddress
                                                .Contains(contactInfoViewModel.SearchViewModel.SearchContent)).ToList();
                            break;
                    }
                    if (searchResult.Count == 0)
                    {
                        message = Request.CreateResponse(HttpStatusCode.NoContent, "Sorry, there is no record with "
                                                + contactInfoViewModel.SearchViewModel.SearchContent);
                    }
                    else
                    {
                        var firstContactInfo = searchResult[0];
                        var lastContactInfo = searchResult[searchResult.Count - 1];

                        responseViewModel.ContactInfos = (searchResult.Skip((contactInfoViewModel.PaginationViewModel.PageIndex - 1)
                                                         * contactInfoViewModel.PaginationViewModel.PageSize)
                                                         .Take(contactInfoViewModel.PaginationViewModel.PageSize)).ToList();

                        foreach(var contactInfo in responseViewModel.ContactInfos)
                        {
                            if (contactInfo == firstContactInfo)
                            {
                                responseViewModel.BeginningOfTheList = true;
                            }

                            if (contactInfo == lastContactInfo)
                            {
                                responseViewModel.EndOfTheList = true;
                            }
                        }

                        message = Request.CreateResponse(HttpStatusCode.OK, responseViewModel);
                    }
                }
                else
                {
                    //var contactInfos = _context.ContactInfos.ToList();
                    var firstContactInfo = _context.ContactInfos.FirstOrDefault();
                    var lastContactInfo = _context.ContactInfos.OrderByDescending(c => c.Id).FirstOrDefault();

                    responseViewModel.ContactInfos = (_context.ContactInfos.OrderBy(c => c.Id)
                                                     .Skip((contactInfoViewModel.PaginationViewModel.PageIndex - 1)
                                                     * contactInfoViewModel.PaginationViewModel.PageSize)
                                                     .Take(contactInfoViewModel.PaginationViewModel.PageSize)).ToList();

                    foreach (var ContactInfo in responseViewModel.ContactInfos)
                    {
                        if (ContactInfo == firstContactInfo)
                        {
                            responseViewModel.BeginningOfTheList = true;
                        }

                        if (ContactInfo == lastContactInfo)
                        {
                            responseViewModel.EndOfTheList = true;
                        }
                    }

                    message = Request.CreateResponse(HttpStatusCode.OK, responseViewModel);
                }
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return message;
        }

        [HttpPost, Route("SearchContactInfo")]
        public HttpResponseMessage SearchContactInfo(SearchViewModel searchVM)
        {
            responseViewModel = new ResponseViewModel();

            switch (searchVM.SearchBy)
            {
                case "Name":
                    responseViewModel.ContactInfos = _context.ContactInfos
                                            .Where(n => n.FullName.Contains(searchVM.SearchContent)).ToList();
                    break;
                case "Email":
                    responseViewModel.ContactInfos = _context.ContactInfos
                                            .Where(e => e.EmailAddress.Contains(searchVM.SearchContent)).ToList();
                    break;
            }
            if (responseViewModel.ContactInfos.Count == 0)
            {
                message = Request.CreateResponse(
                    HttpStatusCode.NoContent, "Sorry, there is no record with " + searchVM.SearchContent);
            }
            else
            {
                var firstContactInfo = responseViewModel.ContactInfos[0];
                var lastContactInfo = responseViewModel.ContactInfos[responseViewModel.ContactInfos.Count - 1];
                message = Request.CreateResponse(HttpStatusCode.OK, responseViewModel.ContactInfos);
            }
            return message;
        }

        [HttpPost, Route("PaginatedContactInfo")]
        public HttpResponseMessage PaginatedContactInfo(PaginationViewModel paginationVM)
        {
            responseViewModel = new ResponseViewModel();
            try
            {
                var contactInfos = _context.ContactInfos.ToList();
                var firstContactInfo = contactInfos[0];
                var lastContactInfo = contactInfos[contactInfos.Count - 1];

                var paginatedContactInfos = (contactInfos.Skip((paginationVM.PageIndex - 1) * paginationVM.PageSize)
                                                        .Take(paginationVM.PageSize)).ToList();

                foreach (var paginatedContactInfo in paginatedContactInfos)
                {
                    if (paginatedContactInfo == lastContactInfo)
                    {
                        responseViewModel.EndOfTheList = true;
                    }

                    if (paginatedContactInfo == firstContactInfo)
                    {
                        responseViewModel.BeginningOfTheList = true;
                    }
                }

                responseViewModel.ContactInfos = paginatedContactInfos;

                message = Request.CreateResponse(HttpStatusCode.OK, responseViewModel);
                return message;
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return message;
            }
        }

        [HttpGet, Route("GetContactInfoById/{Id}")]
        public HttpResponseMessage GetContactInfoById(int Id)
        {
            try
            {
                var contactInfo = _context.ContactInfos.FirstOrDefault(c => c.Id == Id);
                if (contactInfo == null)
                {
                    message = Request.CreateResponse(HttpStatusCode.NotFound, "Sorry Contact, does not exist");
                    return message;
                }
                else
                {
                    var contactInfoVM = new ContactInfoViewModel
                    {
                        Id = contactInfo.Id,
                        FullName = contactInfo.FullName,
                        Telephone1 = contactInfo.Telephone1,
                        Telephone2 = contactInfo.Telephone2,
                        EmailAddress = contactInfo.EmailAddress
                    };

                    message = Request.CreateResponse(HttpStatusCode.OK, contactInfoVM);
                    return message;
                }
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return message;
            }
        }

        [HttpPost, Route("CreateContactInfo")]
        public HttpResponseMessage CreateContactInfo(ContactInfoViewModel contactInfoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contactInfo = new ContactInfo
                    {
                        FullName = contactInfoVM.FirstName + " " + contactInfoVM.LastName,
                        Telephone1 = contactInfoVM.Telephone1,
                        Telephone2 = contactInfoVM.Telephone2,
                        EmailAddress = contactInfoVM.EmailAddress
                    };
                    _context.ContactInfos.Add(contactInfo);
                    _context.SaveChanges();
                    message = Request.CreateResponse(HttpStatusCode.Created, "Contact Info Created Successfully");
                }
                return message;
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return message;
            }
        }

        [HttpPost, Route("EditContactInfo")]
        public HttpResponseMessage EditContactInfo(ContactInfoViewModel contactInfoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contactInfo = _context.ContactInfos.FirstOrDefault(c => c.Id == contactInfoVM.Id);
                    if (contactInfo == null)
                    {
                        message = Request.CreateResponse(HttpStatusCode.NotFound, "Sorry Contact, does not exist");
                    }
                    else
                    {
                        contactInfo.FullName = contactInfoVM.FirstName + " " + contactInfoVM.LastName;
                        contactInfo.Telephone1 = contactInfoVM.Telephone1;
                        contactInfo.Telephone2 = contactInfoVM.Telephone2;
                        contactInfo.EmailAddress = contactInfoVM.EmailAddress;
                        _context.SaveChanges();
                        message = Request.CreateResponse(HttpStatusCode.OK, "Contact info updated successfully");
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return message;
            }
        }

        [AcceptVerbs("GET", "POST")]
        [Route("DeleteContactInfo/{Id}")]
        public HttpResponseMessage DeleteContactInfo(int Id)
        {
            try
            {
                var contactInfo = _context.ContactInfos.FirstOrDefault(c => c.Id == Id);
                if (contactInfo == null)
                {
                    message = Request.CreateResponse(HttpStatusCode.NotFound, "Sorry Contact, does not exist");
                }
                else
                {
                    _context.ContactInfos.Remove(contactInfo);
                    _context.SaveChanges();
                    message = Request.CreateResponse(HttpStatusCode.OK, "Contact info deleted successfully");
                }
                return message;
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return message;
            }
        }
    }
}
