using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Controllers
{
    public class Reorder_NodesController : Controller
    {
        public ActionResult Index()
        {
            SiteMapNode siteNode = SiteMap.RootNode;
            Node root = Reorder_NodesModel.CreateNode(siteNode);
            root.AllowDrag = false;
            root.Expanded = true;

            return View(root);
        }
    }
}
