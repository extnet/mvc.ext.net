using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.DragDrop_Advanced.Models;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Advanced.Controllers
{
    public class Example3Controller : Controller
    {
        public ActionResult Index()
        {
            return View(new Example3Model());
        }
    }
}
