using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Controllers
{
    public class EditorsController : Controller
    {
        public ActionResult Index()
        {
            return View(new Tuple<Node, Node>(EditorsModel.BuildTree(), EditorsModel.BuildTree()));
        }
    }
}
