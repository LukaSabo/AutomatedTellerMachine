using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        /*
         * built-in action result types
         * - view
         * - partialview
         * - contentresult
         * - json
         * - redirecttoroutere
         */

        /*
         * common filter types
         * - authorization filter
         * - action filter
         * - result filter
         * - exception filter
         */

        private ApplicationDbContext db = new ApplicationDbContext();

        //[AllowAnonymous]
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }

        [ActionName("about-this-atm")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        //[Route...]
        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble? Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {

            ViewBag.TheMessage = "Thanks, we got your message!";

            return View();
        }

        public ActionResult Foo()
        {
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            //return Content(serial);
            //return new HttpStatusCodeResult(403);
            //return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
            return RedirectToRoute("Index");
        }
    }
}