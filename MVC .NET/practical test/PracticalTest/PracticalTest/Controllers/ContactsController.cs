using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticalTest.Models;

namespace PracticalTest.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contact
        public ActionResult Random()
        {
            var contact = new Contact() { name = "Shrek" };

          
            return View(contact);
        }
    }
}