using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation.Server_Mapping.Controllers
{
    public class Server_MappingController : Controller
    {
        public ActionResult Index()
        {
            return View(Employee.GetAll());
        }
    }
}
