using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.DragDrop_Grid.Models;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Grid.Controllers
{
    public class Cell_to_CellController : Controller
    {
        public ActionResult Index()
        {
            return View(new Cell_to_CellModel());
        }
    }
}
