using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Models.Controllers
{
    public class Model_StateController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit([Bind(Exclude = "Id")]TimeCard card)
        {
            if (this.ModelState.IsValid)
            {
                X.Msg.Notify("Submit", "The card was successfully saved").Show();
            }

            this.GetCmp<ModelStateStore>("ModelStateStore1").DataBind();

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
