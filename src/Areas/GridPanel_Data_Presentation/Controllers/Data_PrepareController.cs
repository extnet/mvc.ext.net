using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation.Data_Prepare.Controllers
{
    public class Data_PrepareController : Controller
    {
        public ActionResult Index()
        {
            return View(Customers.GetAll());
        }
    }
}
