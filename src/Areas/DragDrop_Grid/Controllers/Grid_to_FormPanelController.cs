using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.DragDrop_Grid.Models;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Grid.Controllers
{
    public class Grid_to_FormPanelController : Controller
    {
        public ActionResult Index()
        {
            return View(new Grid_to_FormPanelModel());
        }
    }
}
