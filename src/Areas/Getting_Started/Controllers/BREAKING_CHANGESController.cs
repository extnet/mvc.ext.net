using System.IO;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Getting_Started.Controllers
{
    public class BREAKING_CHANGESController : Controller
    {
        public ActionResult Index()
        {
            StreamReader streamReader = System.IO.File.OpenText(Server.MapPath("~/App_Readme/Ext.NET/BREAKING_CHANGES.txt"));
            return View("Index", (object)streamReader.ReadToEnd());
        }
    }
}
