using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Models.Models;

namespace Ext.Net.MVC.Examples.Areas.Models.Controllers
{
    public class FormPanelForController : Controller
    {
        public ActionResult Index()
        {
            return View(FormPanelEmployee.GetAll()[0]);
        }

        public ActionResult Submit(FormPanelEmployee employee)
        {   
            X.Msg.Alert("Employee", JSON.Serialize(employee)).Show();
            return this.Direct();
        }
    }
}
