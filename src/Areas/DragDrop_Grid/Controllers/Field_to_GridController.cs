using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.DragDrop_Grid.Models;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Grid.Controllers
{
    public class Field_to_GridController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            return this.Store(new Field_to_GridModel().Companies);
        }
    }
}
