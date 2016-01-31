using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Models.Controllers
{
    public class Data_AnnotationsController : Controller
    {
        public ActionResult Index()
        {
            var card = new TimeCard();
            this.Session["card"] = card;
            return View(card);
        }

        public ActionResult GoToViewMode(string containerId)
        {
            return this.PartialExtView(
                viewName: "Display", 
                containerId: containerId, 
                model: this.Session["card"], 
                mode: RenderMode.AddTo, 
                clearContainer: true
            );
        }

        public ActionResult GoToEditMode(string containerId)
        {
            return this.PartialExtView(
                viewName: "Edit", 
                containerId: containerId, 
                model: this.Session["card"], 
                mode: RenderMode.AddTo, 
                clearContainer: true
            );
        }

        public ActionResult Submit(TimeCard card)
        {
            if (this.ModelState.IsValid)
            {
                this.Session["card"] = card;
                X.Msg.Notify("Submit", "The card was successfully saved").Show();
            }
            
            return this.FormPanel(this.ModelState);
        }

        public JsonResult CheckUsername(string username)
        {
            if (username != "TestUser")
            {
                return Json(new { valid = false, message = "Username must be TestUser" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { valid = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
