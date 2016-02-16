using System.IO;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Getting_Started.Controllers
{
    public class READMEController : Controller
    {
        public ActionResult Index()
        {
            StreamReader streamReader = System.IO.File.OpenText(Server.MapPath("~/App_Readme/Ext.NET/README.md"));
            return View("Index", (object)streamReader.ReadToEnd());
        }
    }
}