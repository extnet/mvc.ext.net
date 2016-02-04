using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Getting_Started.Controllers
{
    public class CHANGELOGController : Controller
    {
        public ActionResult Index()
        {
            StreamReader streamReader = System.IO.File.OpenText(Server.MapPath("~/App_Readme/Ext.NET/CHANGELOG.md"));
            return View("Index", (object)streamReader.ReadToEnd());
        }
    }
}
