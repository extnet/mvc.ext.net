using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ColumnModel.Column_Variations.Controllers
{
    public class Column_VariationsController : Controller
    {
        public ActionResult Index()
        {
            return View(Data.GetData());
        }
    }
}
