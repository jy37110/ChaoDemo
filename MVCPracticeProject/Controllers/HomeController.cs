using MVCPracticeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MVCPracticeProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var model = new AboutModels();
            model.Name = "Jesse (Chao Gong)";
            model.Description = "Here is my CV...";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can find me at the following:";
            var model = new Message();

            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(Message model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "You can find me at the following:";
                var passInModel = new Message();
                return View("Contact", passInModel);
            }

            db.Messagese.Add(model);
            db.SaveChanges();

            TempData["message"] = "Thanks for your message.";
            return RedirectToAction("Contact", "Home");
        }

        [HttpPost]
        public ActionResult FlowStatistics(string msg)
        {
            var userId = User.Identity.GetUserId();
            if (msg == "flow" && userId != "41f16096-f814-446d-a703-43dbefdfd7e5")
            {
                var flowModel = new Flow();
                DateTime now = DateTime.Now;
                flowModel.DateTime = now;
                db.Flows.Add(flowModel);
                db.SaveChanges();
            }
            return null;
        }
    }
}