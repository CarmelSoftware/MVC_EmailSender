using EmailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmailSender.Utils;

namespace EmailSender.Controllers
{
    public class EmailSenderController : Controller
    {
        //
        // GET: /EmailSender/

        public ActionResult JustSendIt()
        {
            return View();
        }

        [HttpPost]
        [ActionName("JustSendIt")]
        public ActionResult Create(Email email)
        {
            SMTPGmail oSender = new SMTPGmail();
            Tuple<bool, string> results = oSender.SendEmail(email);
            if (results.Item1)
            {
                TempData["Email"] = email;
                return RedirectToAction("Details");
            }
            else
            {
                TempData["Msg"] = results.Item2;
                return RedirectToAction("JustSendIt");
            }
        }

        public ActionResult Details(Email email)
        {
            return View((Email)TempData["Email"]);
        }
    }
}
