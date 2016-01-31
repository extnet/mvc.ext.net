using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Models.Controllers
{
    public class SubmitController : Controller
    {
        public ActionResult Index()
        {
            return View(Person.GetPerson());
        }

        public ActionResult SuccessSubmit(Person person)
        {
            X.Msg.Alert("Submit", JSON.Serialize(person)).Show();
            return this.FormPanel(true);
        }

        public ActionResult FailureSubmit(FormCollection values)
        {
            var errors = new FieldErrors();
            
            foreach (var key in values.Keys)
            {
                errors.Add(new FieldError(key.ToString(), "Test error for " + key.ToString()));
            }

            return this.FormPanel("Error is emulated", errors);
        }

        public ActionResult DirectEventSubmit(Person person)
        {
            X.Msg.Alert("Submit", JSON.Serialize(person)).Show();
            return this.Direct();
        }
    }
}
