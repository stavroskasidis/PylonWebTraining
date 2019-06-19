using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class FeedbackController : Controller
    {
        public ActionResult Index()
        {
            var model = new FeedbackViewModel();
            model.FirstName = "Anonymous";
            model.LastName = "Anonymous";
            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(FeedbackViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Write to dB
            }


            return RedirectToAction("Index");
        }
    }
}